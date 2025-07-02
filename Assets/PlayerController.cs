using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
    
        float moveY = Input.GetAxisRaw("Vertical");

        // Rigidbody movement
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        rb.linearVelocity = moveDirection * moveSpeed;

        // make decisions
        if (moveX > 0)
        {
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
        }
        else if (moveY > 0)
        {
            spriteRenderer.flipX = true;
            spriteRenderer.flipY = false;
        }
        else if (moveY < 0)
        {
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = true;
        }
        else if (moveX < 0)
        {
            spriteRenderer.flipX = true;
            spriteRenderer.flipY = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            GameManager.instance.AddScore(25);

            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.PlayerHitEnemy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Shark"))
        {
            GameManager.instance.PlayerHitShark();
        }
    }
}
