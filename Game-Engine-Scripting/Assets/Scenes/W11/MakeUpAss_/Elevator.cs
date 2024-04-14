using UnityEngine;
//TODO: Make sure your project has Dotween installed from the asset store
using DG.Tweening;

public class Elevator : MonoBehaviour
{
    public void GoToFloor(int floor)
    {
        Debug.Log("Moving elevator to floor" 
            + floor);
        //TODO: Write a single line of code that moves the transform along the Y axis using transform.DOMoveY
        //      and the value should be something that is a function of the floor number
        float targetY = floor * 10;
        transform.DOMoveY(targetY, 25);
    }
}
