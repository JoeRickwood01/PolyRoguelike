using UnityEngine;

public class AdaptiveChambering : Item
{
    public override void Init()
    {
        id = 2;
        name = "Adaptive Chambering";
        description = "Firerate Increased, Accuracy Decreased";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Common;
    }

    public override void Activate()
    {
        base.Activate();
        PlayerStats.Instance.firerate += 1;
        PlayerStats.Instance.accuracy *= 0.98f;
    }
}
