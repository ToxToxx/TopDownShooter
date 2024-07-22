using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    private readonly float _slowMultiplier = 0.6f;
    private float _currentMoveSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _currentMoveSpeed = PlayerMovement.Instance.GetMoveSpeed();
            _currentMoveSpeed *= _slowMultiplier;
            PlayerMovement.Instance.ChangeMoveSpeed(_currentMoveSpeed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _currentMoveSpeed = PlayerMovement.Instance.GetMoveSpeed();
            _currentMoveSpeed /= _slowMultiplier;
            PlayerMovement.Instance.ChangeMoveSpeed(_currentMoveSpeed);
        }
    }
}
