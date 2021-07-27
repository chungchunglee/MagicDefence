using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class ButtonEvent : MonoBehaviour
    {
        private List<ButtonController> _buttonController = new List<ButtonController>();
    
        // Start is called before the first frame update
        private void Start()
        {
            GameObject magician = GameObject.Find("Magician Player");
            GameObject supporter = GameObject.Find("Supporter");
            _buttonController.Add(magician.GetComponent<ButtonController>());
            _buttonController.Add(supporter.GetComponent<ButtonController>());
        }

        // Update is called once per frame
        private void Update()
        {

        }
    
        public void LeftBtnDown()
        {
            foreach (var variable in _buttonController)
            {
                variable.leftMove = true;
            }
        }
        public void LeftBtnUp()
        {
            foreach (var variable in _buttonController)
            {
                variable.leftMove = false;
            }
        }
        public void RightBtnDown()
        {
            foreach (var variable in _buttonController)
            {
                variable.rightMove = true;
            }
        }
        public void RightBtnUp()
        {
            foreach (var variable in _buttonController)
            {
                variable.rightMove = false;
            }
        }
    }
}
