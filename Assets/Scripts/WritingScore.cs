using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WritingScore : MonoBehaviour
{
    public Text textScore;
    private float scoreValue;

    private void Start()
    {
        scoreValue = PlayerPrefs.GetInt("Score");
        textScore.text =  scoreValue.ToString();
    }


}
