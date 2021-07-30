using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;

namespace Script
{
    public class Monster : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        private SkeletonAnimation _skeletonAnimation;
        private const float Damage = 1;

        public Action<float> attack;

        private bool _attacking = false;

        // Start is called before the first frame update
        private void Start()
        {
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
            _skeletonAnimation.AnimationName = "walk";
        }

        // Update is called once per frame
        private void Update()
        {
            if (_attacking != false) return;
            var transform1 = transform;
            transform1.position += (-transform1.right) * (moveSpeed * Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Spawner"))
            {
                _skeletonAnimation.AnimationName = "Attack";
            }

            _attacking = true;
            
            StartCoroutine(AttackCoroutine());
        }

        private void OnCollisionStay2D(Collision2D other)
        {

        }

        private void OnCollisionExit2D(Collision2D other)
        {
            _attacking = false;
            
            _skeletonAnimation.AnimationName = "walk";
        }

        private IEnumerator AttackCoroutine()
        {
            while (true)
            {
                if (_skeletonAnimation.AnimationName == "walk")
                    yield break;
                attack?.Invoke(Damage);
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}
