using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleManager : MonoBehaviour
{
    //프리펩들을 보관할 변수
    public GameObject[] prefabs;

    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    //index = 프리펩, scale = 크기, startTrans = 나타나는 위치,  
    public GameObject Get(int index, Vector3 scale, Vector3 startTrans, Color32 color, string effectType, float onTime, float idleTime, float attackTime)
    {
        GameObject select = null;

        foreach(GameObject item in pools[index]) {
            if(!item.activeSelf)
            {
                select = item;
                select.transform.position = startTrans;
                select.SetActive(true);
                break;
            }
        }

        if(select == null)
        {
            select = Instantiate(prefabs[index], startTrans, Quaternion.identity);
            pools[index].Add(select);
        }

        Obstacle obstacle = select.GetComponent<Obstacle>();

        obstacle.obstacleMaterial.color = color;
        obstacle.idleTime = idleTime;
        obstacle.scale = scale;
        obstacle.onTime = onTime;
        obstacle.effectType = effectType;

        return select;
    }

    public GameObject Get(int index, Vector3 scale, Vector3 startTrans, Color32 color, string effectType, float onTime, float attackTime)
    {
        GameObject select = null;

        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.transform.position = startTrans;
                select.SetActive(true);
                break;
            }
        }

        if (select == null)
        {
            select = Instantiate(prefabs[index], startTrans, Quaternion.identity);
            pools[index].Add(select);
        }

        Obstacle obstacle = select.GetComponent<Obstacle>();

        obstacle.obstacleMaterial.color = color;
        obstacle.idleTime = 0;
        obstacle.scale = scale;
        obstacle.onTime = onTime;
        obstacle.effectType = effectType;

        return select;
    }
}