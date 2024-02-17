using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private int hp = 100;
    public int HP { get { return hp; } }

    private int speed=5;
    public int Speed { get { return speed; } }
}
