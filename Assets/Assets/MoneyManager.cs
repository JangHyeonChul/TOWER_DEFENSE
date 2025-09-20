using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    public int money = 0;

    // �̱��� �ν��Ͻ�
    public static MoneyManager Instance { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �̱��� ��ü �Ҵ�
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
