using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    private static BattleManager _instance;
    private UserController _player;
    private Dictionary<String, MonsterController> _monster = new Dictionary<string, MonsterController>();

    private float tick=0;
    private bool isSomeonePlaying = false;
    private Queue<Controller> turnQueue = new Queue<Controller>();
    
    public enum attackType{Slash, Pierce, Strike}

    [SerializeField]private Text text;

    //팝업
    [SerializeField] GameObject PopUpWindow;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static BattleManager Instance
    {
        get
        {
            if (_instance == null) return null;
            return _instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "state : " + isSomeonePlaying + "// queuesize : " + turnQueue.Count;
        if (!isSomeonePlaying)
        {     
            if (turnQueue.Count > 0)
            {
                isSomeonePlaying = true;
                Controller x = turnQueue.Dequeue();
                Debug.Log("Gotten");
                x.getTurn();
            }
            else
            {
                tick += Time.deltaTime;
                if (tick > 0.5f)
                {
                    tick = 0;
                    giveTick();
                }
            }
        }
    }

    public void notifyTurnEnd()
    {
        isSomeonePlaying = false;
        Debug.Log(isSomeonePlaying);
    }

    public void notifyAttackToPlayer(attackType type, int damage)
    {
        _player.getDamage(type, damage);
    }

    public void notifyAttackToMonster(attackType type, int damage, String code)
    {
        _monster.TryGetValue(code, out MonsterController m);
        m.getDamage(type, damage);
    }

    public void giveTick()
    {
        bool x;
        x=_player.getTick();
        if(x) turnQueue.Enqueue(_player);
        
        foreach (MonsterController m in _monster.Values)
        {
            x=m.getTick();
            if(x) turnQueue.Enqueue(m);
        }
        
    }

    public void enrollPlayer(UserController p)
    {
        if (_player == null)
        {
            _player = p;
        }
        Debug.Log("Player inserted");
    }
    public void enrollMonster(String code, MonsterController m)
    {
        if (!_monster.ContainsKey(code))
        {
            _monster.Add(code,m);
        }
        Debug.Log(code + "inserted");
    }

    public void monsterDie(string code)
    {
        if (_monster.ContainsKey(code))
        {
            _monster.Remove(code);
        }

        if (_monster.Count <= 0)
        {
            //대충 게임 승
            PopUpWindow.gameObject.SetActive(true);
            Debug.Log("you win");
        }
    }

    private void PopUpReward()
    {
        PopUpWindow.SetActive(true);
    }
}
