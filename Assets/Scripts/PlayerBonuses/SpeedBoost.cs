/// <summary>
/// класс ускорения игрока
/// </summary>

public sealed class SpeedBoost : PlayerBonus
{
    private readonly float _speedMultiplier = 1.5f;

    public override void ApplyEffect()
    {
        PlayerMovement.Instance.MultiplySpeed(_speedMultiplier);
    }

    public override void RemoveEffect()
    {
        PlayerMovement.Instance.MultiplySpeed(1/ _speedMultiplier);
        Destroy(gameObject);
    }

}
