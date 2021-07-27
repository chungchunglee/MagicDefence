using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.LCH
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField] private float speed = 0.5f;
    
        //Max Status
        [SerializeField]
        private float maxHp = 100;
        [SerializeField]
        private float maxMana = 30;
        [SerializeField]
        private float maxMeat = 20;
                  
        //ÇöÀç floattus
        private float nowHp;
        private float nowMana;
        private float nowMeat;
        private float recoveryHp;
        private float recoveryMana;
        private float recoveryMeat;


        [SerializeField]
        float unitGenerateTime = 1.0f;




        public bool isDead = false;
        private Image hpBar;
        private Image meatBar;
        private Image manaBar;
        private Image expBar;

        void Start()
        {
            nowHp = maxHp;
            nowMana = 0;
            nowMeat = 0;
            recoveryHp = 0;
            recoveryMana = 0.5f;
            recoveryMeat = 0.2f;
        }

        // Update is called once per frame
        void Update()
        {


            Recovery(0, 0, 0);
            hpBar.fillAmount = nowHp / maxHp;
            meatBar.fillAmount = nowMeat / maxMeat;
            manaBar.fillAmount = nowMana / maxMana;
        }
        void Recovery(float addHp,float addMeat, float addMana)
        {
            nowHp += (addHp + recoveryHp) * Time.deltaTime;
            if (maxHp <= nowHp) nowHp = maxHp;

            nowMeat += (addMeat + recoveryMeat) * Time.deltaTime;
            if (maxMeat <= nowMeat) nowMeat = maxMeat;
        
            nowMana += (addMana + recoveryMana) * Time.deltaTime;
            if (maxMana <= nowMana) nowMana = maxMana;
        }
    }
}
