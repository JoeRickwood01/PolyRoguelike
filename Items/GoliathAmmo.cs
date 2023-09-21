using UnityEngine;

public class GoliathAmmo : Item
{
    public override void Init()
    {
        id = 8;
        name = "Goliath Ammo";
        description = "Damage Up, Bullet Size Up";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Uncommon;
    }

    public override void Activate()
    {
        base.Activate();
        PlayerStats.Instance.damage += 4f;

        PlayerStats.Instance.bulletSize *= Mathf.Clamp(3 - PlayerStats.Instance.bulletSize * 3, 1f, 3f);
            
    }
}
