using UnityEngine;

public class Player : MonoBehaviour
{

    public const float GRAVITY = - 18.6f;  

    /// <summary>
    /// Character controller component.
    /// </summary>
    public CharacterController controller = null;

    /// <summary>
    /// Player camera, Allowing to display the game.
    /// </summary>
    public GameObject cam = null;

    
    /// <summary>
    /// Player speed, allowing the player to run faster or slower.
    /// </summary>
    public float speed = 5f;

    /// <summary>
    /// Rotation speed, allowing the player to rotate faster or slower.
    /// </summary>
    public float rotation = 0f;

    /// <summary>
    /// jump force, allowing the player to jump depending on this value.
    /// </summary>
    public float jump = 5f;

    public Vector3 velocity = Vector3.zero;

    /// <summary>
    /// Game Object to used to mesure if the player if grounded or not.
    /// </summary>
    public GameObject groundCheck = null;

    public float groundCheckRadius = 0.4f;

    public LayerMask groundMask;

    public float mouseSensitivity = 100f;

    public float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
       
        gameObject.transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (isGrounded())
        {
            velocity.y = -3f;
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            velocity.y = Mathf.Sqrt(jump * -2 * GRAVITY);
        }

        velocity.y += GRAVITY * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.transform.position, groundCheckRadius, groundMask);
    }

}