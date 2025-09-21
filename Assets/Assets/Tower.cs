using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private Collider2D towerCollider;
    private Coroutine damageCoroutine;

    bool IsDamage = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        towerCollider = GetComponent<Collider2D>();

        damageCoroutine = StartCoroutine(TowerDamage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            IsDamage = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            IsDamage = false;
        }
    }

    private IEnumerator TowerDamage()
    {
        while (true)
        {
            if (IsDamage)
            {
                int enemyPower = EnemySpawner.Instance.GetEnemyPower();
                TowerManager.Instance.RemoveTowerHealth(enemyPower);
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
