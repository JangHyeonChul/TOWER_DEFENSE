using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject attackRange;

    private Collider2D towerCollider;
    private Coroutine damageCoroutine;
    private Coroutine attackCoroutine;

    bool IsDamage = false;

    void Start()
    {
        towerCollider = GetComponent<Collider2D>();
        damageCoroutine = StartCoroutine(TowerDamage());
        attackCoroutine = StartCoroutine(TowerAttack());
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

    private IEnumerator TowerAttack()
    {
        while (true)
        {
            AttackRange attackRangeObj = attackRange.GetComponent<AttackRange>();
            List<GameObject> enemyList = attackRangeObj.GetEnemyList();
            yield return new WaitForSeconds(1f);
        }
    }
}
