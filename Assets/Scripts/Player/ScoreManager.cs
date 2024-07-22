using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private float _playerScore;
    private float _maxScore;

    private const string MAX_SCORE_KEY = "MaxScore";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadMaxScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(float score)
    {
        _playerScore += score;

        if (_playerScore > _maxScore)
        {
            _maxScore = _playerScore;
            SaveMaxScore(); 
        }
    }

    public float GetScore()
    {
        return _playerScore;
    }

    public float GetMaxScore()
    {
        return _maxScore;
    }

    private void SaveMaxScore()
    {
        PlayerPrefs.SetFloat(MAX_SCORE_KEY, _maxScore);
        PlayerPrefs.Save();
    }

    private void LoadMaxScore()
    {
        _maxScore = PlayerPrefs.GetFloat(MAX_SCORE_KEY, 0);
    }
}
