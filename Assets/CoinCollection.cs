using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
{
    public Text score;
    private int scoreValue;

    private void Start()
    {
        SetScore();
        scoreValue = PlayerPrefs.GetInt("Score", 0);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
            scoreValue = PlayerPrefs.GetInt("Score");
            scoreValue += 1;
            PlayerPrefs.SetInt("Score", scoreValue);
            SetScore();
        }
    }

    void SetScore()
    {
        scoreValue = PlayerPrefs.GetInt("Score");
        score.text = "Coins: " + scoreValue;
    }
}
