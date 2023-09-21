using UnityEngine;

public class Hivemind : Item
{
    public override void Init()
    {
        id = 22;
        name = "Hivemind";
        description = "All Tears Move Towards Mouse Cursor";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Legendary;
    }

    public override void Activate()
    {
        base.Activate();
    }

    public override void OnBulletSpawn(GameObject bullet)
    {
        base.OnBulletSpawn(bullet);
        bullet.AddComponent<HomeTowardsMouseCursor>();
    }
}
