using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Script
{
    public class Snake : MonoBehaviour
    {
        private float _timer, waitTime = 0.05f;
        private TouchInputSystem _inputSystem;
        public GameObject snakeHead, snakeBodyPrefab;
        [SerializeField] public List<GameObject> snakeBodyPart;
        private List<Vector3> _positionHistory;
        private FoodSpawner _foodSpawner;
        private ScoreManager _scoreManager;
        private bool _isGameOver;
        public AudioSource audioSource;

        public bool IsOccupiedPos(Vector3 pos) => _positionHistory.Contains(pos);

        void Start()
        {
            _inputSystem = FindObjectOfType<TouchInputSystem>();
            _foodSpawner = FindObjectOfType<FoodSpawner>();
            _scoreManager = FindObjectOfType<ScoreManager>();

            _positionHistory = new List<Vector3>();
            foreach (var body in snakeBodyPart)
            {
                _positionHistory.Insert(0, body.transform.localPosition);
            }
        }


        void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > waitTime && !_isGameOver)
            {
                _timer = 0f;
                var snakeHeadPos = snakeHead.transform.localPosition += _inputSystem.GetDirection();
                _positionHistory.Insert(0, snakeHeadPos);
                Quaternion toRot = Quaternion.Euler(0, _inputSystem.GetRotation().y, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation,toRot,20f);
                if (_positionHistory.Count > snakeBodyPart.Count) _positionHistory.RemoveAt(snakeBodyPart.Count);

                for (int i = 0; i < snakeBodyPart.Count; i++)
                {
                    var pos = _positionHistory[i];
                    if (snakeBodyPart.Count>i+1)
                    {
                        snakeBodyPart[i + 1].transform.localPosition = pos;
                        // snakeBodyPart[i + 1].transform.rotation = Quaternion.Euler(_inputSystem.GetRotation());
                    }
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            Food food = other.GetComponent<Food>();
            if (food != null)
            {
                audioSource.Play();
                GrowSnake();
                _foodSpawner.SpawnFood();
                _scoreManager.AddScorePoint(food.foodType);
                Destroy(other.gameObject);
            }
            else
            {
                _isGameOver = true;
                _scoreManager.GameOver();
            }
        }

        void GrowSnake()
        {
            var go = Instantiate(snakeBodyPrefab, new Vector3(-30, 0, 0), Quaternion.identity,
                snakeHead.transform.parent);
            snakeBodyPart.Add(go);
        }
    }
}