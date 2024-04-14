using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text scoreText;
    public GameObject youDiedText;
    public GameObject resetButton;
    public GameObject resetPanel;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdateScore(int score)
    {
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
    public void ShowResetPanel()
    {
        if (resetPanel != null)
        {
            resetPanel.SetActive(true);
        }
    }
    public void ShowYouDiedText()
    {
        youDiedText.SetActive(true);
    }
    public void HideYouDiedText()
    {
        youDiedText.SetActive(false);
    }
    public void ShowResetButton()
    {
        resetButton.SetActive(true);
    }
    public void HideResetButton()
    {
        resetButton.SetActive(false);
    }
   
}
