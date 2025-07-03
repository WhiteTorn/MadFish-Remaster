using UnityEngine;

public class SharkAI : MonoBehaviour
{
    public float moveSpeed = 1f;

    private Transform playerTransform;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null)
        {
            return;
        }

        Vector2 direction = (playerTransform.position - transform.position).normalized;
    
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
