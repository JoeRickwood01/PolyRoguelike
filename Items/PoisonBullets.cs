using UnityEngine;

public class PoisonBullets : Item
{
    public override void Init()
    {
        id = 12;
        name = "Poison Bullets";
        description = "Poison Rounds";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Rare;
    }

    public override void Activate()
    {
        base.Activate();
    }

    public override void OnBulletImpact(Vector3 pos, GameObject obj)
    {
        if(obj == null) { return; }
        if(obj.GetComponent<Entity>() == null) { return; }

        obj.GetComponent<Entity>().damageTicks.Add(new DamageTick(PlayerStats.Instance.damage / 10f, 0.5f, DamageType.Poison, 0f));
    }
}
