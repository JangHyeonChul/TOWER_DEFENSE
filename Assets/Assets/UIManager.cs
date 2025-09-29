using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public TextMeshProUGUI moneyText;

    public GameObject shopUI;
    public Button shopBtn;
    public Button shopExitBtn;

    public Button attackUpradeBtn;
    public GameObject spellPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �̱��� �ν��Ͻ� ����
        Instance = this;

        // �ʱ� UI �ʱ�ȭ
        UpdateMoneyText();
        
        if (shopBtn != null)
        {
            shopBtn.onClick.AddListener(OpenShopUI);
        }

        if (shopExitBtn != null)
        {
            shopExitBtn.onClick.AddListener(CloseShopUI);
        }

        if (attackUpradeBtn != null)
        {
            attackUpradeBtn.onClick.AddListener(AttackUprade);
        }
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

    void OpenShopUI()
    {
        shopUI.SetActive(true);
    }

    void CloseShopUI()
    {
        shopUI.SetActive(false);
    }

    void AttackUprade()
    {
        MoneyManager moneyManager = MoneyManager.Instance;
        TowerManager towerManager = TowerManager.Instance;

        int money = moneyManager.GetMoney();
        if (money >= 10)
        {
            moneyManager.RemoveMoney(10);
            towerManager.AddTowerAttackPower(2);
            UpdateMoneyText();

        }
    }
}
