using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class LivingEntity : RecycleObject, IDamageable
    {
        [SerializeField] public float moveSpeed = 5f;
        public SkeletonAnimation _skeletonAnimation;
        protected static float Damage = 1;
        public const float MAXHp = 5f;
        public float _hp;
        public Slider _hpBar;
        public GameObject _hpBarPosition;
        public bool _attacking;
        public Action<float> monsterAttack;
        
        protected virtual void Start()
        {
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
            // 걷는 모션
            _skeletonAnimation.AnimationName = "walk";
            Animation();
            DamageControl();
            WalkSpeedControl();
            // Slider 위치를 캐릭터 위에 위치시키려고 쓰는 인스턴스
            _hpBarPosition = transform.Find("Canvas").transform.Find("Slider").gameObject; 
            _hpBar = _hpBarPosition.GetComponent<Slider>();
            // 풀피로 시작
            _hp = MAXHp;
            // UI. 풀피로 시작
            _hpBar.value = 1;
        }

        protected virtual void Animation() { }

        protected virtual void DamageControl() { }
        
        protected virtual void WalkSpeedControl() { }
        
        protected virtual void Update()
        {
            if (!_attacking)
            {
                var transform1 = transform;
                transform1.position += (-transform1.right) * (moveSpeed * Time.deltaTime);
            }
            Debug.Assert(Camera.main != null, "Camera.main != null");
            _hpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 2.4f, 0)); // 오브젝트에 따른 HP Bar 위치 이동
        }

        protected virtual void OnDamaged(float damage)
        {
            _hp -= damage;
            // UI
            _hpBar.value = _hp / MAXHp;
            if (_hp != 0) return;
            // 풀피로 저장. initializes
            _hp = MAXHp;
            // UI. 풀피로 저장. initialize
            _hpBar.value = 1;
            // 객체 회수 이벤트 호출
            destroyed?.Invoke(this);
        }
        
        protected virtual IEnumerator AttackCoroutine()
        {
            while (true)
            {
                if (!_attacking)
                    yield break;
                yield return new WaitForSeconds(1.0f);
                monsterAttack?.Invoke(Damage);
            }
        }
        
        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Spawner")) return;
            // 공격 모션
            _skeletonAnimation.AnimationName = "Attack";
            var spawner = other.collider.GetComponent<Spawner>();
            // spawner 와 monster 이벤트 연결
            spawner.spawnerAttack += OnDamaged;
            _attacking = true;
            StartCoroutine(AttackCoroutine());
        }

        protected virtual void OnCollisionExit2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Spawner")) return;
            var spawner = other.collider.GetComponent<Spawner>();
            // spawner 와 monster 에 연결된 이벤트 해제
            spawner.spawnerAttack -= OnDamaged;
            // 걷는 모션
            _skeletonAnimation.AnimationName = "walk";
            _attacking = false;
            StopCoroutine(AttackCoroutine());
        }
    }
}
