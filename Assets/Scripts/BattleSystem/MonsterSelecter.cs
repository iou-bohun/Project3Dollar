using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterSelecter : MonoBehaviour
{
    public string monsterName;
    private void Awake()
    {
       var obj = FindObjectsOfType<MonsterSelecter>();
        if(obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        monsterName = SceneManager_.instance.eventName;
    }
    private void OnDisable()
    {
       SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
