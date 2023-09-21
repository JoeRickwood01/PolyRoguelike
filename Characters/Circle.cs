using UnityEngine;

public class Circle : Entity
{
    Rigidbody2D rb;

    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }

    public override void Update()
    {
        base.Update();

        HandleMovement();
    }

    void HandleMovement()
    {
        Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = moveDir * PlayerStats.Instance.speed;
    }

    public override void Die()
    {
        Level.Instance.EndGame();
    }
}
