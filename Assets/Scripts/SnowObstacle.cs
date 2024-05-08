using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SnowObstacle : MonoBehaviour
{
    public float onTime;
    public float idleTime;
    public float attackTime;

    public float attackSpeed = 10.0f;
    Vector3 direction = Vector3.down;

    private void Update()
    {
        transform.position += direction * attackSpeed * Time.deltaTime;
    }

};