using UnityEngine;

public class Minigun : Item
{
    public override void Init()
    {
        id = 5;
        name = "Minigun";
        description = "Massive Scaled Firerate Up, Damage Down, Accuracy Down, Small Bullets";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Epic;
    }

    public override void Activate()
    {
        base.Activate();
        PlayerStats.Instance.damage *= 0.25f;
        PlayerStats.Instance.firerate *= Mathf.Clamp(6f - (PlayerStats.Instance.firerate / 2f), 1.2f, 6f);
        PlayerStats.Instance.accuracy *= 0.4f;
        PlayerStats.Instance.bulletSize = 0.075f;
    }
}
