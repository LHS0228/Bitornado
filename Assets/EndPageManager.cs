using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EndPageManager : MonoBehaviour
{
    public TextMeshProUGUI[] pointRankingText;
    public GameObject[] pointRanking_obj;

    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < pointRanking_obj.Length; i++)
        {
            pointRanking_obj[i].GetComponent<TextMeshProUGUI>();
        }
    }

    void Start()
    {
        for(int i=0; i< pointRanking_obj.Length; i++)
        {
            pointRanking_obj[i].transform.DOMoveY(pointRanking_obj[i].transform.position.y + 4, 1.0f) // 1�� ���� ���� 3 ���� �̵�
        .SetLoops(-1, LoopType.Yoyo) // ���� ����, Yoyo ���
        .SetEase(Ease.InOutQuad); // �ε巯�� ���۰� ���� ���� ��¡
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ReStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
