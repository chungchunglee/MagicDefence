using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.LCH
{
    public class PlayerHealth:LivingEntity
    {
        public Slider _hpbar;

        private void Awake()
        {
            
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _hpbar.gameObject.SetActive(true);
            _hpbar.maxValue = maxHealth;
            _hpbar.value = Health;
        }

        public override void OnDamage(float damage)
        {
            /*
            if (!Dead)
            {
                //효과음 재생
            }
            */
            base.OnDamage(damage);
            _hpbar.value = Health;
        }

        public override void Die()
        {
            base.Die();
            _hpbar.gameObject.SetActive(false);
            //사망 에니메이션, 음악 재생
            //조작 disable
        }
    }
}