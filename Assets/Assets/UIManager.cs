using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; }

    public TextMeshProUGUI moneyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �̱��� �ν��Ͻ� ����
        Instance = this;

        // �ʱ� UI �ʱ�ȭ
        UpdateMoneyText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMoneyText()
    {
        int money = MoneyManager.Instance.GetMoney();
        moneyText.text = $"Money : {money}";
    }
}
