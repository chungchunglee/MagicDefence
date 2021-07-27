using UnityEngine;

namespace Script
{
    public class ButtonEvent : MonoBehaviour
    {
        private GameObject _button;
        private ButtonController _buttonController;
    
        // Start is called before the first frame update
        private void Start()
        {
            _button = GameObject.Find("Supporter");
            _buttonController = _button.GetComponent<ButtonController>();
        }

        // Update is called once per frame
        private void Update()
        {

        }
    
        public void LeftBtnDown()
        {
            _buttonController.leftMove = true;
        }
        public void LeftBtnUp()
        {
            _buttonController.leftMove = false;
        }
        public void RightBtnDown()
        {
            _buttonController.rightMove = true;
        }
        public void RightBtnUp()
        {
            _buttonController.rightMove = false;
        }
    }
}
