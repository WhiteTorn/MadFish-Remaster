using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject foodPrefab;
    public int foodNumber = 29;

    public TextMeshProUGUI scoreText;

    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnAllFood();
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "SCORE: " + score;
    }

    void SpawnAllFood()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

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
