using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_01 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(1, 1, 1), new Color(255, 255, 255), "Rolling", 0.5f, 0.5f, 1f);
    }
}
