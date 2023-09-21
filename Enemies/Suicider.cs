using System.Threading.Tasks;
using UnityEngine;

public class Suicider : Entity
{
    Transform player;
    Rigidbody2D rb;

    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer flashRenderer;
    [SerializeField] private Color[] flashColors;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int damage;

    float delay = 1f;
    int i;

    public override void Start()
    {
        maxHealth = Mathf.RoundToInt(maxHealth * (1 + Mathf.Pow(Level.Instance.round / 2f, 1.3f)));

        base.Start();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        float distanceToPlayer = (player.position - transform.position).magnitude * 5f;
        delay = 1f / distanceToPlayer;
    }
    public override void Update()
    {
        base.Update();

        Vector3 velocity = (player.position - transform.position).normalized;
        rb.velocity = velocity * (speed * (1f + (Level.Instance.round / 100f)));

        delay -= Time.deltaTime;

        if(delay <= 0)
        {
            float distanceToPlayer = (player.position - transform.position).magnitude * 5f;
            delay = Mathf.Clamp(distanceToPlayer / 1000f, 0.1f, 1f);

            i++;
            if(i >= flashColors.Length)
            {
                i = 0;
            }

            flashRenderer.color = flashColors[i];
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Entity>() != null)
        {
            Die();
        }
    }

    bool dying;
    public override async void Die()
    { 
        if(dying == true)
        {
            return;
        }
        dying = true;
        await Task.Delay(100);
        GameObject cur = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        cur.GetComponent<Damage>().damage = damage * Mathf.RoundToInt(1 + (1 + Mathf.Pow(Level.Instance.round / 100f, 1.2f)));
        if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <= 10f)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ObjectShake>().Shake(0.5f, 0.1f, new Vector3(1f, 1f, 0f));
        }
        Destroy(gameObject);

        PlayerStats.Instance.enemiesKilled++;
    }

}
