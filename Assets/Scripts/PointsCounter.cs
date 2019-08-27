using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsCounter : MonoBehaviour
{
    public static event Action<int> OnWin = delegate {};

    private TextMeshProUGUI textMesh;
    private int counter = 0;
    private const string pointsText = "Points: {0}";

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        BallController.OnExplode += AddPoints;
        Timer.OnTimeOver += EnableWinScreen;
    }

    private void AddPoints(int points, Vector3 position)
    {
        counter += points;
        textMesh.text = string.Format(pointsText, counter);
    }

    private void EnableWinScreen()
    {
        OnWin(counter);
    }
}
