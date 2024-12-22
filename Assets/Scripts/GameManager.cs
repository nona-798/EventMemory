using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameState
{
    Intro,
    Playing,
    Dead
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State = GameState.Intro;
    public int Life = 3;
    public float playStartTime;
    public int highScore;

    [Header("References")]
    [Tooltip("��Ʈ�� UI")]
    public GameObject introUI;
    [Tooltip("���� UI")]
    public GameObject deadUI;
    [Tooltip("�� ���� ������Ʈ")]
    public GameObject enemySpawner;
    [Tooltip("���� ���� ������Ʈ")]
    public GameObject foodSpawner;
    [Tooltip("��� ���� ������Ʈ")]
    public GameObject goldenSpawner;

    public Player player;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        introUI.SetActive(true);
        highscoreText.text = "" + PlayerPrefs.GetInt("highScore");
    }
    float CalculateScore()
    {
        return Time.time - playStartTime;
    }
    void SaveHighScore()
    {
        int score = Mathf.FloorToInt(CalculateScore());
        int currentHighScore = PlayerPrefs.GetInt("highScore");
        if(score > currentHighScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
    }
    public float CalculateGameSpeed()
    {
        if(State != GameState.Playing)
        {
            return 5f;
        }
        float speed = 8f + (0.5f * Mathf.Floor(CalculateScore() / 10f));
        return Mathf.Min(speed, 30f);
    }
    void Update()
    {
        if(State == GameState.Playing)
        {
            scoreText.text = "" + Mathf.FloorToInt(CalculateScore());
        }
        if(State == GameState.Intro && Input.GetKeyDown(KeyCode.Space)) // ��Ʈ�� �� �����̽��� ����
        {
            State = GameState.Playing;
            introUI.SetActive(false);
            enemySpawner.SetActive(true);
            foodSpawner.SetActive(true);
            goldenSpawner.SetActive(true);
            playStartTime = Time.time;
        }
        if(State == GameState.Playing && Life <= 0) // �÷��� �� ����� ���� ����
        {
            player.KillPlayer();
            enemySpawner.SetActive(false);
            foodSpawner.SetActive(false);
            goldenSpawner.SetActive(false);
            deadUI.SetActive(true);

            SaveHighScore();
            highscoreText.text = "" + PlayerPrefs.GetInt("highScore");
            scoreText.text = "" + Mathf.FloorToInt(CalculateScore());
            State = GameState.Dead;
        }
        if(State == GameState.Dead && Input.GetKeyDown(KeyCode.Space)) // ���� ȭ�鿡�� �����̽��� ����
        {
            SceneManager.LoadScene("Main");
        }
    }
}
