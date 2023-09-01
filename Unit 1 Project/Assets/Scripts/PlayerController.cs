using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // Public variables for customization in the Unity Editor
    public float moveSpeed = 5f;     // Horizontal movement speed
    public float jumpForce = 4f;    // Force applied when jumping
    public float gravity = -9.81f;  // Strength of gravity

    private CharacterController controller;  // The character controller component
    private Vector3 velocity;               // Current velocity of the character

    public AudioSource jumpAudioSource;

    // Awake is called when the script instance is initialized
    private void Awake()
    {
        // Get the CharacterController component attached to this GameObject
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Horizontal movement
        var moveInput = Input.GetAxis("Horizontal");
        var moveDirection = transform.right * (moveInput * moveSpeed);

        // Apply gravity
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0;
        }

        // Jumping
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            jumpAudioSource.Play();
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }

        // Apply movement and gravity
        var move = moveDirection + velocity;
        controller.Move(move * Time.deltaTime);
    }
}