using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Save : MonoBehaviour
{
    public static Save instance;
    public int coins;
    public int skinNum = 0;
    public int score;
    public TMP_Text coinsText;
    public TMP_Text scoreText;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        coins = PlayerPrefs.GetInt("Coins", coins);
        skinNum = PlayerPrefs.GetInt("SkinNum", skinNum);
        score = PlayerPrefs.GetInt("Score", score);
        coinsText.text = coins.ToString();
        scoreText.text = "lvl : " + score.ToString();
    }

}
