using System;
using UnityEngine;

namespace Assets.Script.LCH
{
    public class LivingEntity:MonoBehaviour,IDamageable
    {
        public float maxHealth = 100 ;
        public float Health { get; protected set; }
        public bool Dead { get; protected set; }
        public event Action OnDeath;
        
        protected virtual void OnEnable()
        {
            Dead = false;
            Health = maxHealth;
        }
        public virtual void OnDamage(float damage)
        {
            Health -= damage;
            if (Health <= 0 && !Dead)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            if (OnDeath != null)
            {
                OnDeath();
            }
            //임시
            //태그 변환?
            gameObject.SetActive(false);
            Dead = true;
        }
    }
}