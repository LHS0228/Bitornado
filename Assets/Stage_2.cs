using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2 : MonoBehaviour
{
    float Tiame;
    bool isgo;
    public AudioClip stage01_Music;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isgo)
        {
            Debug.Log(Tiame += Time.deltaTime);
        }
    }

    public void Stage01_Start()
    {
        DOTween.KillAll();

        isgo = true;
        Tiame = 0;
        GameManager.instance.gameBGM.clip = stage01_Music;
        GameManager.instance.gameBGM.Play();

        DOVirtual.DelayedCall(0.5f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(-5, 5, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.28f, 0.2f)).SetUpdate(UpdateType.Fixed); //총합 : 1.18 나와함
        DOVirtual.DelayedCall(0.9f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(5, -5, 1), new Color(255, 0, 0), "Rolling", 0.3f, 0.56f, 0.2f)).SetUpdate(UpdateType.Fixed); //총합 : 1.96 ···

        DOVirtual.DelayedCall(3.98f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(-3, 3, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //4.52
        DOVirtual.DelayedCall(4.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(3, -3, 1), new Color(255, 255, 0), "Rolling", 0.2f, 0.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //5.06

        DOVirtual.DelayedCall(6.86f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(-4, 4, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //7.4
        DOVirtual.DelayedCall(7.5f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(4, -4, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //8.02

        DOVirtual.DelayedCall(9.96f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(-6, 6, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //9.28
        DOVirtual.DelayedCall(10.4f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(6, -6, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //10.14

        DOVirtual.DelayedCall(12.9f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(-5, 5, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //12.33
        DOVirtual.DelayedCall(13.4f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(5, -5, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //여기까지 1차 완료

        //-------------------------------

        DOVirtual.DelayedCall(12.9f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(-5, 5, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //16.15
        DOVirtual.DelayedCall(13.22f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(5, -5, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //17

        DOVirtual.DelayedCall(12.9f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(-5, 5, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //19
        DOVirtual.DelayedCall(13.22f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(5, -5, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //19.4 

        DOVirtual.DelayedCall(12.9f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(-5, 5, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //21.8
        DOVirtual.DelayedCall(13.22f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(5, -5, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //22.4

        DOVirtual.DelayedCall(12.9f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(-5, 5, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //24.7
        DOVirtual.DelayedCall(13.22f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, 1, 1), new Vector3(5, -5, 1), new Color(255, 0, 0), "Rolling", 0.2f, 0.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //25.5

        //27.74
        //28.14

        //30.2
        //31.1~0

        //33.2
        //33.8

        //36.2
        //36.7

        //38.9
        //39.3

        //41.5
        //42.3

        //44.4
        //45


    }
}
