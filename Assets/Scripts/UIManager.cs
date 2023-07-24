using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager Instance;

    public TextMeshProUGUI scoreText;
    public int score;
    public TextMeshProUGUI highScoreText;
    public int highScore;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI waveText;
    public int wave;

    public Image[] lifeSprites;
    public Image healthBar;
    public Sprite[] healthBars;

    private Color32 active = new Color(1, 1, 1, 1);
    private Color32 inactive = new Color(1, 1, 1, 0.25f);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void UpdateLives(int 1) 
    { 
    
    }

    public static void UpdateHealthBar (int h) 
    { 
    
    }

    public static void UpdateScore() 
    { 
    
    }

    public static void UpdateHighScore() 
    { 
    
    }

    public static void UpdateWave()
    {

    }

    public static void UpdateCoins()
    {

    }

}
