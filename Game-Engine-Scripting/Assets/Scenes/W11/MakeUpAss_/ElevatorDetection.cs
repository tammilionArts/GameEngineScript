using UnityEngine;

//TODO: This script should be attached to the camera since we are going off of wherever the camera is looking at

public class ElevatorDetection : MonoBehaviour
{
    //Button we are currently looking at
    private ElevatorButton button;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(button != null)
            {
                button.Press();
            }
        }
        else
        {
            FindButton();
        }
    }

    void FindButton()
    {
        //TODO: Use Physics.Raycast to detect if the direction we are looking at is intersecting a ElevatorButton
        //      You will need to make a new Layer similar to we've done in the past and create a layerMask similar to how we
        //      did for ground detection. 
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        int layerMask = 1 << LayerMask.NameToLayer("ElevatorButton");
        //      If raycast successfully intersects a button then use GetComponent on the transform of the hit object to get the ElevatorButton
        //      Class and assign the value into button.
        //      Then call the Select function
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            ElevatorButton newButton = hit.transform.GetComponent<ElevatorButton>();
            if (newButton != null)
            {
                newButton.Select();
                Debug.Log("Button detected: " + newButton.name);
            }
            if (button != null && button != newButton)
            {
                button.UnSelect();
            }
            button = newButton;
        }
        //      
        //      If there is no successful intersection from the Raycast then check if button is not null and if that is the case then
        //      call UnSelect on the button and then set the button to null afterwards to clear it out.
        else
        {
            if (button != null)
            {
                button.UnSelect();
                button = null;
            }
        }
    }
    public ElevatorButton GetButton()
    {
        return button;
    }
}

