using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 0;

    public bool reset = false;

    void Awake()
    {
        // If the PlayerPrefs HighScore already exists, load it
        if (PlayerPrefs.HasKey("ArgonAssaultHighScore") && !reset)
        {
            score = PlayerPrefs.GetInt("ArgonAssaultHighScore");
        }

        PlayerPrefs.SetInt("ArgonAssaultHighScore", score);
    }

    void Update()
    {
        Text gt = GetComponent<Text>();
        gt.text = "High Score: " + score;

        if (score > PlayerPrefs.GetInt("ArgonAssaultHighScore"))
        {
            PlayerPrefs.SetInt("ArgonAssaultHighScore", score);
        }
    }
}
