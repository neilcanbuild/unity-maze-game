using System;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    // remaining lives
    public static int playerLives = 3;

    // events
    public static event Action playerLifeLost;
    public static event Action playerRunOutLives;

    private void Awake()
    {
        // lives are static, therefore set it back to default on Awake
        playerLives = 3;
    }
    public static void LoseLife()
    {
        // reduce lives by 1 
        playerLives--;

        // signal life is lost
        if (playerLives > 0)
        {
            // player round continues
            playerLifeLost?.Invoke();
        }
        else
        {
            // game over!
            playerRunOutLives?.Invoke();
        }
    }
}

