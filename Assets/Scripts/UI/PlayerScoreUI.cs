using TMPro;
using UnityEngine;

/// <summary>
/// Класс описывающий показ счёта игрока во время игры
/// </summary>
public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerScoreText;


    private void Update()
    {
        _playerScoreText.text = "Score: " + ScoreManager.Instance.GetScore().ToString();
    }
}
