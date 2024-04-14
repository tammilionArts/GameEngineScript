using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 initialPlayerPosition;
    private Rigidbody playerRigidbody;
    public float playerMovingSpeed = 10f;
    public float strafeSpeed = 5f;
    private float moving;
    private float strafe;
    public GameObject cam;
    private float xRot = 0.0f;
    private float yRot = 0.0f;
    public float horizontalSensitivity = 2.0f;
    public float verticalSensitivity = 2.0f;
    public float rotationLimit;
    private float runSpeed = 1;
    public float runMultiplier = 2;

    private int playerScore = 0;
    private bool hasKey = false;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        initialPlayerPosition = transform.position;
    }

    void Update()
    {
        yRot = Input.GetAxis("Mouse X") * horizontalSensitivity;
        xRot += Input.GetAxis("Mouse Y") * verticalSensitivity;

        xRot = Mathf.Clamp(xRot, -rotationLimit, rotationLimit);

        cam.transform.localEulerAngles = new Vector3(-xRot, 0, 0);

        transform.Rotate(0, yRot, 0);

        runSpeed = 1.0f;
        if (Input.GetKey(KeyCode.LeftShift))
            runSpeed = runMultiplier;
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        Vector3 movement = moveDirection.normalized * playerMovingSpeed *runSpeed;
        playerRigidbody.velocity = movement;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            playerScore += 10;
            UIManager.instance.UpdateScore(playerScore);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Goal"))
        {
            GameManager.instance.CompleteMaze();
        }
        else if (other.CompareTag("Trap"))
        {
            GameManager.instance.PlayerDied();
            UIManager.instance.ShowResetPanel();
        }
    }
    public void ResetPlayer()
    {
        transform.position = initialPlayerPosition;
        playerScore = 0;
        hasKey = false;
    }
    public bool HasKey()
    {
        return hasKey;
    }
}
