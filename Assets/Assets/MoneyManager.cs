using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    public int money = 0;

    // ΩÃ±€≈Ê ¿ŒΩ∫≈œΩ∫
    public static MoneyManager Instance { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ΩÃ±€≈Ê ∞¥√º «“¥Á
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }
}
