using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSelecter : MonoBehaviour
{
    public string monsterName;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        monsterName = SceneManager_.instance.eventName;
    }
}
