using UnityEngine;

public class DoorOpenSwitch : MonoBehaviour
{
    // variables
    public AudioSource doorAudio;
    public void OpenDoor()
    {
        // Opens door and plays audio
        doorAudio.Play();
        gameObject.SetActive(false);
        
    }
}