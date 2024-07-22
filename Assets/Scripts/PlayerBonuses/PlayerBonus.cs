using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBonus : MonoBehaviour
{
    private float _playerBonusDuration = 10f;
    public abstract void ApplyEffect();
    public abstract void RemoveEffect( );
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            StartCoroutine(ActivatePowerUp());
        }
    }

    IEnumerator ActivatePowerUp()
    {
        ApplyEffect();
        yield return new WaitForSeconds(_playerBonusDuration);
        RemoveEffect();
        Destroy(gameObject);
    }
}
