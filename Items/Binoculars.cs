using UnityEngine;

public class Binoculars : Item
{

    public override void Init()
    {
        id = 15;
        name = "Binoculars";
        description = "Sight Up";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Common;
    }

    public override void Activate()
    {
        base.Activate();
        PlayerStats.Instance.sight += 1;
    }
}
