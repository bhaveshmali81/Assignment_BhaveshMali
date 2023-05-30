using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project.Script
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public TextMeshProUGUI highestScore;
        public Button startButton;

        private void Awake()
        {
            highestScore.text = "Highest Score: " + PlayerPrefs.GetInt("HighScore");
            startButton.onClick.AddListener(() => SceneManager.LoadScene(1));
        }

        public static GameManager Instance 
        {
            get 
            {
                if(_instance==null) 
                    _instance = new GameManager();

                return _instance;
            }
        }

    }
}
