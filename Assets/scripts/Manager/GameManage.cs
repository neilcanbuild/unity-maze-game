using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // reference var to player
    public GameObject player;

    // spawn
    public GameObject spawnPoint;

    // singleton instancing

    public static GameManager Instance;

    private void Awake()
    {
        // play again?
        Time.timeScale = 1.0f;

        // avoid having dupes
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // subscribe to the event, listen for the health events
        PlayerHP.playerLifeLost += Respawn;
        PlayerHP.playerRunOutLives += GameOver;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void OnDestroy()
    {
        // un-sub to event
        PlayerHP.playerLifeLost -= Respawn;
        PlayerHP.playerRunOutLives -= GameOver;
    }
    void Respawn()
    {
        // move player back to spawn
        player.transform.position = spawnPoint.transform.position;
    }
    void GameOver()
    {
        // disable player movement
        player.SetActive(false);
    }

    public void WinGame()
    {
        // coordinate with UI
        UIManage.Instance.DisplayWinOverlay();

        // pause the game
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        // reload game
        SceneManager.LoadScene("test");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void PauseGame()
    {
        UIManage.Instance.DisplayExitOverlay();
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        UIManage.Instance.CloseExitOverlay();
        Time.timeScale = 1f;
    }
}