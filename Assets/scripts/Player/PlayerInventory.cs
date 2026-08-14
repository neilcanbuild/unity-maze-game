using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // static variable - Determines if key is in possession
    public static bool keyAcquired = false;

    // static variables do not reset when scenes are relaunched
    void OnDestroy()
    {
        // when scene is closed, this will be called
        keyAcquired = false;
    }
}
