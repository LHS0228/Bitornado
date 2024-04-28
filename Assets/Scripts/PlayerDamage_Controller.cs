using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage_Controller : MonoBehaviour
{
    [SerializeField]
    private PlayerMove playerMove;

    // Start is called before the first frame update
    void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    public void getDamage()
    {
        if (playerMove.nowHP != 0)
        {
            playerMove.nowHP--;
            StartCoroutine(AdjustDistanceSmoothly(playerMove.currentDistance, playerMove.hpDistance[playerMove.nowHP]));
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
}
