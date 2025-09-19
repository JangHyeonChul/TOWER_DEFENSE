using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int emenyHealth = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

        }
        else
        {
            emenyHealth = attackResultEnemyHealth;
        }
        
    }
}
