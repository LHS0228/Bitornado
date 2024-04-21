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
    [Header("중심점, 속도, 거리 설정")]
    private Transform centerPoint; // 중심점
    public float rotationSpeed = 10f; // 회전 속도
    public float distance = 10f; // 중심점과의 거리

    [Header("반대로 돌기 방향 설정")]
    public bool turnRotation;

    [Header("점프 관련 설정")]
    public float jumpDistance = 2f; // 점프시 추가 거리
    public float jumpSpeed = 5f; // 점프 속도
    public float jumpTime = 0.5f;

    [Header("대쉬 관련 설정")]
    public float dashSpeedMultiplier = 3f; // 대쉬 속도 배수
    public float dashTime = 0.3f; // 대쉬 지속 시간

    [Header("왠만하면 건들지 말 것")]
    Vector2 inputVec;
    [SerializeField]
    private bool isJumping = false;
    [SerializeField]
    private bool isDashing = false;
    public float currentDistance; //점프 설정

    private void Start()
    {
        currentDistance = distance;
        silhouette = GetComponent<Silhouette>();
    }

    void FixedUpdate()
    {
        // 중심점을 기준으로 한 회전을 계산합니다.
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
        if (difference != Vector3.zero) // 벡터가 0이 아니면 정규화
        {
            Vector3 orbitPosition = difference.normalized * currentDistance + centerPoint.position;
            transform.position = orbitPosition;
        }
        else // 벡터가 0이면 기본 방향을 설정
        {
            transform.position = centerPoint.position + new Vector3(0, distance, 0); // 중심점 위로 거리만큼 위치
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

        // 점프 후 원래 거리로 복귀
        elapsed = 0;
        while (elapsed < jumpTime)
        {
            currentDistance = Mathf.Lerp(distance + jumpDistance, distance, elapsed / jumpTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        isJumping = false;

        Debug.Log("점프 작동함");
    }

    private IEnumerator DashRoutine()
    {
        Debug.Log("Dash started"); // 대쉬 시작 로그
        isDashing = true;
        silhouette.Active = true;
        float originalSpeed = rotationSpeed; // 원래 속도를 임시 변수에 저장
        rotationSpeed *= dashSpeedMultiplier; // 회전 속도 증가

        try
        {
            yield return new WaitForSeconds(dashTime); // 대쉬 지속 시간
        }
        finally
        {
            rotationSpeed = originalSpeed; // 회전 속도를 원래대로 복구
            isDashing = false; // IsDashing 플래그를 false로 설정
            silhouette.Active = false;
            Debug.Log("Dash ended"); // 대쉬 종료 로그
        }
    }
}

