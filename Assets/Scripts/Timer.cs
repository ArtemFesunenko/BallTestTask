using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static event Action OnTimeOver = delegate {};

    public static Timer Instance;

    public float timeCounter;
    public float timeLeft;

    private const string timerText = "Timer: {0}";
    private TextMeshProUGUI textMesh;
    private bool timeOver = false;

    void Start()
    {
        Instance = this;
        timeLeft = timeCounter;
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            textMesh.text = string.Format(timerText, Mathf.Floor(timeLeft));
        }
        else
        {
            if (!timeOver)
            {
                timeLeft = 0;
                timeOver = true;
                OnTimeOver();
            }
        }
    }
}
