using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSystem : MonoBehaviour
{
    public GameObject logo;
    public GameObject logo_2;

    public GameObject start;
    public GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        logo.transform.DOMoveY(logo.transform.position.y + 30, 1.0f) // 1�� ���� ���� 3 ���� �̵�
    .SetLoops(-1, LoopType.Yoyo) // ���� ����, Yoyo ���
    .SetEase(Ease.InOutQuad); // �ε巯�� ���۰� ���� ���� ��¡

        logo_2.transform.DOMoveY(logo.transform.position.y + 35, 1.0f) // 1�� ���� ���� 3 ���� �̵�
    .SetLoops(-1, LoopType.Yoyo) // ���� ����, Yoyo ���
    .SetEase(Ease.InOutQuad); // �ε巯�� ���۰� ���� ���� ��¡


        start.transform.DOMoveY(start.transform.position.y + 5, 1f) // 1�� ���� ���� 3 ���� �̵�
    .SetLoops(-1, LoopType.Yoyo) // ���� ����, Yoyo ���
    .SetEase(Ease.InOutQuad); // �ε巯�� ���۰� ���� ���� ��¡

        exit.transform.DOMoveY(exit.transform.position.y + 5, 1f) // 1�� ���� ���� 3 ���� �̵�
    .SetLoops(-1, LoopType.Yoyo) // ���� ����, Yoyo ���
    .SetEase(Ease.InOutQuad); // �ε巯�� ���۰� ���� ���� ��¡
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void OnStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnOption()
    {
       
    }

    public void OnEnd()
    {
        Application.Quit();
    }
}
