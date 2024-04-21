using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Silhouette silhouette;

    [SerializeField]
    [Header("�߽���, �ӵ�, �Ÿ� ����")]
    private Transform centerPoint; // �߽���
    public float rotationSpeed = 10f; // ȸ�� �ӵ�
    public float distance = 10f; // �߽������� �Ÿ�

    [Header("�ݴ�� ���� ���� ����")]
    public bool turnRotation;

    [Header("���� ���� ����")]
    public float jumpDistance = 2f; // ������ �߰� �Ÿ�
    public float jumpSpeed = 5f; // ���� �ӵ�
    public float jumpTime = 0.5f;

    [Header("�뽬 ���� ����")]
    public float dashSpeedMultiplier = 3f; // �뽬 �ӵ� ���
    public float dashTime = 0.3f; // �뽬 ���� �ð�

    [Header("�ظ��ϸ� �ǵ��� �� ��")]
    Vector2 inputVec;
    [SerializeField]
    private bool isJumping = false;
    [SerializeField]
    private bool isDashing = false;
    public float currentDistance; //���� ����

    private void Start()
    {
        currentDistance = distance;
        silhouette = GetComponent<Silhouette>();
    }

    void FixedUpdate()
    {
        // �߽����� �������� �� ȸ���� ����մϴ�.
        float rotationAmount = inputVec.x * rotationSpeed;

        if (rotationAmount != 0)
        {
            transform.RotateAround(centerPoint.position, Vector3.forward, -rotationAmount * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(centerPoint.position, Vector3.forward, (turnRotation ? -1 : 1) * rotationSpeed * Time.deltaTime);
        }

        Vector3 difference = transform.position - centerPoint.position;
        if (difference != Vector3.zero) // ���Ͱ� 0�� �ƴϸ� ����ȭ
        {
            Vector3 orbitPosition = difference.normalized * currentDistance + centerPoint.position;
            transform.position = orbitPosition;
        }
        else // ���Ͱ� 0�̸� �⺻ ������ ����
        {
            transform.position = centerPoint.position + new Vector3(0, distance, 0); // �߽��� ���� �Ÿ���ŭ ��ġ
        }
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (!isJumping)
        {
            StartCoroutine(JumpRoutine());
        }
    }

    void OnDash()
    {
        if (!isJumping && !isDashing)
        {
            StartCoroutine(DashRoutine());
        }
    }

    private IEnumerator JumpRoutine()
    {
        isJumping = true;
        float elapsed = 0;

        while (elapsed < jumpTime)
        {
            currentDistance = Mathf.Lerp(distance, distance + jumpDistance, elapsed / jumpTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // ���� �� ���� �Ÿ��� ����
        elapsed = 0;
        while (elapsed < jumpTime)
        {
            currentDistance = Mathf.Lerp(distance + jumpDistance, distance, elapsed / jumpTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        isJumping = false;

        Debug.Log("���� �۵���");
    }

    private IEnumerator DashRoutine()
    {
        Debug.Log("Dash started"); // �뽬 ���� �α�
        isDashing = true;
        silhouette.Active = true;
        float originalSpeed = rotationSpeed; // ���� �ӵ��� �ӽ� ������ ����
        rotationSpeed *= dashSpeedMultiplier; // ȸ�� �ӵ� ����

        try
        {
            yield return new WaitForSeconds(dashTime); // �뽬 ���� �ð�
        }
        finally
        {
            rotationSpeed = originalSpeed; // ȸ�� �ӵ��� ������� ����
            isDashing = false; // IsDashing �÷��׸� false�� ����
            silhouette.Active = false;
            Debug.Log("Dash ended"); // �뽬 ���� �α�
        }
    }
}

