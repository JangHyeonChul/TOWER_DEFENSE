using UnityEngine;

public class TowerManager : MonoBehaviour
{

    public int attackPower = 10;

    // �̱��� �ν��Ͻ�
    public static TowerManager Instance { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTowerAttackPower(int power)
    {
        attackPower += power;
    }

    public int GetTowerAttackPower()
    {
        return attackPower;
    }
    
}
