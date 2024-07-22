using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PlayerBonus
{
    public override void ApplyEffect()
    {
        PlayerDeathController.Instance.SwitchPlayerDieState(false);
    }
    public override void RemoveEffect()
    {
        PlayerDeathController.Instance.SwitchPlayerDieState(true);
    }
}
