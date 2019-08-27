using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    
    private Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
        PointsCounter.OnWin += SetWinText;
    }

    private void SetWinText(int totalPoints)
    {
        Invoke("ReloadScene", 3f);
        textMesh.text = string.Format("YOUR SCORE: {0}", totalPoints);
        anim.Play();
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
