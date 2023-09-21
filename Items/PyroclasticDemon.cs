using UnityEngine;

public class PyroclasticDemon : Item
{
    public override void Init()
    {
        id = 14;
        name = "Pyroclastic Demon";
        description = "Holy Hell";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Legendary;
    }

    public override void Activate()
    {
        base.Activate();
    }

    void Explode(Vector3 pos)
    {
        GameObject cur = GameObject.Instantiate(GameManager.Instance.GetSpawnablePrefabWithID(1), pos, Quaternion.identity);
        cur.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        GameObject.Destroy(cur, 10f);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ObjectShake>().Shake(0.2f, 0.05f, new Vector3(1f, 1f, 0f));
    }

    public override void OnBulletImpact(Vector3 pos, GameObject obj)
    {
        Explode(pos);
    }

    public override void OnEnemyKilled(Vector3 pos)
    {
        Explode(pos);
    }


}
