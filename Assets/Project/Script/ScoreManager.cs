using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Project.Script
{
    public class ScoreManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText, streakText, currentScoreText, highestScoreText;
        public GameObject panel;
        public Button restartButton;
        private int _streak = 1, _score = 0;
        private FoodCategory _lastFoodConsumeType = FoodCategory.None;

        void Start()
        {
            panel.SetActive(false);
            restartButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        }

        public void AddScorePoint(FoodCategory foodType)
        {
            _streak = _lastFoodConsumeType == foodType ? _streak + 1 : 1;
            _score += Convert.ToInt32(foodType) * _streak;
            scoreText.text = "Score: " + _score;
            streakText.text = "Streak: " + _streak;
            _lastFoodConsumeType = foodType;

            if (_score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", _score);
            }
        }

        public void GameOver()
        {
            currentScoreText.text = "Your Current Score: " + _score;
            highestScoreText.text = "Highest Score: " + PlayerPrefs.GetInt("HighScore");
            panel.SetActive(true);
        }
    }
}