using UnityEngine;

public class Choices : Item
{
    public override void Init()
    {
        id = 20;
        name = "Choices";
        description = "Gain An Extra Item Choice After Each Round";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Rare;
    }

    public override void Activate()
    {
        base.Activate();
        PlayerStats.Instance.itemChoices++;
    }
}
