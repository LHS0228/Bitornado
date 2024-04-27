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

    public GameObject Get(int index, Vector3 scale, Vector3 startTrans, Quaternion quaternion, Color32 color, string effectName, float delayTime, float onTime)
    {
        GameObject select = null;

        foreach(GameObject item in pools[index]) {
            if(!item.activeSelf)
            {
                select = item;
                select.transform.position = startTrans;
                select.transform.rotation = quaternion;
                select.SetActive(true);
                break;
            }
        }

        if(select == null)
        {
            select = Instantiate(prefabs[index], startTrans, quaternion);
            pools[index].Add(select);
        }

        Obstacle obstacle = select.GetComponent<Obstacle>();
        obstacle.obstacleQuaternion = quaternion;
        obstacle.obstacleMaterial.color = color;
        obstacle.onTime = onTime;
        obstacle.scale = scale;
        obstacle.delayTime = delayTime;

        return select;
    }

}