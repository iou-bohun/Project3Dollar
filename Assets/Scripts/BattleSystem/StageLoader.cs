
using System;
using System.Linq;
using UnityEngine;

public class StageLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterPrefabs;
    private string monstername;

    private void Awake()
    {
        monstername = GameObject.Find("MonsterSelecter").GetComponent<MonsterSelecter>().monsterName;
    }
    private void Start()
    {
        GameObject obj=  GetPrefab();
        MonsterSpawner.Instance.addMonster(obj,1);
    }

    private GameObject GetPrefab()
    {
        GameObject monsterPrefab = Array.Find(monsterPrefabs, elemen => elemen.name == monstername);
        return monsterPrefab;
    }
}