using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI popupTextPrefab;

    private Camera mainCamera;
    private const string plusText = "+{0}";

    void Start()
    {
        mainCamera = Camera.main;
        BallController.OnExplode += InstancePopupText;
    }

    private void InstancePopupText(int points, Vector3 position)
    {
        var popupTextGO = Instantiate(popupTextPrefab, transform);
        popupTextGO.GetComponent<TextMeshProUGUI>().text = string.Format(plusText, points);
        popupTextGO.transform.position = mainCamera.WorldToScreenPoint(position);
        Destroy(popupTextGO, 0.2f);
    }
}
