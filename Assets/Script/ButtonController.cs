using Spine.Unity;
using UnityEngine;

namespace Script
{
    public class ButtonController : MonoBehaviour
    {
        private SkeletonAnimation _skeletonAnimation;
    
        public bool leftMove = false;
        public bool rightMove = false;
        private Vector3 _moveVelocity = Vector3.zero;
        private const float MoveSpeed = 5;

        // Start is called before the first frame update
        private void Start()
        {
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (leftMove)
            {
                _moveVelocity = new Vector3(-1, 0, 0);
                transform.position += _moveVelocity * (MoveSpeed * Time.deltaTime);
                _skeletonAnimation.skeleton.ScaleX = -Mathf.Abs(_skeletonAnimation.skeleton.ScaleX);
            }
            else if(rightMove)
            {
                _moveVelocity = new Vector3(1, 0, 0);
                transform.position += _moveVelocity * (MoveSpeed * Time.deltaTime);
                _skeletonAnimation.skeleton.ScaleX = Mathf.Abs(_skeletonAnimation.skeleton.ScaleX);
            }
        }
    }
}
