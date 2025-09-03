using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private bool isGameOver;
    bool restart;
    float restartTime;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Destroy other GameManager instances
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGameOver)
        {
            restart = true;
            SceneManager.LoadScene(1);
            Time.timeScale = 0;
            restartTime = Time.unscaledTime;
        }
        else if (restart && isGameOver && (Time.unscaledTime - restartTime >= 0.5f))
        {
            Time.timeScale = 1;
            restart = false;
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
