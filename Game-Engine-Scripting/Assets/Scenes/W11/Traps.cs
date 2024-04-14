using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnPlayerDeath.AddListener(ResetTrap);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.PlayerDeathFromTrap();
            gameObject.SetActive(false);
        }
    }
    public void ResetTrap()
    {
        gameObject.SetActive(true);
    }
    
}
