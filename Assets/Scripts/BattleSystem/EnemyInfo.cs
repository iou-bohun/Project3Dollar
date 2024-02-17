
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Info", menuName = "Scriptable Object/Enemy Info",order = int.MaxValue)]
public class EnemyInfo :ScriptableObject
{
    [SerializeField]
    private string name;
    public string Name
    {
        get { return name; }
    }
    [SerializeField] private int maxHp;
    public int MaxHP
    {
        get { return maxHp; }
        set { maxHp = value; }
    }
    [SerializeField] private int speed;
    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    [SerializeField] private float[] block = new float[3];
    public float[] Block
    {
        get { return block; }
    }

}
