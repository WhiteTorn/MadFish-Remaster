using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float patrolDistance = 4f;

    private Vector3 startingPosition;
    private int direction = 1;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);
    
        if (transform.position.x > startingPosition.x + patrolDistance)
        {
            direction = -1;
            spriteRenderer.flipX = true;
        }
        else if (transform.position.x < startingPosition.x - patrolDistance)
        {
            direction = 1;
            spriteRenderer.flipX = false;
        }

    }
}
