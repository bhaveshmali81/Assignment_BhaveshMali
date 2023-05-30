using UnityEngine;

namespace Project.Script
{
    public class TouchInputSystem : MonoBehaviour
    {
        private Vector2 startTouchPosition,endTouchPosition;
        private Vector3 _currentDirection,_currentRotation;
        private const float Dir = 0.2f;
        private readonly Vector3 _leftDir = new(-Dir, 0, 0);
        private readonly Vector3 _rightDir = new(Dir, 0, 0);
        private readonly Vector3 _upDir = new(0, 0, Dir);
        private readonly Vector3 _downDir = new(0, 0, -Dir);
        void Start()
        {
            _currentDirection = _leftDir;
        }
        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.LeftArrow) && _currentDirection != _leftDir && _currentDirection != _rightDir)
            {
                _currentDirection= _leftDir;
                _currentRotation = new Vector3(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow) && _currentDirection != _leftDir && _currentDirection != _rightDir)
            {
                _currentDirection = _rightDir;
                _currentRotation = new Vector3(0, 180, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow) && _currentDirection != _upDir && _currentDirection != _downDir)
            {
                _currentDirection = _upDir;
                _currentRotation = new Vector3(0, 90, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow) && _currentDirection != _upDir && _currentDirection != _downDir)
            {
                _currentDirection = _downDir;
                _currentRotation = new Vector3(0, -90, 0);
            }
#endif
        
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                startTouchPosition = Input.GetTouch(0).position;

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;

                if (endTouchPosition.x < startTouchPosition.x && _currentDirection!=_leftDir && _currentDirection!=_rightDir)
                {
                    _currentDirection= _leftDir;
                    _currentRotation = new Vector3(0, 0, 0);
                    Debug.Log("Swiped left");
                }
                else if (endTouchPosition.x > startTouchPosition.x && _currentDirection!=_leftDir && _currentDirection!=_rightDir)
                {
                    _currentDirection = _rightDir;
                    _currentRotation = new Vector3(0, 180, 0);
                    Debug.Log("Swiped right");
                }
                else if (endTouchPosition.y > startTouchPosition.y && _currentDirection!=_upDir && _currentDirection!=_downDir)
                {
                    _currentDirection = _upDir;
                    _currentRotation = new Vector3(0, 90, 0);
                    Debug.Log("Swiped up");
                }
                else if (endTouchPosition.y < startTouchPosition.y && _currentDirection!=_upDir && _currentDirection!=_downDir)
                {
                    _currentDirection = _downDir;
                    _currentRotation = new Vector3(0, -90, 0);
                    Debug.Log("Swiped down");
                }
                
            }
        }

        public Vector3 GetDirection()
        {
            return _currentDirection;
        }
        public Vector3 GetRotation()
        {
            return _currentRotation;
        }
    }
}
