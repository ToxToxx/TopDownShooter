using System.Collections;
using UnityEngine;

/// <summary>
/// абстрактный класс, реализующий общую логику поведения баффов
/// </summary>
public abstract class PlayerBonus : MonoBehaviour
{
    private float _playerBonusDuration = 10f; 
    private float _disappearanceTime = 5f; 
    private bool _isPickedUp = false; 

    private void Start()
    {
        StartCoroutine(CountdownToDisappear());
    }

    public abstract void ApplyEffect();
    public abstract void RemoveEffect();

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            if (!_isPickedUp)
            {
                _isPickedUp = true; 
                StopAllCoroutines(); 
                StartCoroutine(ActivatePowerUp()); 
            }
        }
    }

    IEnumerator ActivatePowerUp()
    {
        ApplyEffect();
        Debug.Log("Effect applied");
        yield return new WaitForSeconds(_playerBonusDuration);
        Debug.Log("Effect Removed");
        RemoveEffect();
    }

    IEnumerator CountdownToDisappear()
    {
        yield return new WaitForSeconds(_disappearanceTime);
        if (!_isPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
