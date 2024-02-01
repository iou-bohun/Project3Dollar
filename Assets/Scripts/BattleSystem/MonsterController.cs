using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour, Controller
{
    private int HP;
    private float tick;
    private float speed;

    private float[] damage = new float[3];
    private float[] block = new float[3];

    private String code;

    [SerializeField]private Text text;
    [SerializeField] private TextMeshProUGUI dialogue;
    
    
    // Start is called before the first frame update
    void Start() //monsterDataLoadAndEnroll
    {
        //비쥬얼적인 어떤 이미지를 불러올지까지
        HP = 20;
        damage = new float[3]{0.2f,1.2f,0.8f};
        block = new float[3]{0.2f,1.2f,0.8f};
        code = "001";
        speed = 3;
        BattleManager.Instance.enrollMonster(code, this);
    }

    private void Update()
    {
        text.text = "tick : "+tick+"//HP : "+HP;
    }

    public bool getTick()
    {
        tick += speed;
        if (tick >= 20f)
        {
            tick = 0;
            return true;
        }
        return false;
    }

    public void getDamage(BattleManager.attackType type, float damage)
    {
        float trueDamage = block[(int)type] * damage;
        HP = HP - (int)trueDamage;
        dialogue.text = "몬스터에게 " + trueDamage + "의 피해를 입혔습니다!";
        if (HP<=0) die();
    }

    public void getTurn()
    {
        //행동을 할지에 대한 정보
        float damage = 10 * this.damage[(int)BattleManager.attackType.Pierce];
        BattleManager.Instance.notifyAttackToPlayer(BattleManager.attackType.Pierce,(int)damage);
        //BattleManager에게 턴이 끝났음을 알림
        BattleManager.Instance.notifyTurnEnd();
    }

    public void die()
    {
        gameObject.SetActive(false);
        BattleManager.Instance.monsterDie(code);
    }

    public string getCode()
    {
        return code;
    }

}
