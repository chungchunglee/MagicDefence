using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    float speed = 0.5f;
    
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
    public Image HPBar;
    public Image MeatBar;
    public Image ManaBar;
    public Image ExpBar;

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


        recovery(0, 0, 0);
        HPBar.fillAmount = nowHp / maxHp;
        MeatBar.fillAmount = nowMeat / maxMeat;
        ManaBar.fillAmount = nowMana / maxMana;
    }
    void recovery(float addHP,float addMeat, float addMana)
    {
        nowHp += (addHP + recoveryHp) * Time.deltaTime;
        if (maxHp <= nowHp) nowHp = maxHp;

        nowMeat += (addMeat + recoveryMeat) * Time.deltaTime;
        if (maxMeat <= nowMeat) nowMeat = maxMeat;
        
        nowMana += (addMana + recoveryMana) * Time.deltaTime;
        if (maxMana <= nowMana) nowMana = maxMana;
    }
}
