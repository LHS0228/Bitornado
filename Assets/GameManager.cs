using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ObstacleManager obstacle;

    public GameObject whirlWind;

    public GameObject player;

    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        ;
    }
}
