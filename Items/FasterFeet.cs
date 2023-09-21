using UnityEngine;

public class FasterFeet : Item
{
    public override void Init()
    {
        id = 1;
        name = "Faster Feet";
        description = "Speed Up";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Common;
    }

    public override void Activate()
    {
        base.Activate();
        PlayerStats.Instance.speed += 0.5f;
    }

}
