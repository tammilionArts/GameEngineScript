using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent OnMazeComplete = new UnityEvent();
    public UnityEvent OnPlayerDeath = new UnityEvent();

    public static GameManager instance;
    private Vector3 initialPlayerPosition;
    private Vector3 initialKeyPositon;
    public GameObject player;
    public GameObject key;

    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        key = GameObject.FindGameObjectWithTag("Key");
        initialPlayerPosition = player.transform.position;
        initialKeyPositon = key.transform.position;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void CompleteMaze()
    {
        OnMazeComplete.Invoke();
    }
    public void PlayerDied()
    {
        UIManager.instance.ShowYouDiedText();
        UIManager.instance.ShowResetButton();
        OnPlayerDeath.Invoke();
        isGameOver = true;
    }
    public void ResetGame()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            key.transform.position = initialKeyPositon;
            player.transform.position = initialPlayerPosition;
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if(playerMovement != null )
            {
                playerMovement.ResetPlayer();
            }
        }
        Traps[] traps = FindObjectsOfType<Traps>();
        foreach (Traps trap in traps )
        {
            trap.ResetTrap();
        }
        DoorController[] doors = FindObjectsOfType<DoorController>();
        foreach (DoorController door in doors)
        {
            door.ResetDoor();
        }
        isGameOver = false;
        UIManager.instance.HideYouDiedText();
        UIManager.instance.HideResetButton();
    }
    public void PlayerReachedDoorWithKey()
    {
        if (isGameOver && player.GetComponent<PlayerMovement>().HasKey())
        {
            CompleteMaze();
        }
    }
    public void PlayerDeathFromTrap()
    {
        if (!isGameOver)
        {
            OnPlayerDeath.Invoke();
            UIManager.instance.ShowResetPanel();
        }
    }
    public void MazeComplete()
    {
        if (!isGameOver)
        {
            OnMazeComplete.Invoke();
        }
    }
}
