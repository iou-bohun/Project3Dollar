using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public abstract class MonsterController : MonoBehaviour, Controller
{
    [SerializeField] private EnemyInfo data;
    private float tick;
    private String code;
    private Text text;
    private int HP;
    private String name;

    [SerializeField] private TextMeshProUGUI dialogue;
    
    public void loadDataAndEnroll(string code, GameObject text)
    {
        this.code = code;
        BattleManager.Instance.enrollMonster(code, this);
        this.text = text.GetComponent<Text>();
        text.transform.position = new Vector3(transform.position.x, transform.position.y-1, 0);
        HP = data.MaxHP;
        this.text = text.GetComponent<Text>();
        StartCoroutine("viewInfo");
    }


    IEnumerator viewInfo()
    {
        while (true)
        {
            text.text = "tick : "+tick+"//HP : "+HP;
            yield return null;
        }
    }

    public bool getTick()
    {
        tick += data.Speed;
        if (tick >= 20f)
        {
            tick = 0;
            return true;
        }
        return false;
    }

    public void getDamage(BattleManager.attackType type, float damage)
    {
        float trueDamage = data.Block[(int)type] * damage;
        HP -= (int)trueDamage;
        dialogue.text = "몬스터에게 " + trueDamage + "의 피해를 입혔습니다!";
        if (HP<=0) die();
    }

    public abstract void getTurn();
    /*{
        //행동을 할지에 대한 정보
        float damage = 10;
        BattleManager.Instance.notifyAttackToPlayer(BattleManager.attackType.Pierce,(int)damage);
        //BattleManager에게 턴이 끝났음을 알림
        BattleManager.Instance.notifyTurnEnd();
    }*/

    public void die()
    {
        gameObject.SetActive(false);
        BattleManager.Instance.monsterDie(code);
        Destroy(text);
        Destroy(this);
    }

    public string getCode()
    {
        return code;
    }

}
