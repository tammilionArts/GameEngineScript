using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private ElevatorDetection elevatorDectection;
    private CharacterController characterController;
    [SerializeField]
    float speed = 5.0f;
    [SerializeField]
    float rotation = 5.0f;

    private float lastMouseX = 0f;
    private float mouseDeltaX = 0f;
    private int rotDir = 0;

    // Start is called before the first frame update
    void Start()
    {
        elevatorDectection = GetComponent<ElevatorDetection>();
        characterController = GetComponent<CharacterController>();
    }
    //TODO: This function should be called from your player script
    //      You will need to create a reference to ElevatorDetection in your player script and assign it as a reference
    public ElevatorButton GetButton()
    {
        return elevatorDectection.GetButton();
    }

     void Update()
    {
        HandleMovement();
        HandleRotation();
        if (Input.GetKeyDown(KeyCode.F))
        {
            PressElevatorButton();
        }
    }

    void HandleMovement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * HorizontalInput + transform.forward * VerticalInput;
        characterController.Move(moveDirection * speed * Time.deltaTime);

    }

    void HandleRotation()
    {
        mouseDeltaX = Input.mousePosition.x - lastMouseX;

        if (mouseDeltaX != 0)
        {
            rotDir = mouseDeltaX > 0 ? 1 : -1;
            lastMouseX = Input.mousePosition.x;

            transform.Rotate(Vector3.up, rotation * Time.deltaTime * rotDir);
        }
    }
    void PressElevatorButton()
    {
        
            ElevatorButton currentButton = GetButton();
            if(currentButton != null)
            {
                currentButton.Press();
                
            }
        

    }
}
