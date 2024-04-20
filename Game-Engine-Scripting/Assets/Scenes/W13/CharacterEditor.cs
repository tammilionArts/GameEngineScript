using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CharacterEditor
{
    public class CharacterEditor : MonoBehaviour
    {
        [SerializeField] Button nextMaterial;
        [SerializeField] Button nextBodyPart;
        [SerializeField] Button loadGame;

        [SerializeField] Character character;

        int id;
        BodyTypes bodyType = BodyTypes.Head;

        public void Awake()
        {
            //TODO: Setup some button listeners to call the NextMaterial, NextBodyPart, and LoadGame functions
            nextMaterial.onClick.AddListener(NextMaterial);
            nextBodyPart.onClick.AddListener(NextBodyPart);
            loadGame.onClick.AddListener(LoadGame);
        }

        void NextMaterial()
        {
            //TODO: Add 1 to the value of id and if it is 3 or more then reset back to 0
            id = (id + 1) % 3;

            //TODO: Make a switch case for each BodyType and save the value of id to the correct PlayerPref
            switch (bodyType)
            {
                case BodyTypes.Head:
                    PlayerPrefs.SetInt("HeadMaterial", id);
                    break;
                case BodyTypes.Body:
                    PlayerPrefs.SetInt("BodyMaterial", id);
                    break;
                case BodyTypes.Arm:
                    PlayerPrefs.SetInt("ArmMaterial", id);
                    break;
                case BodyTypes.Leg:
                    PlayerPrefs.SetInt("LegMaterial", id);
                    break;
                default:
                    break;
            }
            //TODO: Tell the character to load to get the updated body piece
            character.Load();
        }

        void NextBodyPart()
        {     
            //TODO: Setup a switch case that will go through the different body types
            //      ie if the current type is Head and we click next then set it to Body
            switch(bodyType)
            {
                case BodyTypes.Head:
                    bodyType = BodyTypes.Body;
                    break;
                case BodyTypes.Body:
                    bodyType = BodyTypes.Arm;
                    break;
                case BodyTypes.Arm:
                    bodyType = BodyTypes.Leg;
                    break;
                case BodyTypes.Leg:
                    bodyType = BodyTypes.Head;
                    break;
                default:
                    break;
            }

            //TODO: Then setup another switch case that will get the current saved value
            //      from the player prefs for the current body type and set it to id
            switch (bodyType)
            {
                case BodyTypes.Head:
                    id = PlayerPrefs.GetInt("HeadMaterial", 0);
                    break;
                case BodyTypes.Body:
                    id = PlayerPrefs.GetInt("BodyMaterial", 0);
                    break;
                case BodyTypes.Arm:
                    id = PlayerPrefs.GetInt("ArmMaterial", 0);
                    break;
                case BodyTypes.Leg:
                    id = PlayerPrefs.GetInt("LegMaterial", 0);
                    break;
                default:
                    break;
            }
            character.Load();
        }

        void LoadGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}