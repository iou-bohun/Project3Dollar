using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UserController : MonoBehaviour, Controller
{
    private int HP;
    private float tick;
    private float speed;

    private float[] block = new float[3];

    [SerializeField]private Text text;
    [SerializeField] private TextMeshProUGUI dialogue;
    // Start is called before the first frame update
    void Start()
    {
        BattleManager.Instance.enrollPlayer(this);
        block = new float[3]{0.2f,1.2f,0.8f};
        speed = 7;
        HP = 100;
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
        dialogue.text = "플레이어가  " + trueDamage+"의 데미지를 입었습니다.";
    }

    public void getTurn()
    {
        PlayerTurnController.Instance.startTurn(this);
    }
    
    public void EndTurn(){BattleManager.Instance.notifyTurnEnd();}

    public void EndTurn(BattleManager.attackType type, int damage, String target)
    {
        BattleManager.Instance.notifyAttackToMonster(type,damage,target);
        BattleManager.Instance.notifyTurnEnd();
    }

    public void die()
    {
        //gameover
    }
}
