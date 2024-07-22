using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    public static PlayerDeathController Instance;
    private bool _isPlayerCanDie;

    private void Awake()
    {
        Instance = this; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            Die();
        }
    }

    private void Die()
    {
        if (_isPlayerCanDie)
        {
            Time.timeScale = 0f;
        }
    }

    public void SwitchPlayerDieState(bool state)
    {
        _isPlayerCanDie = state;
    }
    
}
