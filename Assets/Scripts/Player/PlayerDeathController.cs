using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    public static PlayerDeathController Instance;
    private bool _isPlayerCanDie = true;
    [SerializeField] private GameObject _deathScreen;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            Destroy(other.gameObject);
            Die();
        }
    }

    public void Die()
    {
        if (_isPlayerCanDie)
        {
            Time.timeScale = 0f;
            _deathScreen.SetActive(true);
        }
    }

    public void SwitchPlayerDieState(bool state)
    {
        _isPlayerCanDie = state;
    }
    
}
