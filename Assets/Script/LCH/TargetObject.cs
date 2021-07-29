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
