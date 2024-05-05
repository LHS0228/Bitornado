using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimePoint : MonoBehaviour
{
    [SerializeField]
    private float point;
    private TextMeshProUGUI pointText;

    private void Awake()
    {
        pointText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        point += Time.deltaTime;

        pointText.text = $"{(int)point}";
    }
}
