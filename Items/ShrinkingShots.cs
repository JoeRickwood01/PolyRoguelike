using UnityEngine;

public class ShrinkingShots : Item
{
    public override void Init()
    {
        id = 24;
        name = "Shrinking Shots";
        description = "2x Damage \n Bullets Decrease In Size And Damage As They Travel";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Rare;
    }

    public override void Activate()
    {
        base.Activate();
    }

    public override void OnBulletSpawn(GameObject bullet)
    {
        base.OnBulletSpawn(bullet);
        bullet.AddComponent<ShrinkingBullet>();
    }
}
