using UnityEngine;

//TODO: This script should be attached to each button on your elevator

public class ElevatorButton : MonoBehaviour
{
    //TODO: You need to assign the reference to the elevator in the inspector of this button
    [SerializeField] private Elevator elevator;
    [SerializeField] private int floor;

    //TODO: You will need to create a couple of materials to represent selected and not selected states
    [SerializeField] private Material defaultMat;
    [SerializeField] private Material selectedMat;

    private MeshRenderer meshRenderer;

     void Awake()
    {
        //TODO: Use GetComponent to get the MeshRenderer attached to this button and assign it to meshRenderer
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public int Floor
    {
        get { return floor; }
    }

    public void Press()
    {
        //TODO: Call GoToFloor and pass in the floor
        elevator.GoToFloor(floor);
        Debug.Log("Button pressed: " + gameObject.name);
    }

    public void Select()
    {
        Debug.Log("Button selected");
        //TODO: Change the material of the meshRenderer to selectedMat
        meshRenderer.material = selectedMat;
    }

    public void UnSelect()
    {
        Debug.Log("Button unselected");
        //TODO: Change the material of the meshRenderer to the defaultMat
        meshRenderer.material = defaultMat;
    }
}
