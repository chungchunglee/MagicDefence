using UnityEngine;

namespace Assets.Script.LCH
{
    public class EnemyStatus : MonoBehaviour
    {
        [SerializeField] private float speed = 0.5f;
    
        //Max Status
        [SerializeField]
        private float maxHp = 100;
        [SerializeField]
        private float maxMana = 30;
        [SerializeField]
        private float maxMeat = 20;
                  
        //현재 floattus
        private float nowHp;
        private float nowMana;
        private float nowMeat;
        private float recoveryHp;
        private float recoveryMana;
        private float recoveryMeat;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
