using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    private int baseEnemyHealth = 100;
    public int emenyHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        emenyHealth = baseEnemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage, GameObject targetEnemy)
    {
        int attackResultEnemyHealth = emenyHealth - damage;
        if (attackResultEnemyHealth < 0)
        {
            EnemySpawner.Instance.ReturnToPool(targetEnemy);
            MoneyManager.Instance.AddMoney(10);
            UIManager.Instance.UpdateMoneyText();
        }
        else
        {
            emenyHealth = attackResultEnemyHealth;
        }
        
    }

    public void ResetEnemyHealth()
    {
        emenyHealth = baseEnemyHealth;
    }
}
