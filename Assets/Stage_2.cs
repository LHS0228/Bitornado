using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2 : MonoBehaviour
{
    bool isgo;
    public AudioSource gameBGM;
    public AudioClip stage01_Music;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Stage02_Start()
    {
        DOTween.KillAll();

        isgo = true;
        gameBGM.clip = stage01_Music;
        gameBGM.Play();

        DOVirtual.DelayedCall(0, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-17, 5, 1), "Rolling", 0.7f, 0.28f, 0.2f)).SetUpdate(UpdateType.Fixed); //총합 : 1.18 나와함
        DOVirtual.DelayedCall(0.6f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(17, 5, 1), "Rolling", 1.0f, 0.56f, 0.2f)).SetUpdate(UpdateType.Fixed); //총합 : 1.96 ···

        DOVirtual.DelayedCall(3.98f - 1, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(7, -17, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //4.52
        DOVirtual.DelayedCall(4.54f - 1, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(7, 17, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //5.06

        DOVirtual.DelayedCall(6.86f - 1, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-20, 0, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //7.4
        DOVirtual.DelayedCall(7.5f - 1, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, 0, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //8.02

        DOVirtual.DelayedCall(9.96f - 1, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-19, 13, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //9.28
        DOVirtual.DelayedCall(10.4f - 1, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(15, 13, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //10.14

        DOVirtual.DelayedCall(12.9f - 1, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, 9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //12.33
        DOVirtual.DelayedCall(13.4f - 1, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-18, 9, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //여기까지 1차 완료

        //-------------------------------

        DOVirtual.DelayedCall(16.15f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, -9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //16.15
        DOVirtual.DelayedCall(17 - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(17, 5, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //17

        DOVirtual.DelayedCall(19 - 1.54f , () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(16, -17, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //19
        DOVirtual.DelayedCall(19.4f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(7, 17, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //19.4 

        DOVirtual.DelayedCall(21.8f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(19, 13, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //21.8
        DOVirtual.DelayedCall(22.4f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(19, -13, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //22.4

        DOVirtual.DelayedCall(24.7f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, 9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //24.7
        DOVirtual.DelayedCall(25.5f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-18, 9, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //25.5

        //---------------------------------------
        //0.54
        //0.52
        //DOVirtual.DelayedCall(26.0f - 1.54f, () => Debug.Log("Hi")); 이때 눈 장애물
        for (int i = 0; i < 40; i++)
        {
            float x = Random.Range(-15, 15);
            
            DOVirtual.DelayedCall(Random.Range(25.0f, 28.0f), () => GameManager.instance.obstacle.Get(1, new Vector3(x, 30, 0), 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed);
        }

        DOVirtual.DelayedCall(27.2f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(0, -15, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //27.74
        DOVirtual.DelayedCall(27.62f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(0, 18, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //28.14

        DOVirtual.DelayedCall(30.2f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-2, -12, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //30.2
        DOVirtual.DelayedCall(31.1f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-5, 18, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //31.1

        DOVirtual.DelayedCall(33.2f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(5, -12, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //33.2
        DOVirtual.DelayedCall(33.8f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-6, 18, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //33.8

        DOVirtual.DelayedCall(36.2f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(3, -12, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //36.2
        DOVirtual.DelayedCall(36.7f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-9, 18, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //36.7

        DOVirtual.DelayedCall(38.9f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(7, -12, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //38.9
        DOVirtual.DelayedCall(39.3f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-3, 18, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //39.3

        DOVirtual.DelayedCall(41.5f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-8, 18, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //41.5
        DOVirtual.DelayedCall(42.2f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(6, -12, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //42.2


        DOVirtual.DelayedCall(44.4f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(7, -17, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //44.4
        DOVirtual.DelayedCall(45f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-20, 0, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //45

        DOVirtual.DelayedCall(47 - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-19, 13, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //47
        DOVirtual.DelayedCall(50.3f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, 9, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //50.3

        DOVirtual.DelayedCall(53.1f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, -9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //53.1

        //프리랩 타이밍이라 따로 만들기

        DOVirtual.DelayedCall(69.8f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(16, -17, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //69.8
        DOVirtual.DelayedCall(70.4f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(19, 13, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //70.4

        DOVirtual.DelayedCall(72.8f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, 9, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //72.8
        DOVirtual.DelayedCall(73.2f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-18, 9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //73.2

        DOVirtual.DelayedCall(75.4f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, -9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //75.4
        DOVirtual.DelayedCall(76.1f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(-1, 1, 1), new Vector3(17, 5, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //76.1

        DOVirtual.DelayedCall(78.3f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(1, -1, 1), new Vector3(7, 17, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //78.3
        DOVirtual.DelayedCall(78.9f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(19, -13, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //78.9

        DOVirtual.DelayedCall(81f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-18, 9, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //81

        DOVirtual.DelayedCall(84f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, -9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //84
        DOVirtual.DelayedCall(86.8f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(17, 5, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //86.8

        DOVirtual.DelayedCall(89f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(7, 17, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //89
        DOVirtual.DelayedCall(89.6f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(19, -13, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //89.6
        DOVirtual.DelayedCall(90.4f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, 9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //90.4
        DOVirtual.DelayedCall(91f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-18, 9, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //91
        DOVirtual.DelayedCall(91.7f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(16, -17, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //91.7
        DOVirtual.DelayedCall(92.7f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(19, 13, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //92.7
        DOVirtual.DelayedCall(95f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, 9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //95
        DOVirtual.DelayedCall(97.4f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-18, 9, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //97.4
        DOVirtual.DelayedCall(98.2f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(16, -17, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //98.2
        DOVirtual.DelayedCall(99f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(19, 13, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //99
        DOVirtual.DelayedCall(100.8f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, 9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //100.8
        DOVirtual.DelayedCall(101.5f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-18, 9, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //101.5
        DOVirtual.DelayedCall(102.2f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(16, -17, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //102.2
        DOVirtual.DelayedCall(103f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(19, 13, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //103

        DOVirtual.DelayedCall(103.7f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, 9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //103.7
        DOVirtual.DelayedCall(104.3f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-18, 9, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //104.3

        DOVirtual.DelayedCall(106.5f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(16, -17, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //106.5
        DOVirtual.DelayedCall(107.3f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(19, 13, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //107.3

        DOVirtual.DelayedCall(109.4f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, 9, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //109.4
        DOVirtual.DelayedCall(110f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-18, 9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //110

        DOVirtual.DelayedCall(112f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(16, -17, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //112
        DOVirtual.DelayedCall(112.6f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(19, 13, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //112.6

        DOVirtual.DelayedCall(115f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, 9, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //115
        //프리렙타임

        DOVirtual.DelayedCall(126.4f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(7, -17, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //126.4
        DOVirtual.DelayedCall(127f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(7, 17, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //127

        DOVirtual.DelayedCall(129.1f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-20, 0, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //129.1
        DOVirtual.DelayedCall(129.7f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, 0, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //129.7

        DOVirtual.DelayedCall(131.9f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-19, 13, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //131.9
        DOVirtual.DelayedCall(132.3f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(15, 13, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //132.3

        DOVirtual.DelayedCall(134.7f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, 9, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //134.7
        DOVirtual.DelayedCall(135.3f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-18, 9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //135.3

        DOVirtual.DelayedCall(137.6f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, -9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //137.6
        DOVirtual.DelayedCall(138.2f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(17, 5, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //138.2

        DOVirtual.DelayedCall(140.4f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(16, -17, 1), "Rolling", 0.2f, 1.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //140.4
        DOVirtual.DelayedCall(141f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(7, 17, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //141

        DOVirtual.DelayedCall(143.2f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(19, 13, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //143.2
        DOVirtual.DelayedCall(143.7f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(19, -13, 1), "Rolling", 1.2f, 0.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //143.7

        DOVirtual.DelayedCall(146.1f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(18, 9, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //146.1
        DOVirtual.DelayedCall(146.7f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(-18, 9, 1), "Rolling", 1.2f, 0.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //146.7

        //148.9 이때 파문 퍼지는듯한 이펙트

        DOVirtual.DelayedCall(152f - 1.54f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(17, 5, 1), "Rolling", 1.2f, 0.12f, 0.2f)).SetUpdate(UpdateType.Fixed); //152

        DOVirtual.DelayedCall(154.6f - 1.52f, () => GameManager.instance.obstacle.Get(0, new Vector3(2, 2, 2), new Vector3(7, 17, 1), "Rolling", 0.2f, 1.14f, 0.2f)).SetUpdate(UpdateType.Fixed); //154.6
    }
}
