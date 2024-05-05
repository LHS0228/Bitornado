using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerDamage_Controller : MonoBehaviour
{
    [SerializeField]
    private PlayerMove playerMove;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public GameObject camera_vistual;

    // Start is called before the first frame update
    void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void getDamage()
    {
        if (playerMove.isInvencible == false)
        {

            camera_vistual.transform.DOMove(new Vector3(2, 1.2f, -15), 0);
            camera_vistual.transform.DOMove(new Vector3(0, -2, -15), 0).SetDelay(0.15f);
            camera_vistual.transform.DOMove(new Vector3(-1.1f, -0.5f, -15), 0).SetDelay(0.3f);


            if (playerMove.nowHP == 0)
            {
                //GameOver;
            }
            else
            {
                playerMove.nowHP -= 1;
                StartCoroutine(AdjustDistanceSmoothly(playerMove.currentDistance, playerMove.hpDistance[playerMove.nowHP]));
            }

            playerMove.isInvencible = true;
            spriteRenderer.color = new Color32(255, 0, 0, 20);
            DOVirtual.DelayedCall(3, () => playerMove.isInvencible = false); //3초 무적
            DOVirtual.DelayedCall(3, () => new Color32(255, 0, 0, 255));
        }
    }

    private IEnumerator AdjustDistanceSmoothly(float startDistance, float endDistance)
    {
        float duration = 0.5f; // 전환에 걸리는 시간
        float elapsed = 0;

        while (elapsed < duration)
        {
            playerMove.currentDistance = Mathf.Lerp(startDistance, endDistance, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        playerMove.currentDistance = endDistance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("데미지 입음");
        
        getDamage();
    }
}
