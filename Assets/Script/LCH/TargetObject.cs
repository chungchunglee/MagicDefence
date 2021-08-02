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

    public float hp;
    public float attack;
    public float attackSpeed;
    public bool isAttacked;
    public float localTime = 0;

    public float moveSpeed;

    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(-1, 0) * moveSpeed;
    }
    public void onDamaged(float damage)
    {
        hp -= damage;
        Debug.Log("get Damaged and hp is" + hp);
    }
    

    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log("Hit");
        //if (other.tag == "Player")
        {
            Debug.Log("Hit");
            if(isAttacked)
            {
                rigidbody2D.velocity = new Vector2((float)0.01, 0);
                //rigidbody2D.velocity = new Vector2(-1, 0) * moveSpeed;
                other.gameObject.GetComponent<TargetObject>().onDamaged(attack);
                //에니메이션
                isAttacked=false;
            }
            else
            {
                localTime+=Time.deltaTime;
                if(localTime>=attackSpeed)
                {
                    isAttacked=true;
                    localTime = 0;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        rigidbody2D.velocity = new Vector2(-1, 0) * moveSpeed;
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
