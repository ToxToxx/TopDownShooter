using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerScoreText;


    private void Update()
    {
        _playerScoreText.text = "Score: " + ScoreManager.Instance.GetScore().ToString();
    }
}
