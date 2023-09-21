using UnityEngine;

public class Tri : Entity
{
    float timer;
    float targetAngle = 0f;
    float moveTimer;
    Rigidbody2D rb;
    Transform player;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private Transform[] bulletSpawnPoints;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float moveSpeed;

    public override void Start()
    {
        maxHealth = Mathf.RoundToInt(maxHealth * (1 + Mathf.Pow(Level.Instance.round / 10, 1.4f)));
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Update()
    {
        base.Update();

        timer -= Time.deltaTime;
        moveTimer -= Time.deltaTime;    

        if(timer <= 0f)
        {
            timer = Random.Range(2f, 3f);
            moveTimer = Random.Range(0.3f, 0.5f);
            Action();
        }

        if(moveTimer > 0f)
        {
            rb.velocity = (player.position - transform.position).normalized * moveSpeed;
        }else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime * 10f);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, targetAngle), Time.deltaTime * rotationSpeed);
    }

    private void Action()
    {
        targetAngle += Random.Range(80f, 165f);
        if(Vector2.Distance(transform.position, player.position) > 30f)
        {
            return;
        }
        for (int i = 0; i < bulletSpawnPoints.Length; i++)
        {
            GameObject cur = Instantiate(bulletPrefab, bulletSpawnPoints[i].position, Quaternion.identity, Level.Instance.bulletTransform);
            cur.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoints[i].up * bulletSpeed;
        }
    }

}
