using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.LCH
{
    public class Enemy:LivingEntity
    {
        public float speed = 5.0f;
        public float damage = 20f;
        public float timeBetAttack = 1.5f;
        private float lastAttackTime;
        private new Rigidbody2D rigidbody2D;
        
        public Slider _hpbar;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            _hpbar.gameObject.SetActive(true);
            _hpbar.maxValue = maxHealth;
            _hpbar.value = Health;
        }

        private void Start() // start awake 구분해서 - disable 되었을때도 고려해야함
        {
            Debug.Log("Start");
            rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = new Vector2(-1, 0) * speed;
        }
        public void Setup(float newHealth, float newDamage, float newSpeed)
        {
            maxHealth = newHealth;
            Health = newHealth;
            damage = newDamage;
            speed = newSpeed;
        }

        public override void OnDamage(float damage)
        {
            /*
            if (!Dead)
            {
                //피격판정 구현
            }
            */
            base.OnDamage(damage);
        }

        public override void Die()
        {
            base.Die();
            //사망 구현
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            Debug.Log("OnTrigger");
            if (other.tag == "Player")
            {
                rigidbody2D.velocity = Vector2.zero;
                if (!Dead && Time.time >= lastAttackTime + timeBetAttack)
                {
                    // other.tag로 검사이후 getComponent ->
                    LivingEntity attackTarget = other.GetComponent<LivingEntity>();
                    lastAttackTime = Time.time;
                    attackTarget.OnDamage(damage);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("OnTriggerExit");
            rigidbody2D.velocity = new Vector2(-1, 0) * speed;
        }
    
    }
}