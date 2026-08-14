using UnityEngine;

public class Chest : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public string playerTag = "Player";
    private bool playerInRange = false;
    private bool isOpened = false;

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

        // tell game manager you win
        GameManager.Instance.WinGame();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            playerInRange = false;
        }
    }
}
