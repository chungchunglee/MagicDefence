using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Script
{
    public class FixedWindow : MonoBehaviour
    {
        private void Start()
        {
            SetResolution(); // 초기에 게임 해상도 고정
        }

        /* 해상도 설정하는 함수 */
        private static void SetResolution()
        {
            const int setWidth = 3040; // 사용자 설정 너비
            const int setHeight = 1440; // 사용자 설정 높이

            var deviceWidth = Screen.width; // 기기 너비 저장
            var deviceHeight = Screen.height; // 기기 높이 저장

            Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution 함수 제대로 사용하기

            if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
            {
                var newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
                Debug.Assert(Camera.main != null, "Camera.main != null");
                Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
            }
            else // 게임의 해상도 비가 더 큰 경우
            {
                var newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
                Debug.Assert(Camera.main != null, "Camera.main != null");
                Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
            }
        }
    }
}
