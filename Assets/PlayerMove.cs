using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Transform centerPoint; // 중심점
    public float rotationSpeed = 10f; // 회전 속도
    public float distance = 10f; // 중심점과의 거리

    Vector2 inputVec;

    void FixedUpdate()
    {
        // 중심점을 기준으로 한 회전을 계산합니다.
        transform.RotateAround(centerPoint.position, Vector3.forward, (-1 * inputVec.x * rotationSpeed) * Time.deltaTime);

        Vector3 orbitPosition = (transform.position - centerPoint.position).normalized * distance + centerPoint.position;
        transform.position = orbitPosition;
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}

