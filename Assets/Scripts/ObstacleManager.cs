using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] prefabs;  // ��������� ������ ����
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index, Vector3 scale, Vector3 startTrans, Color32 color, string effectType, float onTime, float idleTime, float attackTime)
    {
        GameObject select = FindOrCreateObstacle(index, startTrans);
        SetupObstacle(select, scale, color, effectType, onTime, idleTime, attackTime);
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

        select.transform.position = startTrans; // ��ġ ����

        return select;
    }

    private void SetupObstacle(GameObject obstacle, Vector3 scale, Color32 color, string effectType, float onTime, float idleTime, float attackTime)
    {
        Obstacle obstacleComponent = obstacle.GetComponent<Obstacle>();

        obstacleComponent.obstacleRenderer.color = color;
        obstacleComponent.scale = scale;
        obstacleComponent.effectType = effectType;
        obstacleComponent.onTime = onTime;
        obstacleComponent.idleTime = idleTime;
        obstacleComponent.attackTime = attackTime;
    
        obstacle.transform.localScale = scale;  // ������ ����
        obstacle.SetActive(true);  // ������Ʈ Ȱ��ȭ
    }
}