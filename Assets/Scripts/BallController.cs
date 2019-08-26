using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static event Action<int> OnExplode = delegate {};

    [SerializeField] private int defaultPoints;
    [SerializeField] private float defaultSpeed;
    [SerializeField] private float minModifier;
    [SerializeField] private float maxModifier;
    [Header("GeneratedStats")]
    [SerializeField] private int generatedPoints;
    [SerializeField] private float generatedSpeed;


    private Camera mainCamera;
    private float cameraDistance;
    private Vector3 viewportBottomPosition;
    private Vector3 viewportTopPosition;
    private Renderer rend;
    private float randomModifier;

    void Start()
    {
        mainCamera = Camera.main;
        rend = GetComponent<Renderer>();
        cameraDistance = Vector3.Distance(mainCamera.transform.position, transform.position);
        
        viewportTopPosition = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1f, cameraDistance));
        
        Initialize();
    }

    void Update()
    {
        if (transform.position.y <= viewportTopPosition.y + transform.localScale.y)
        {
            transform.position += Vector3.up * Time.deltaTime * GeneratedSpeed();
        }
        else
        {
            Initialize();
        }
    }

    public void Initialize()
    {
        SetRandomColor();
        SetRandomModifier();
        SetRandomScale();
        GeneratedSpeed();
        SetRandomPoints();
        SetBottomPosition();
    }

    private void SetRandomColor()
    {
        rend.material.SetColor("_BaseColor", UnityEngine.Random.ColorHSV());
    }

    private void SetRandomModifier()
    {
        randomModifier = UnityEngine.Random.Range(minModifier, maxModifier);
    }

    private void SetRandomScale()
    {
        transform.localScale = Vector3.one * randomModifier;
    }

    private float GeneratedSpeed()
    {
        float newSpeed = defaultSpeed * (Timer.Instance.timeCounter / Timer.Instance.timeLeft) * (1 / randomModifier);
        return newSpeed;
    }

    private void SetRandomPoints()
    {
        generatedPoints = Mathf.RoundToInt(defaultPoints * (1 / randomModifier));
    }

    private void SetBottomPosition()
    {
        float horizontalViewportPosition = UnityEngine.Random.Range(0f, 1f);
        viewportBottomPosition = mainCamera.ViewportToWorldPoint(new Vector3(horizontalViewportPosition, 0f, cameraDistance));
        transform.position = viewportBottomPosition + (Vector3.down * transform.localScale.y) + (horizontalViewportPosition >= 0.5f ?  Vector3.left : Vector3.right * transform.localScale.x);
    }

    private void OnMouseDown()
    {
        OnExplode(generatedPoints);
        Initialize();
    }
}
