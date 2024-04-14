using UnityEngine;
using UnityEngine.UI;

//Script on Drag and drop will create box collider component automatically
[RequireComponent(typeof(BoxCollider))]
public class KeyController : MonoBehaviour
{
    BoxCollider keyCollider;
    Rigidbody keyRB;
    public DoorController DC;

    /// <summary>
    /// Incase user forgets to uncheck isTrigger in box collider
    /// This sets them automatically
    /// </summary>
    private void Start()
    {
        keyCollider = GetComponent<BoxCollider>();

        keyCollider.isTrigger = true;

        GameManager.instance.OnPlayerDeath.AddListener(ResetKey);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DC.gotKey = true;
            this.gameObject.SetActive(false);
        }
    }
    private void ResetKey()
    {
        this.gameObject.SetActive(true);
    }
}
