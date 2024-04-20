using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    [SerializeField]
    private float spinSpeed = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0f, 0, spinSpeed * Time.deltaTime);
    }
}
