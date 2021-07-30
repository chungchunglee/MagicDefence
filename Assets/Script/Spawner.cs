using System;
using UnityEngine;

namespace Script
{
    public class Spawner : RecycleObject
    {
        [SerializeField] private float moveSpeed = 5f;
        public float hp = 5f;

        private Monster _monster;
        
        // Start is called before the first frame update
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            transform.position += transform.right * (moveSpeed * Time.deltaTime);
        }

        private void OnDamaged(float damage)
        {
            hp -= damage;
            if (hp == 0)
            {
                destroyed?.Invoke(this); // 객체 회수 이벤트 호출        
                _monster.attack -= OnDamaged; // spawner 와 monster 에 연결된 이벤트 해제
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Weak Monster"))
            {
                _monster = other.collider.GetComponent<Monster>();
                _monster.attack += OnDamaged; // spawner 와 monster 이벤트 연결
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.transform.CompareTag("Weak Monster"))
            {
                _monster = other.collider.GetComponent<Monster>();
                _monster.attack -= OnDamaged; // spawner 와 monster 에 연결된 이벤트 해제
            }
        }
    }
}
