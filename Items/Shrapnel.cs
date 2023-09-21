using UnityEngine;

public class Shrapnel : Item
{
    GameObject shrapnelPiece;

    public override void Init()
    {
        id = 9;
        name = "Shrapnel";
        description = "Its Flying Everywhere";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Rare;
    }

    public override void Activate()
    {
        base.Activate();
        shrapnelPiece = Resources.Load<GameObject>("Shrapnel");
    }

    public override void OnBulletImpact(Vector3 pos, GameObject obj)
    {
        for (int i = 0; i < Random.Range(2, 3); i++)
        {
            Vector2 velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            GameObject cur = GameObject.Instantiate(shrapnelPiece, pos, Quaternion.identity);
            InventoryManager.Instance.bulletSpawnEvent(cur);
            cur.GetComponent<Rigidbody2D>().velocity = velocity * 10f;
            cur.GetComponent<Bullet>().clone = true;
            cur.GetComponent<Bullet>().cooldown = 0.5f;
        }
    }
}
