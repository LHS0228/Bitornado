using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] prefabs;  // 프리펩들을 보관할 변수
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index, Vector3 scale, Vector3 startTrans, string effectType, float onTime, float idleTime, float attackTime)
    {
        GameObject select = FindOrCreateObstacle(index, startTrans);
        SetupObstacle(select, scale, effectType, onTime, idleTime, attackTime);
        return select;
    }

    private GameObject FindOrCreateObstacle(int index, Vector3 startTrans)
    {
        GameObject select = null;
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                break;
            }
        }

        if (select == null)
        {
            select = Instantiate(prefabs[index], startTrans, Quaternion.identity);
            pools[index].Add(select);
        }

        select.transform.position = startTrans; // 위치 설정

        return select;
    }

    private void SetupObstacle(GameObject obstacle, Vector3 scale, string effectType, float onTime, float idleTime, float attackTime)
    {
        Obstacle obstacleComponent = obstacle.GetComponent<Obstacle>();

        obstacleComponent.obstacleRenderer.color = new Color(Random.Range(100, 255) / 255f, Random.Range(100, 255) / 255f, Random.Range(100, 255) / 255f);
        obstacleComponent.scale = scale;
        obstacleComponent.effectType = effectType;
        obstacleComponent.onTime = onTime;
        obstacleComponent.idleTime = idleTime;
        obstacleComponent.attackTime = attackTime;
    
        obstacle.transform.localScale = scale;  // 스케일 설정
        obstacle.SetActive(true);  // 오브젝트 활성화
    }
}