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
            pointRanking_obj[i].transform.DOMoveY(pointRanking_obj[i].transform.position.y + 4, 1.0f) // 1초 동안 위로 3 유닛 이동
        .SetLoops(-1, LoopType.Yoyo) // 무한 루프, Yoyo 방식
        .SetEase(Ease.InOutQuad); // 부드러운 시작과 끝을 위한 이징
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
