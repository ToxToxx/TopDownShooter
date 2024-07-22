using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreenScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerScoreText;
    private const string MAX_SCORE_KEY = "MaxScore";


    private void Update()
    {
        float maxScore = PlayerPrefs.GetFloat(MAX_SCORE_KEY, 0);
        if(ScoreManager.Instance.GetScore() > maxScore)
        {
            _playerScoreText.text = "Score: " + ScoreManager.Instance.GetScore().ToString() + " NEW RECORD!!!";
        } else
        {
            _playerScoreText.text = "Score: " + ScoreManager.Instance.GetScore().ToString();
        }
    }
}
