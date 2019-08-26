using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;

    private const string timerText = "Timer: {0}";
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        time -= Time.deltaTime;
        textMesh.text = string.Format(timerText, Mathf.Floor(time));
    }
}
