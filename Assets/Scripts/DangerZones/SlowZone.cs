using UnityEngine;

/// <summary>
/// Класс реализующий зону замедления
/// </summary>
public class SlowZone : MonoBehaviour
{
    private readonly float _slowMultiplier = 0.6f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {

            PlayerMovement.Instance.MultiplySpeed(_slowMultiplier);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            PlayerMovement.Instance.MultiplySpeed(1/ _slowMultiplier);
        }
    }
}
