using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private float _playerScore;

    private void Awake()
    {
        Instance = this;
    }
    public void AddScore(float score)
    {
        _playerScore += score;
    }

    public float GetScore()
    {
        return _playerScore;
    }
}
