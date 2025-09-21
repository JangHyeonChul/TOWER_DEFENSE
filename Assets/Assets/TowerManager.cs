using UnityEngine;

public class TowerManager : MonoBehaviour
{



    public int health = 100;
    public int attackPower = 10;

    // ΩÃ±€≈Ê ¿ŒΩ∫≈œΩ∫
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

    public void RemoveTowerHealth(int damage)
    {
        health -= damage;
    }

}
