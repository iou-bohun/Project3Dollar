using System;
using System.Collections;
using UnityEngine.UI;

using UnityEngine;
using DefaultNamespace;
using Unity.VisualScripting;

public class PlayerTurnController : MonoBehaviour
{
    [SerializeField]private GameObject btnAttack;
    [SerializeField]private GameObject btnBlock;
    [SerializeField]private GameObject btnItem;
    
    [SerializeField]private GameObject btnSlash;
    [SerializeField]private GameObject btnPierce;
    [SerializeField]private GameObject btnStrike;


    private static PlayerTurnController _instance;
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
    public static PlayerTurnController Instance
    {
        get
        {
            if (_instance == null) return null;
            return _instance;
        }
    }
    
    private String target;
    private BattleManager.attackType type;
    private UserController user;

    private void Start()
    {
        setBehaviorBtns(false);
        setAttackBtns(false);
    }

    public void startTurn(UserController x)
    {
        user = x;
        setBehaviorBtns(true);
        setAttackBtns(false);
    }

    public void item()
    {
        
    }

    public void defense()
    {
        
    }
    
    public void attack()
    {
        setBehaviorBtns(false);
        setAttackBtns(true);
        Debug.Log("Attack");
    }

    public void SlashAttack()
    {
        setAttackBtns(false);
        type = BattleManager.attackType.Slash;
        chooseTarget();
    }
    public void chooseAttackType(int n)
    {
        Debug.Log("Attack type - "+n);
        setAttackBtns(false);
        type = (BattleManager.attackType)n;
        chooseTarget();
    }

    public void chooseTarget()
    {
        StartCoroutine("targeting");

    }

    IEnumerator targeting()
    {
        bool targeted = false;
        Debug.Log("start targeting");
        while (!targeted)
        {
            yield return null;
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                if (hit.collider != null)
                {
                    GameObject x = hit.collider.gameObject;
                    if (x.TryGetComponent(out MonsterController k))
                    {
                        target = k.getCode();
                        targeted = true;
                    }
                }
            }
        }

        yield return null;
        chooseWeapon();
    }

    public void chooseWeapon()
    {
        int damage = 10;
        //call something
        user.EndTurn(type,damage,target);
    }
    

    private void setBehaviorBtns(bool x)
    {
        btnAttack.SetActive(x);
        btnBlock.SetActive(x);
        btnItem.SetActive(x);
    }
    private void setAttackBtns(bool x)
    {
        btnSlash.SetActive(x);
        btnPierce.SetActive(x);
        btnStrike.SetActive(x);
    }

}