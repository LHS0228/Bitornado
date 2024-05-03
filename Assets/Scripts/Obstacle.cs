using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
using System.Net;
using Unity.VisualScripting;

public class Obstacle : MonoBehaviour
{
    public SpriteRenderer obstacleRenderer;

    public Vector3 startTrans;
    public Vector3 scale;

    public float onTime;
    public float idleTime;
    public float attackTime;

    public string effectType;

    //설정
    Vector3 direction;
    float angle;

    [SerializeField]
    private bool isAttack = false;

    public GameObject lineBox;

    private void Awake()
    {
        obstacleRenderer = GetComponent<SpriteRenderer>();
        lineBox = transform.Find("LineBox").gameObject;
    }

    private void OnEnable()
    {
        DOTween.Kill(gameObject);

        direction = Vector3.zero - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        SetTransparency(0);

        obstacleRenderer.DOFade(1, onTime).SetEase(Ease.InOutQuad).SetUpdate(UpdateType.Fixed).SetDelay(onTime);

        switch (effectType)
        {
            case "Rolling":
                transform.DORotate(new Vector3(0, 0, 360), onTime, RotateMode.FastBeyond360).SetDelay(onTime).SetRelative().SetUpdate(UpdateType.Fixed);
                lineBox.transform.DOScaleX(1, attackTime).SetUpdate(UpdateType.Fixed).SetDelay(onTime);
                break;

            case "Sizing":
                transform.position.Scale(new Vector3(0,0,0));
                transform.DOScale(scale, onTime).SetUpdate(UpdateType.Fixed).SetDelay(onTime);
                break;
        }

        DOVirtual.DelayedCall(onTime - 0.1f, () => { isAttack = true; }).SetUpdate(UpdateType.Fixed);

        transform.DOMove(new Vector3(0, 0, 0), attackTime).SetDelay(onTime+idleTime).SetEase(Ease.Linear).SetUpdate(UpdateType.Fixed)
            .OnComplete(() => { transform.DOScaleX(0, 0.2f).OnComplete(() => { gameObject.SetActive(false); }); }).SetUpdate(UpdateType.Fixed);
    }

    private void OnDisable()
    {
        isAttack = false;
        SetTransparency(0);
        lineBox.transform.localScale = new Vector3(0, lineBox.transform.localScale.y, lineBox.transform.localScale.z);
    }

    private void FixedUpdate()
    {
        if (isAttack)
        {
            if (!lineBox.activeSelf)
            {
                lineBox.SetActive(true);
            }

            //Target 오브젝트가 월드 중심을 바라보게 합니다.
            direction = Vector3.zero - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            if (transform.position != Vector3.zero)
            {
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            // Target과 월드 중심의 거리에 따라 Hitbox의 크기를 조절합니다.
            float distance = Vector3.Distance(transform.position, Vector3.zero);
            lineBox.transform.localScale = new Vector3(lineBox.transform.localScale.x, distance, 1); // X와 Z는 고정, Y만 거리에 따라 조정
        }
    }

    private void SetTransparency(float alpha)
    {
        isAttack = false;
        Color newColor = obstacleRenderer.color; // 현재 색상을 가져옵니다
        newColor.a = alpha; // 투명도 값을 조정합니다
        obstacleRenderer.color = newColor; // 수정된 색상으로 설정합니다
    }
}
