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
}
