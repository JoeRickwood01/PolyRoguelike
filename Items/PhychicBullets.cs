using UnityEngine;

public class PhychicBullets : Item
{
    public override void Init()
    {
        id = 10;
        name = "Psychic Bullets";
        description = "They Have A Mind Of Their Own!";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Epic;
    }

    public override void Activate()
    {
        base.Activate();
    }

    public override void OnBulletSpawn(GameObject cur)
    {
        cur.AddComponent<Homing>();
    }
}
