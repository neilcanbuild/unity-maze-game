using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // movement speed
    public float movementSpeed = 2.2f;

    // inputs
    public bool wKey = false;
    public bool aKey = false;
    public bool sKey = false;
    public bool dKey = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        wKey = (Input.GetKey(KeyCode.W));
        aKey = (Input.GetKey(KeyCode.A));
        sKey = (Input.GetKey(KeyCode.S));
        dKey = (Input.GetKey(KeyCode.D));

        // call move
        Move();
    }
    void Move()
    {
        if (wKey)
            transform.position = new Vector3(transform.position.x, transform.position.y + movementSpeed * Time.deltaTime, transform.position.z);

        if (aKey)
            transform.position = new Vector3(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        if (sKey)      
            transform.position = new Vector3(transform.position.x, transform.position.y - movementSpeed * Time.deltaTime, transform.position.z);      

        if (dKey)
            transform.position = new Vector3(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        

       }
    }
