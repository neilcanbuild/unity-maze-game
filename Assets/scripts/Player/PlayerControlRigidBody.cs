using UnityEngine;

public class PlayerControlRigidBody : MonoBehaviour
{
    //references
    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource footstepAudio;

    //input control
    private float horizontalInput;
    private float verticalInput;

    //speed war
    [SerializeField] private float movementVelocity = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // grabbing reference to rigidbody & animator component
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        footstepAudio = GetComponent<AudioSource>();

        Debug.Log("Start");
    }

    // Update is called once per frame
    // FixedUpdate is used for physics every .05 sec
    void Update()
    {
        // print message
        Debug.Log("Move");
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        
        // change animation states
        if (horizontalInput != 0 || verticalInput != 0)
        {
            // moving set animator bool parameter to TRUE
            animator.SetBool("isWalking", true);

            // plays footsteps
            if (!footstepAudio.isPlaying)
            {
                footstepAudio.Play();
            }
    
            // rotate in player input direction
            float angle = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            animator.SetBool("isWalking", false);
            footstepAudio.Stop();
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * movementVelocity, verticalInput * movementVelocity);
    }
}
    
    
