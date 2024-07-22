using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����� ������ ��������, ������� � ��������� ����� �.�. ����� ������������ ����� ������ � ������� �� ����� ����
/// </summary>

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _deathScreen;

    private void OnEnable()
    {
        if (_restartButton != null)
        {
            _restartButton.onClick.AddListener(RestartGame);
        }
        else
        {
            Debug.LogError("Restart button is not assigned.");
        }
    }

    private void OnDisable()
    {
        if (_restartButton != null)
        {
            _restartButton.onClick.RemoveListener(RestartGame);
        }
    }

    private void RestartGame()
    {
        Loader.Load(Loader.Scene.GameScene);
        Time.timeScale = 1.0f;
        _deathScreen.gameObject.SetActive(false);
    }

}
