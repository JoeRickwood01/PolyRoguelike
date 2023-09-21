using UnityEngine;

public class Bloodlust : Item
{
    public override void Init()
    {
        id = 17;
        name = "Bloodlust";
        description = "Chance To Increase Max Health On Kill";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Epic;
    }

    public override void Activate()
    {
        base.Activate();
    }

    public override void OnEnemyKilled(Vector3 pos)
    {
        System.Random rand = new System.Random();

        if(rand.Next(0, 100) > 90)
        {
            PlayerStats.Instance.maxHealth += 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().maxHealth += 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().currentHealth += 1;
        }
    }
}
