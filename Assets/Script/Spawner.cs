using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class Spawner : LivingEntity
    {
        public Action<float> spawnerAttack;

        protected override void Start()
        {
            // Slider 위치를 캐릭터 위에 위치시키려고 쓰는 인스턴스
            _hpBarPosition = transform.Find("Canvas").transform.Find("Slider").gameObject; 
            _hpBar = _hpBarPosition.GetComponent<Slider>();
            // 풀피로 시작
            _hp = MAXHp;
            // UI. 풀피로 시작
            _hpBar.value = 1;
        }

        protected override void Update()
        {
            if(!_attacking)
            {
                var transform1 = transform;
                transform1.position += transform1.right * (moveSpeed * Time.deltaTime);
            }
            Debug.Assert(Camera.main != null, "Camera.main != null");
            // 오브젝트에 따른 HP Bar 위치 이동
            _hpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.2f, 0)); 
        }
        
        protected override IEnumerator AttackCoroutine()
        {
            while (true)
            {
                if (!_attacking)
                    yield break;
                yield return new WaitForSeconds(1.0f);
                spawnerAttack?.Invoke(Damage);
            }
        }
        
        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Monster")) return;
            var monster = other.collider.GetComponent<Monster>();
            // spawner 와 monster 이벤트 연결
            monster.monsterAttack += OnDamaged;
            _attacking = true;
            StartCoroutine(AttackCoroutine());
        }

        protected override void OnCollisionExit2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Monster")) return;
            var monster = other.collider.GetComponent<Monster>();
            // spawner 와 monster 에 연결된 이벤트 해제
            monster.monsterAttack -= OnDamaged;
            _attacking = false;
            StopCoroutine(AttackCoroutine());
        }
    }
}
