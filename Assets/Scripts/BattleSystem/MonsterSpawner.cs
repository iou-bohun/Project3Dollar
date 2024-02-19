using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    Big, Small
}

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject TextPrefab;

    [SerializeField] private Canvas canvas;

    private List<GameObject> Enemys;

    private int count = 0;

    private static MonsterSpawner _instance;

    [SerializeField] private Transform spawnPoints;
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
    
    
    /*void Start()
    {
        Enemys = new List<GameObject>();
        for (int i = 0; i < EnemyDatas.Count; i++)
        {
            Enemys.Add(SpawnMonster(i));
        }
    }*/

    public void addMonster(GameObject enemy, int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnMonster(enemy);
        }
    }

    /*public GameObject SpawnMonster(int i)
    {
        GameObject gm = Instantiate(EnamyPrefab);
        Vector3 t = new Vector3(transform.position.x + (10 / EnemyDatas.Count * i), transform.position.y, 0);
        gm.GetComponent<Transform>().position = t;
        
        var newMon = gm.GetComponent<MonsterController>();
        string code = string.Concat(EnemyDatas[i].Name,i);
        GameObject text = Instantiate(TextPrefab,t,Quaternion.identity,canvas.transform);
        
        newMon.loadDataAndEnroll(EnemyDatas[i],code,text);
        return gm;
    }*/

    private GameObject SpawnMonster(GameObject enemy)
    {
        GameObject gm = Instantiate(enemy);
        Vector3 t = new Vector3(spawnPoints.position.x + (3 * count++), spawnPoints.position.y, 0);
        gm.GetComponent<Transform>().position = t;
        
        var newMon = gm.GetComponent<MonsterController>();
        string code = string.Concat(newMon.name, count++);
        GameObject text = Instantiate(TextPrefab,t,Quaternion.identity,canvas.transform);
        
        newMon.loadDataAndEnroll(code,text);
        return gm;
    }
}