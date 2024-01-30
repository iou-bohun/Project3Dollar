﻿using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    Big, Small
}

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private List<EnemyInfo> EnemyDatas;
    [SerializeField]
    private GameObject EnamyPrefab;
    [SerializeField]
    private GameObject TextPrefab;

    [SerializeField] private Canvas canvas;

    private List<GameObject> Enemys;

    private static MonsterSpawner _instance;
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

    public static MonsterSpawner Instance
    {
        get
        {
            if (_instance == null) return null;
            return _instance;
        }
    }
    void Start()
    {
        Enemys = new List<GameObject>();
        for (int i = 0; i < EnemyDatas.Count; i++)
        {
            Enemys.Add(SpawnMonster(i));
        }
    }

    public GameObject SpawnMonster(int i)
    {
        GameObject gm = Instantiate(EnamyPrefab);
        Vector3 t = new Vector3(transform.position.x + (10 / EnemyDatas.Count * i), transform.position.y, 0);
        gm.GetComponent<Transform>().position = t;
        var newMon = gm.GetComponent<MonsterController>();
        string code = string.Concat(EnemyDatas[i].Name.Substring(0, 3),i);
        GameObject text = Instantiate(TextPrefab,t,Quaternion.identity,canvas.transform);
        
        newMon.loadDataAndEnroll(EnemyDatas[i],code,text);
        return gm;
    }
}