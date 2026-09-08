using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;

public class UIManage : MonoBehaviour
{
    // reference variables
    [SerializeField] private TextMeshProUGUI playerLivesText;
    public GameObject gameOverlay;
    public GameObject winOverlay;
    public GameObject exitOverlay;

    // instance
    public static UIManage Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // subscribe to the event, listen for the health events
        PlayerHP.playerLifeLost += UpdateLives;
        PlayerHP.playerRunOutLives += DisplayGameOverlay;

    }

    private void OnDestroy()
    {
        // un-sub to event
        PlayerHP.playerLifeLost -= UpdateLives;
        PlayerHP.playerRunOutLives -= DisplayGameOverlay;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
        {
            UpdateLives();
        }
    public void UpdateLives()
    {
        // update the lives that are shown on screen based on the players current lives number
        playerLivesText.text = "Lives: " + PlayerHP.playerLives.ToString();
    }
    public void DisplayGameOverlay()
    {
        // once player runs out of lives, display different message
        playerLivesText.text = "GAME OVER" + PlayerHP.playerLives.ToString();
        gameOverlay.SetActive(true);
        
        // play audio
        gameOverlay.GetComponent<AudioSource>().Play();
    }

    public void DisplayWinOverlay()
    {
        // display win overlay
        winOverlay. SetActive(true);

        // play audio
        winOverlay.GetComponent<AudioSource>().Play();
    }

    public void DisplayExitOverlay()
    {
        exitOverlay.SetActive(true);
    }

    public void CloseExitOverlay()
    {
        exitOverlay.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
}

