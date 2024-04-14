using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject resetPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (resetPanel != null)
        {
            resetPanel.SetActive(false);
        }
        GameManager.instance.OnPlayerDeath.AddListener(ShowResetPanel);
    }

    void ShowResetPanel()
    {
        if (resetPanel != null)
        {
            resetPanel.SetActive(true);
        }
    }
    public void ResetGame()
    {

    }
}