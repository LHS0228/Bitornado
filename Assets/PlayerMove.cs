using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Transform centerPoint; // �߽���
    public float rotationSpeed = 10f; // ȸ�� �ӵ�
    public float distance = 10f; // �߽������� �Ÿ�

    Vector2 inputVec;

    void FixedUpdate()
    {
        // �߽����� �������� �� ȸ���� ����մϴ�.
        transform.RotateAround(centerPoint.position, Vector3.forward, (-1 * inputVec.x * rotationSpeed) * Time.deltaTime);

        Vector3 orbitPosition = (transform.position - centerPoint.position).normalized * distance + centerPoint.position;
        transform.position = orbitPosition;
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}

