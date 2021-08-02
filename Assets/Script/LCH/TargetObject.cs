// 인식거리 & 사정거리
// 자동 이동(바라보는 방향 + 이동속도)
// 사정거리 - 정지 + 공격 // OnTriggerEnter
// 사정거리 벗어남 - 이동 재개 // OnTriggerExit

using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class TargetObject : MonoBehaviour
{

    protected bool isEnemy;

    protected float hp;
    protected float attack;
    public float attackSpeed;
    public bool isAttacked;
    private float localTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void onDamaged(float damage)
    {
        hp -= damage;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(isAttacked&&other.tag == "Player")
        {
            other.gameObject.GetComponent<TargetObject>.onDamaged(attack);
            //에니메이션
            ~isAttacked;
        }
        else
        {
            localTime+=Time.deltaTime;
            if(localTime>=attackSpeed)
            {
                ~isAttacked;
                localTime = 0;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        //보는 방향으로 이동
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    [SerializeField] protected ObjectInfo objectInfo;//https://everyday-devup.tistory.com/53 참조 
    [SerializeField] protected GameObject destroyEffect;

    protected bool isEnemy;

    protected float hp;

    public bool isNextTarget;

    public ObjectInfo Info
    {
        get
        {
            return objectInfo;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

*/
