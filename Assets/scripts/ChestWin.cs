using UnityEngine;

public class Chest : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public string playerTag = "Player";
    public GameObject PressE;
    private bool playerInRange = false;
    private bool isOpened = false;

    void Start()
    {
        // Hides the open chest prompt when game starts
        PressE.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && !isOpened && Input.GetKeyDown(interactKey))
        {
            OpenChest();
            
        }
    }
    private void OpenChest()
    {
        isOpened = true;

        // Hides the open chest prompt when game ends
        PressE.SetActive(false);

        // tell game manager you win
        GameManager.Instance.WinGame();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            playerInRange = true;
            PressE.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            playerInRange = false;
            PressE.SetActive(false);
        }
    }
}
