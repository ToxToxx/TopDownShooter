using TMPro;
using UnityEngine;

/// <summary>
/// Класс, описывающий поведение экрана смерти игрока
/// </summary>
public class EndScreenScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerScoreText;
    private const string MAX_SCORE_KEY = "MaxScore";
    private float _curentMaxScore;

    private void OnEnable()
    {
        _curentMaxScore = PlayerPrefs.GetFloat(MAX_SCORE_KEY, 0);
    }

    private void Update()
    { 
        if(ScoreManager.Instance.GetScore() > _curentMaxScore)
        {
            _playerScoreText.text = "Score: " + ScoreManager.Instance.GetScore().ToString() + " NEW RECORD!!!";
        } else
        {
            _playerScoreText.text = "Score: " + ScoreManager.Instance.GetScore().ToString();
        }
    }
}
