using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    private const int BASIC_HEALTH = 3;
    
    private static HUDManager _instance;

    public static HUDManager Instance => _instance;

    public TextMeshProUGUI scoreText;
    
    [Header("Healthbar UI controller")]
    public HealthBar healthBar;
    
    private int _score = 0;
    private int _health = 0;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);

            return;
        }

        _instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Debug.Log("Hud start");
        Reset();
    }

    private void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void Reset()
    {
        SetScore(0);
        _health = healthBar.totalHealth > 0 ? healthBar.totalHealth : BASIC_HEALTH;
        healthBar.Reset();
    }

    public void UpdateScore(int addScore)
    {
        _score += addScore;
        SetScore(_score);
    }
    
    public void ChangeHealth(int delta)
    {
        _health+=delta;
        healthBar.SetHealth(_health);
        Debug.Log("Hud change health");
        Debug.Log(_health);
        if (_health <= 0)
        {
            SceneManager.LoadScene(0);
            Reset();
        }
    }
}
