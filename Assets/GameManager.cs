using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject foodPrefab;
    public GameObject enemyFishPrefab;
    public GameObject sharkPrefab;

    public int enemyNumber = 5;
    public int foodNumber = 29;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI storyText; // NEW: Story text UI
    public GameObject gameOverUI;
    public GameObject gameWonUI; // NEW: A UI panel for winning

    private int score = 0;
    public int scoreToEatEnemies = 300;
    public int scoreToDefeatShark = 2000;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverUI.SetActive(false);
        gameWonUI.SetActive(false);

        Time.timeScale = 1f;

        SpawnAllFood();
        SpawnAllEnemies();
        SpawnShark();
        UpdateScoreUI();
        UpdateStory();
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
        if (gameOverUI.activeSelf || gameWonUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
        }
    }

    public void PlayerHitShark()
    {
        if (score >= scoreToDefeatShark)
        {
            GameWon();
        }
        else
        {
            GameOver();
        }
    }

    void GameWon()
    {
        gameWonUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateStory()
    {
        if (score <= 60)
        {
            storyText.text = "A long time ago, there was peace and bliss in the Kingdom of Ungu...";
        }
        else if (score <= 200)
        {
            storyText.text = "It all started when Ungu's heir was defeated by an evil shark called Zako...";
        }
        else if (score <= 500)
        {
            storyText.text = "According to legend, the only one who can save the Kingdom will be born...";
        }
        else if (score <= 1000)
        {
            storyText.text = "In 900 AD, the heir of Ungu was born: Dex of Ungu.";
        }
        else if (score <= 2000)
        {
            storyText.text = "Dex was small, but had the spirit of a true warrior...";
        }
        else
        {
            storyText.text = "Dex grew stronger. The time has come to face Zako!";
        }
    }

    void SpawnShark()
    {
        // Spawn the shark at position (0, 0, 0)
        Instantiate(sharkPrefab, Vector3.zero, Quaternion.identity);
    }
}
