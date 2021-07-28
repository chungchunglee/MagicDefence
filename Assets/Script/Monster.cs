using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;

namespace Script
{
    public class Monster : MonoBehaviour
    {
        private SkeletonAnimation _skeletonAnimation;
        private float _damage = 1;

        public Action<float> Attack;
        
        // Start is called before the first frame update
        private void Start()
        {
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
        }

        // Update is called once per frame
        private void Update()
        {
        
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.transform.CompareTag("Spawner"))
            {
                _skeletonAnimation.AnimationName = "Attack";
            }

            StartCoroutine(AttackCoroutine());
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            _skeletonAnimation.AnimationName = "Idle";
        }

        private IEnumerator AttackCoroutine()
        {
            if (_skeletonAnimation.AnimationName == "Idle")
                yield break;
            yield return new WaitForSeconds(1.0f);
            Attack?.Invoke(_damage);
        }
    }
}
