using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

namespace Script
{
    public class Monster : RecycleObject
    {
        [SerializeField] private float moveSpeed = 5f;
        private SkeletonAnimation _skeletonAnimation;
        private const float Damage = 1;

        private const float MAXHp = 5f;
        private float _hp;
        private Slider _hpBar;
        private GameObject _hpBarPosition;
        
        private Spawner _spawner;
        
        public Action<float> monsterAttack;

        private bool _attacking;

        // Start is called before the first frame update
        private void Start()
        {
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
            _skeletonAnimation.AnimationName = "walk"; // 걷는 모션
            
            _hpBarPosition = transform.Find("Canvas").transform.Find("Slider").gameObject; // Slider 위치를 캐릭터 위에 위치시키려고 쓰는 인스턴스
            _hpBar = _hpBarPosition.GetComponent<Slider>();
            
            _hp = MAXHp; // 풀피로 시작
            _hpBar.value = 1; // UI. 풀피로 시작
        }

        // Update is called once per frame
        private void Update()
        {
            if (!_attacking)
            {
                var transform1 = transform;
                transform1.position += (-transform1.right) * (moveSpeed * Time.deltaTime);
            }

            Debug.Assert(Camera.main != null, "Camera.main != null");
            _hpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 2.4f, 0)); // 오브젝트에 따른 HP Bar 위치 이동
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Spawner")) return;
            _skeletonAnimation.AnimationName = "Attack"; // 공격 모션
                
            _spawner = other.collider.GetComponent<Spawner>();
            _spawner.spawnerAttack += OnDamaged; // spawner 와 monster 이벤트 연결
                
            _attacking = true;
                
            StartCoroutine(AttackCoroutine());
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Spawner")) return;
            _spawner = other.collider.GetComponent<Spawner>();
            _spawner.spawnerAttack -= OnDamaged; // spawner 와 monster 에 연결된 이벤트 해제
                
            _skeletonAnimation.AnimationName = "walk"; // 걷는 모션
                
            _attacking = false;
            StopCoroutine(AttackCoroutine());
        }

        private void OnDamaged(float damage)
        {
            _hp -= damage;
            _hpBar.value = _hp / MAXHp; // UI
            if (_hp != 0) return;
            _hp = MAXHp; // 풀피로 저장
            _hpBar.value = 1; // UI. 풀피로 저장
            _spawner.spawnerAttack -= OnDamaged; // spawner 와 monster 에 연결된 이벤트 해제
            destroyed?.Invoke(this); // 객체 회수 이벤트 호출
        }
        
        private IEnumerator AttackCoroutine()
        {
            while (true)
            {
                if (!_attacking)
                    yield break;
                yield return new WaitForSeconds(1.0f);
                monsterAttack?.Invoke(Damage);
            }
        }
    }
}
