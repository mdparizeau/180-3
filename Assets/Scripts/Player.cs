using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Name: Michael Parizeau
/// Date: 12/7/24
/// Description: Allows player movement and interaction
/// </summary>

public class Player : MonoBehaviour
{
    // set the player's move speed to be altered by the playtester
    public float moveSpeed = 5f;
    // variable to reference player object
    private Rigidbody rb;
    // setting the variables to check where the player is in relation 
    // to surrounding objects
    private bool is_grounded = true;
    private int jumpForce = 7;
    private bool is_touching_left = false;
    private bool is_touching_right = false;
    private bool is_touching_forward = false;
    private bool is_touching_back = false;
    // variable for if player quit, or if they won
    public static bool is_quitter = true;
    // variables for status of stick
    public GameObject stick;
    public bool attacked = false;
    // dynamic variables that track where the player has gone and how many coins they have
    public static int level = 0;
    public static int coins;

    /// <summary>
    /// initialize player object and locking of mouse as cursor
    /// </summary>
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
    // Manages the Player's collision interactions with doors
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Door>())
        {   if (other.gameObject.GetComponent<Door>().doorName != "Guess")
            {
                SceneManager.LoadScene(other.gameObject.GetComponent<Door>().sceneIndex);
                if (other.gameObject.GetComponent<Door>().doorName == "Quit")
                {
                    Cursor.lockState = CursorLockMode.None;
                    is_quitter = true;
                }
            }     
        }
    }
    /// <summary>
    /// Allows the player to jump if they are on the ground and hit the spacebar
    /// </summary>
    private void SpaceJump()
    {
        if (Input.GetKeyDown("space") && is_grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        Debug.DrawRay(transform.position, Vector3.down * 1.2f, Color.red);
    }
    private void Attack()
    {
        // swings stick forward
        if (Input.GetKeyDown("left shift") && moveSpeed > 0)
        {
            stick.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
            attacked = true;
        }
        // returns stick to upright position
        if (Input.GetKeyUp("left shift") && moveSpeed > 0)
        {
            stick.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
            attacked = false;
        }
        // returns stick to upright position if they are not moving (talking to an NPC)
        if (attacked && moveSpeed == 0)
        {
            stick.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
            attacked = false;
        }
    }
    void Update()
    {
        // input -> transform
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // make player move twice as slow when mid-air
        if (!is_grounded)
        {
            moveX *= 0.75f;
            moveZ *= 0.75f;
        }

        // if running into wall, then stop player from moving
        if ((is_touching_forward && moveZ > 0) || (is_touching_back && moveZ < 0))
            moveZ = 0;
        if ((is_touching_left && moveX < 0) || (is_touching_right && moveZ > 0))
            moveX = 0;

        // move the player
        transform.Translate(moveX, 0, moveZ);

        // allows me to get out of testing
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        // update player's level if they enter a higher level than they've been to before
        if (SceneManager.GetActiveScene().buildIndex-1 > level)
            level = SceneManager.GetActiveScene().buildIndex-1;

        // allows player to jump
        SpaceJump();
        // allows player to attack
        Attack();

        //if (SceneManager.GetActiveScene().buildIndex)
    }
    /// <summary>
    /// check if player is touching walls, and allow constant rotation of their camera
    /// </summary>
    void FixedUpdate()
    {
        IfTouchingWall();
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
    /// <summary>
    /// check if player is touching wall(s), and update bools accordingly
    /// </summary>
    private void IfTouchingWall()
    {
        // create rays in all directions
        RaycastHit hit;
        Ray left_ray = new Ray(transform.position, -transform.right);
        Ray front_ray = new Ray(transform.position, transform.forward);
        Ray back_ray = new Ray(transform.position, -transform.forward);
        Ray right_ray = new Ray(transform.position, transform.right);

        //Raycast left to find a wall
        if (Physics.Raycast(left_ray, out hit) && !hit.collider.isTrigger)
            if (hit.distance <= .6)
                is_touching_left = true;
            else is_touching_left = false;

        //Raycast forward to find a wall
        if (Physics.Raycast(front_ray, out hit) && !hit.collider.isTrigger)
            if (hit.distance <= .6)
                is_touching_forward = true;
            else is_touching_forward = false;

        //Raycast back to find a wall
        if (Physics.Raycast(back_ray, out hit) && !hit.collider.isTrigger)
            if (hit.distance <= .6)
                is_touching_back = true;
            else is_touching_back = false;

        //Raycast right to find a wall
        if (Physics.Raycast(right_ray, out hit) && !hit.collider.isTrigger)
            if (hit.distance <= .6)
                is_touching_right = true;
        else is_touching_right = false;


        //Raycast down to find the ground
        if (Physics.Raycast(transform.position, -transform.up, 1.1f))
            is_grounded = true;
        else is_grounded = false;
    }
}