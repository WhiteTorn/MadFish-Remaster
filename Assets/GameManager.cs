using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject foodPrefab;
    public int foodNumber = 29;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnAllFood();
    }

    void SpawnAllFood()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthograpicSize;
        float widht = height * cam.aspect;

        for (int i = 0; i < foodNumber; i++)
        {
            float randomX = Random.Range(-width / 2, width / 2);
            float randomY = Random.Range(-height / 2, height / 2);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
