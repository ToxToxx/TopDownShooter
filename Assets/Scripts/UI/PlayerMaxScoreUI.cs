using TMPro;
using UnityEngine;

/// <summary>
/// Класс описывающий поведение текста, отображающего лучший результат игрока
/// </summary>
public class PlayerMaxScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _maxScoreText;
    private const string MAX_SCORE_KEY = "MaxScore"; 

    private void Start()
    {
        UpdateMaxScoreText(); 
    }

    private void Update()
    {

        UpdateMaxScoreText();
    }

    private void UpdateMaxScoreText()
    {
        float maxScore = PlayerPrefs.GetFloat(MAX_SCORE_KEY, 0); 
        _maxScoreText.text = "Max score: " + maxScore.ToString(); 
    }
}
