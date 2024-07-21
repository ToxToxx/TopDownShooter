using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            Die();
        }
    }

    private void Die()
    {
        Time.timeScale = 0f;
    }
}
