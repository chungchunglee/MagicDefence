using System;
using UnityEngine;

namespace Script
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        public float _hp = 5f;

        // Start is called before the first frame update
        private void Start()
        {
            
        }

        // Update is called once per frame
        private void Update()
        {
            var transform1 = transform;
            transform1.position += transform1.right * (moveSpeed * Time.deltaTime);
        }

        public void OnDamaged(float damage)
        {
            _hp -= damage;
            if (_hp == 0)
                OnDestroy();
        }

        private void OnDestroy()
        {
            Destroy(gameObject);
        }
    }
}
