using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage_Controller : MonoBehaviour
{
    [SerializeField]
    private PlayerMove playerMove;

    [SerializeField]
    private float[] hpTrans = { 0, 3.5f, 6.5f, 9 };
    public int hp = 3;

    // Start is called before the first frame update
    void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
    }

    public void getDamage()
    {
        if (hp != 0)
        {
            hp--;
            playerMove.currentDistance = hpTrans[hp];
            Debug.Log(hpTrans[hp]);
        }
    }
}
