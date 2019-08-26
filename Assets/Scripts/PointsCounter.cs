using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsCounter : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private int counter = 0;
    private const string pointsText = "Points: {0}";

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        BallController.OnExplode += AddPoints;
    }

    private void AddPoints(int points)
    {
        counter += points;
        textMesh.text = string.Format(pointsText, counter);
    }
}
