using UnityEngine;


/// <summary>
/// класс для опасных зон, которые убивают
/// </summary>
public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            PlayerDeathController.Instance.SwitchPlayerDieState(true);
            PlayerDeathController.Instance.Die();
        }
    }
}
