using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EndPageManager : MonoBehaviour
{
    public GameObject pointHigh_obj;
    public TextMeshProUGUI pointHigh_Text;

    public GameObject pointRank_obj;
    public TextMeshProUGUI pointRank_Text;

    // Start is called before the first frame update
    private void Awake()
    {
        pointRank_Text = pointRank_obj.GetComponent<TextMeshProUGUI>();
        pointHigh_Text = pointHigh_obj.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        pointRank_obj.transform.DOMoveY(pointRank_obj.transform.position.y + 5, 1.0f) // 1�� ���� ���� 3 ���� �̵�
    .SetLoops(-1, LoopType.Yoyo) // ���� ����, Yoyo ���
    .SetEase(Ease.InOutQuad); // �ε巯�� ���۰� ���� ���� ��¡

        pointHigh_obj.transform.DOMoveY(pointHigh_obj.transform.position.y + 5, 1.0f) // 1�� ���� ���� 3 ���� �̵�
    .SetLoops(-1, LoopType.Yoyo) // ���� ����, Yoyo ���
    .SetEase(Ease.InOutQuad); // �ε巯�� ���۰� ���� ���� ��¡

        pointHigh_Text.text = $"{PlayerPrefs.GetInt("HighPoint")}";
        pointRank_Text.text = $"{PlayerPrefs.GetInt("TimePoint")}";

        pointRank_obj.transform.DOMoveY(pointRank_obj.transform.position.y + 4, 1.0f) // 1�� ���� ���� 3 ���� �̵�
        .SetLoops(-1, LoopType.Yoyo) // ���� ����, Yoyo ���
        .SetEase(Ease.InOutQuad); // �ε巯�� ���۰� ���� ���� ��¡
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
