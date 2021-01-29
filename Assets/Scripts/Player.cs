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
    /// jump force, allowing the player to jump depending on this value.
    /// </summary>
    public float jump = 5f;

    /// <summary>
    /// Player velocity, indicates how much force is applied vertically.
    /// </summary>
    public Vector3 velocity = Vector3.zero;

    /// <summary>
    /// Game Object to used to mesure if the player if grounded or not.
    /// </summary>
    public GameObject groundCheck = null;

    /// <summary>
    /// The radius of the circle in which the ground check will be performed.
    /// </summary>
    public float groundCheckRadius = 0.4f;

    /// <summary>
    /// Layer mask of everything supposed to be ground.
    /// </summary>
    public LayerMask groundMask;

    /// <summary>
    /// Mouse sensitivity indicating how much the player can rotate himself and the camera.
    /// </summary>
    public float mouseSensitivity = 100f;

    /// <summary>
    /// Contains value of the rotation according to the "X" axis.
    /// </summary>
    public float xRotation = 0f;

    public Weapon weapon = null;

    
    public float lastFireTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            shoot();
        }

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

    /// <summary>
    /// Check if the player is grounded or not.
    /// </summary>
    /// <returns>true if the ground is detected, otherwise false.</returns>
    private bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.transform.position, groundCheckRadius, groundMask);
    }

    private void shoot()
    {
        if (Time.time > lastFireTime + weapon.fireRate)
        {
            var obj = Instantiate(weapon.bullet, weapon.tip.transform.position, Quaternion.Euler(0, 0, 90));
            var rb = obj.GetComponent<Rigidbody>();

            weapon.destroyBullet(obj, 4f);
            
            if (rb != null)
            {
                rb.AddForce(cam.transform.forward * weapon.bulletForce);
            }

            lastFireTime = Time.time;
        }
        
    }

}