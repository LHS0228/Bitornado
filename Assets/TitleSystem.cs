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
    public Animator start_anim;
    public Animator exit_anim;

    // Start is called before the first frame update
    void Start()
    {
        logo.transform.DOMoveY(logo.transform.position.y + 30, 1.0f) // 1초 동안 위로 3 유닛 이동
    .SetLoops(-1, LoopType.Yoyo) // 무한 루프, Yoyo 방식
    .SetEase(Ease.InOutQuad); // 부드러운 시작과 끝을 위한 이징

        logo_2.transform.DOMoveY(logo.transform.position.y + 35, 1.0f) // 1초 동안 위로 3 유닛 이동
    .SetLoops(-1, LoopType.Yoyo) // 무한 루프, Yoyo 방식
    .SetEase(Ease.InOutQuad); // 부드러운 시작과 끝을 위한 이징


        start.transform.DOMoveY(start.transform.position.y + 5, 1f) // 1초 동안 위로 3 유닛 이동
    .SetLoops(-1, LoopType.Yoyo) // 무한 루프, Yoyo 방식
    .SetEase(Ease.InOutQuad); // 부드러운 시작과 끝을 위한 이징

        exit.transform.DOMoveY(exit.transform.position.y + 5, 1f) // 1초 동안 위로 3 유닛 이동
    .SetLoops(-1, LoopType.Yoyo) // 무한 루프, Yoyo 방식
    .SetEase(Ease.InOutQuad); // 부드러운 시작과 끝을 위한 이징
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void OnStart()
    {
        start_anim.enabled = true;
        DOVirtual.DelayedCall(1, () => SceneManager.LoadScene("SampleScene"));
    }

    public void OnEnd()
    {
        exit_anim.enabled = true;
        DOVirtual.DelayedCall(1, () => Application.Quit());
    }
}
