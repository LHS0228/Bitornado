using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
using System.Net;
using Unity.VisualScripting;

public class Obstacle : MonoBehaviour
{
    public Material obstacleMaterial;
    public SpriteRenderer obstacleRenderer;
    public Quaternion obstacleQuaternion;

    public Transform endPoint;   // ���� ������Ʈ

    public Vector3 startTrans;
    public Vector3 endTrans;
    public Vector3 scale;

    public float delayTime;
    public float onTime;

    public string effectType;

    //����
    Vector3 direction;
    float angle;

    [SerializeField]
    private bool isAttack = false;

    public GameObject lineBox;

    private void Awake()
    {
        obstacleMaterial = GetComponent<Material>();
        obstacleRenderer = GetComponent<SpriteRenderer>();
        lineBox = transform.Find("LineBox").gameObject;
        endPoint = GameObject.FindWithTag("WhirlWind").transform;
    }

    private void OnEnable()
    {
        transform.position = startTrans;
        transform.localScale = scale;

        direction = Vector3.zero - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        SetTransparency(0);

        obstacleRenderer.DOFade(1, delayTime).SetEase(Ease.InOutQuad).SetUpdate(UpdateType.Fixed);

        switch (effectType)
        {
            case "Rolling":
                transform.DORotate(new Vector3(0, 0, 360), delayTime, RotateMode.FastBeyond360).SetRelative().SetUpdate(UpdateType.Fixed);
                lineBox.transform.DOScaleX(1, onTime).SetUpdate(UpdateType.Fixed).SetDelay(delayTime);
                break;
            case "Sizing":
                transform.position.Scale(new Vector3(0,0,0));
                transform.DOScale(scale, delayTime).SetUpdate(UpdateType.Fixed);
                break;
        }

        transform.DOMove(new Vector3(0,0,0), onTime).SetDelay(delayTime).SetEase(Ease.Linear).SetUpdate(UpdateType.Fixed).OnComplete(() => {
            transform.DOScaleX(0, 0.2f);});
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

            //Target ������Ʈ�� ���� �߽��� �ٶ󺸰� �մϴ�.
            direction = Vector3.zero - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Target�� ���� �߽��� �Ÿ��� ���� Hitbox�� ũ�⸦ �����մϴ�.
            float distance = Vector3.Distance(transform.position, Vector3.zero);
            lineBox.transform.localScale = new Vector3(1, distance, 1); // X�� Z�� ����, Y�� �Ÿ��� ���� ����
        }
        else
        {
            if (lineBox.activeSelf)
            {
                lineBox.SetActive(false);
            }
        }
    }

    private void SetTransparency(float alpha)
    {
        Color newColor = obstacleRenderer.color; // ���� ������ �����ɴϴ�
        newColor.a = alpha; // ������ ���� �����մϴ�
        obstacleRenderer.color = newColor; // ������ �������� �����մϴ�
    }
}