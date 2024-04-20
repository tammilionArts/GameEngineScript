using UnityEngine;
//TODO: Make sure your project has Dotween installed from the asset store
using DG.Tweening;

public class Elevator : MonoBehaviour
{
    [SerializeField] public Elevator elevator;
    [SerializeField] public int floor;
    public void GoToFloor(int floor)
    {
        Debug.Log("Moving elevator to floor" + floor);
        //TODO: Write a single line of code that moves the transform along the Y axis using transform.DOMoveY
        //      and the value should be something that is a function of the floor number
        float targetY = floor * 10f;
        transform.DOMoveY(targetY, 15f);
    }
    public void Press()
    {
        //TODO: Call GoToFloor and pass in the floor
        elevator.GoToFloor(floor);
        Debug.Log("Button pressed: " + floor);
    }
}
