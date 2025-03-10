using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSinput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float jumpSpeed = 5.0f; // Jump strength

    private CharacterController charController;
    public const float _baseSpeed = 3f;
    private float verticalVelocity = 0f; // Track vertical movement due to gravity
    // ***(can change with 2 line above if error)public const float _baseSpeed = 3f;

    private void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value)
    {
        speed = _baseSpeed * value;
    }


    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal and vertical movement from player's  keyboard input
        float deltaX = Input.GetAxis("Horizontal") * speed /** Time.deltaTime*/;
        float deltaZ = Input.GetAxis("Vertical") * speed /** Time.deltaTime*/;

        // Create a new vector  respresenting this movement 
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        // Clamp magnitude so it move no faster than the speed
        //*** movement = Vector3.ClampMagnitude(movement, speed);

        // Apply gravity
        //*** movement.y = gravity;

        // Multiply by time.deltatime so movement is agnostic of framerate 
        //*** movement *= Time.deltaTime;

        // Transform from local coords to global coords
        //*** movement = transform.TransformDirection(movement);

        // Call the character controller's move method and pass in the movement vector
        //***charController.Move(movement);
       
        // Check if the player is on the ground  (New jump)
        if (charController.isGrounded)
        {
            verticalVelocity = 0f; // Reset vertical velocity when touching ground

            // If the player presses the jump button, apply an upward force
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpSpeed;
            }
        }
        else
        {
            // Apply gravity when in the air
            verticalVelocity += gravity * Time.deltaTime;
        }

        movement.y = verticalVelocity; // Apply vertical velocity

        movement = transform.TransformDirection(movement);

        charController.Move(movement * Time.deltaTime);
    }
}
