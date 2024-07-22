using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : PlayerBonus
{
    private float _speedMultiplier = 1.5f;
    private float _currentMoveSpeed;

    public override void ApplyEffect()
    {
        _currentMoveSpeed = PlayerMovement.Instance.GetMoveSpeed();
        _currentMoveSpeed *= _speedMultiplier;
        PlayerMovement.Instance.ChangeMoveSpeed(_currentMoveSpeed);
    }

    public override void RemoveEffect()
    {
        _currentMoveSpeed = PlayerMovement.Instance.GetMoveSpeed();
        _currentMoveSpeed /= _speedMultiplier;
        PlayerMovement.Instance.ChangeMoveSpeed(_currentMoveSpeed);
    }

}
