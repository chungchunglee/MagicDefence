using System;
using UnityEngine;

namespace Script
{
    public class TouchMoveCam : MonoBehaviour
    {
        private const float Speed = .5f;
        private Vector2 _nowPos, _prePos;
        private Vector3 _movePos;
        private Camera _camera;

        // Start is called before the first frame update
        private void Start()
        {
            Screen.orientation = ScreenOrientation.Landscape; // 화면을 가로로 고정
            _camera = GetComponent<Camera>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.touchCount != 1) return;
            var touch = Input.GetTouch (0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _prePos = touch.position - touch.deltaPosition;
                    break;
                case TouchPhase.Moved:
                    _nowPos = touch.position - touch.deltaPosition;
                    _movePos = (Vector3)(_prePos - _nowPos) * (Time.deltaTime * Speed);
                    _movePos = new Vector3(_movePos.x, 0, 0); // x 축만 움직이게 고정
                    _camera.transform.Translate(_movePos); 
                    _prePos = touch.position - touch.deltaPosition;
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
