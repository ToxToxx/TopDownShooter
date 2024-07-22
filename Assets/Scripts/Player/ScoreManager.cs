using UnityEngine;

/// <summary>
///  ласс реализующий и управл€ющий очками игрока, сохран€ет и загружает их
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private float _playerScore = 0;
    private float _maxScore;

    private const string MAX_SCORE_KEY = "MaxScore";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        LoadMaxScore();
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
