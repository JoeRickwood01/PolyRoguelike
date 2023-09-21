using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public bool isPlayerOwned;
    public bool clone;
    public float cooldown;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown > 0)
        {
            GetComponent<Collider2D>().enabled = false;
        }else
        {
            GetComponent<Collider2D>().enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D col = collision.GetContact(0).collider;
        if (isPlayerOwned)
        {
            if(!col.gameObject.transform.CompareTag("Player"))
            {
                if(col.gameObject.GetComponent<Entity>() != null) {
                    col.gameObject.GetComponent<Entity>().TakeDamage(Mathf.Clamp(damage, 1, 999999999));
                    if (!clone)
                    {
                        InventoryManager.Instance.bulletImpactEvent(transform.position, col.gameObject);
                    }
                }
            }
        }
        else
        {
            if (col.gameObject.transform.CompareTag("Player"))
            {
                col.gameObject.GetComponent<Entity>().TakeDamage(Mathf.Clamp(damage, 1, 999999999));
            }
        }
        Destroy(gameObject);
    }

}
