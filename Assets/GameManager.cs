using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject foodPrefab;
    public GameObject enemyFishPrefab;
    public int enemyNumber = 5;
    public int foodNumber = 29;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverUI;

    private int score = 0;
    public int scoreToEatEnemies = 300;

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
        gameOverUI.SetActive(false);

        Time.timeScale = 1f;

        SpawnAllFood();
        SpawnAllEnemies();
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void PlayerHitEnemy(GameObject enemy)
    {
        if (score >= scoreToEatEnemies)
        {
            AddScore(350);
            Destroy(enemy);
        }
        else
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
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

    void SpawnAllEnemies()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        for (int i = 0; i < enemyNumber; i++)
        {
            float randomX = Random.Range(-width / 2, width / 2);
            float randomY = Random.Range(-height / 2, height / 2);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            Instantiate(enemyFishPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
