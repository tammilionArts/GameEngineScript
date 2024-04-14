using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HangmanGame : MonoBehaviour
{
    public TMP_Text wordToGuessText;
    public TMP_Text lettersGuessedText;
    public Texture2D goodClothingTexture;
    public Texture2D badClothingTexture;
    public RawImage hangmanRenderer;
    public List<string> wordList;
    public string[] taunts = { "You suck!", "First time?" };
    public string[] praises = { "Cool.", "Nice, keep going!" };

    public AudioClip winnerSound;
    public AudioClip loserSound;
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public AudioSource audioSource;

    private string wordToGuess;
    private string wordDisplay;
    private string lettersGuessed;
    private int incorrectGuesses;
    private int maxIncorrectGuesses = 4;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        wordToGuess = RandomWord();

        wordDisplay = new string('_', wordToGuess.Length);
        wordToGuessText.text = wordDisplay;

        lettersGuessed = "";
        lettersGuessedText.text = "";

        hangmanRenderer.texture = null;

        incorrectGuesses = 0;
    }
    string RandomWord()
    {
        return wordList[Random.Range(0, wordList.Count)];
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GuessLetter('A');
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            GuessLetter('B');
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            GuessLetter('C');
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GuessLetter('D');
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            GuessLetter('E');
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            GuessLetter('F');
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            GuessLetter('G');
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            GuessLetter('H');
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            GuessLetter('I');
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            GuessLetter('J');
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            GuessLetter('K');
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            GuessLetter('L');
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            GuessLetter('M');
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            GuessLetter('N');
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            GuessLetter('O');
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            GuessLetter('P');
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            GuessLetter('Q');
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            GuessLetter('R');
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GuessLetter('S');
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            GuessLetter('T');
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            GuessLetter('U');
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            GuessLetter('V');
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            GuessLetter('W');
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            GuessLetter('X');
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            GuessLetter('Y');
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            GuessLetter('Z');
        }
        else
        {
            return;
        }
    }
    void GuessLetter(char letter)
    {
        if (lettersGuessed.Contains(letter.ToString()))
        {
            Debug.Log("You've already guessed" + letter);
            return;
        }
        lettersGuessed += letter;
        lettersGuessedText.text = lettersGuessed;

        bool correctGuess = false;

        if (wordToGuess.Contains(letter.ToString()))
        {
            for(int i = 0; i < wordToGuess.Length; i++) 
            {
                if (wordToGuess[i] == letter)
                {
                    wordDisplay = wordDisplay.Substring(0, i) + letter + wordDisplay.Substring(i + 1);
                    correctGuess = true;
                }
            }
            wordToGuessText.text = wordDisplay;

            if (wordDisplay.Equals(wordToGuess))
            {
                audioSource.PlayOneShot(winnerSound);
                Debug.Log("You've won!");
            }
        }
        else
        {
            audioSource.PlayOneShot(incorrectSound);
            incorrectGuesses++;
            UpdateHangmanGraphics();
            StartCoroutine(DisplayMessage(GetRandomTaunt(), 7f));
            if (incorrectGuesses >= maxIncorrectGuesses)
            {
                audioSource.PlayOneShot(loserSound);
                Debug.Log("You've lost! The word was: " + wordToGuess);
            }
        }
        if (correctGuess)
        {
            audioSource.PlayOneShot(correctSound);
            hangmanRenderer.texture = goodClothingTexture;
            StartCoroutine(DisplayMessage(GetRandomPraise(), 7f));
        }
    }
    void UpdateHangmanGraphics()
    {

        if (incorrectGuesses <= maxIncorrectGuesses)
        {
            hangmanRenderer.texture = badClothingTexture;
        }
        else
        {
            hangmanRenderer.texture = goodClothingTexture;
        }
    }
    string GetRandomTaunt()
    {
        return taunts[Random.Range(0, taunts.Length)];
    }
    string GetRandomPraise()
    {
        return praises[Random.Range(0, praises.Length)];
    }
    IEnumerator DisplayMessage(string message, float displayTime)
    {
        Debug.Log(message);
        yield return new WaitForSeconds(displayTime);
        Debug.Log("");
    }
}
