using UnityEngine;

public class RedSwitch : MonoBehaviour
{
    // call vars
    public DoorOpenSwitch door2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // crate hits switch
        if (collision.CompareTag("Movable"))
        {
            // switch activates and opens door
            door2.OpenDoor();
        }
            
    }
}
