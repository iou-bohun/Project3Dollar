
using System;
using UnityEngine;

public class StageLoader : MonoBehaviour
{
    [SerializeField] private GameObject SkeletonArcher;

    private void Start()
    {
        MonsterSpawner.Instance.addMonster(SkeletonArcher,2);
    }
}