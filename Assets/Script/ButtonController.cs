using System;
using Spine.Unity;
using UnityEngine;

namespace Script
{
    public class ButtonController : MonoBehaviour
    {
        private SkeletonAnimation _skeletonAnimation;
        private SpriteRenderer _spriteRenderer;
    
        public bool leftMove;
        public bool rightMove;
        private Vector3 _moveVelocity = Vector3.zero;
        private const float MoveSpeed = 5;

        // Start is called before the first frame update
        private void Start()
        {
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (leftMove)
            {
                _moveVelocity = new Vector3(-1, 0, 0);
                transform.position += _moveVelocity * (MoveSpeed * Time.deltaTime);
                try // 방황 전환
                {
                    _skeletonAnimation.skeleton.ScaleX = -Mathf.Abs(_skeletonAnimation.skeleton.ScaleX);
                }
                catch(NullReferenceException)
                {
                    _spriteRenderer.flipX = true;
                }
            }
            else if(rightMove)
            {
                _moveVelocity = new Vector3(1, 0, 0);
                transform.position += _moveVelocity * (MoveSpeed * Time.deltaTime);
                try // 방황 전환
                {
                    _skeletonAnimation.skeleton.ScaleX = Mathf.Abs(_skeletonAnimation.skeleton.ScaleX);
                }
                catch(NullReferenceException)
                {
                    _spriteRenderer.flipX = false;
                }
            }
        }
    }
}
