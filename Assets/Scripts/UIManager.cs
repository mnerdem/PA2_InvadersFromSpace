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

    public static void UpdateLives(int l) 
    {
        foreach (Image i in Instance.lifeSprites)
        {
            i.color = Instance.inactive;
        }
        for (int i = 0; i < l; i++)
        {
            Instance.lifeSprites[i].color = Instance.active;
        }
    }

    public static void UpdateHealthBar (int h) 
    {
        Instance.healthBar.sprite = Instance.healthBars[h];
    }

    public static void UpdateScore(int s) 
    {
        Instance.score += s;
        Instance.scoreText.text = Instance.score.ToString("000,000");
    }

    public static void UpdateHighScore() 
    { 
        // sonra tekrar
    }

    public static void UpdateWave()
    {
        Instance.wave++;
        Instance.waveText.text = Instance.wave.ToString();
    }

    public static void UpdateCoins()
    {
        // sonra tekrar
    }

}
