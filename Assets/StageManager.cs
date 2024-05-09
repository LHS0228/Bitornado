using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StageManager : MonoBehaviour
{
    public Stage_2 stage2;

    // Start is called before the first frame update

    void Start()
    {
        stage2 = GetComponent<Stage_2>();
        DOVirtual.DelayedCall(3, () => stage2.Stage02_Start()).SetUpdate(UpdateType.Fixed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
