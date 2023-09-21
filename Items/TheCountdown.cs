using UnityEngine;

public class TheCountdown : Item
{
    GameObject shrapnelPiece;

    int count;

    public override void Init()
    {
        id = 16;
        name = "The Countdown";
        description = "Every 5 Bullets, Shoot A Goliath Round Which Deals 2x Damage";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Uncommon;
    }

    public override void Activate()
    {
        base.Activate();
    }

    public override void OnBulletSpawn(GameObject bullet)
    {
        count++;
        if(count >= 5)
        {
            bullet.transform.localScale *= 1.5f;
            bullet.GetComponent<Bullet>().damage *= 2;
            count = 0;
        }
    }
}
