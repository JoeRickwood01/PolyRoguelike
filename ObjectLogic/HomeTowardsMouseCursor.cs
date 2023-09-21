using UnityEngine;

public class HomeTowardsMouseCursor : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 target = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized * 10f;
        rb.velocity = Vector2.Lerp(rb.velocity, target, Time.deltaTime * 5f);
    }
}
