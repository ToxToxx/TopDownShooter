/// <summary>
/// ����� ����������� ���� ������������
/// </summary>

public sealed class Invincibility : PlayerBonus
{

    public override void ApplyEffect()
    {
        PlayerDeathController.Instance.SwitchPlayerDieState(false);
    }
    public override void RemoveEffect()
    {
        PlayerDeathController.Instance.SwitchPlayerDieState(true);
        Destroy(gameObject);
    }
}
