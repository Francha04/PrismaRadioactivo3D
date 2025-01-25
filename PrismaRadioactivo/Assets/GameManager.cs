using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void GameOver() 
    {
        Time.timeScale = 0f;
        UIManager.Instance.GameLost();
    }
    public void UIActivateReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
