using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private Collider2D attackRangeCollider;

    private List<GameObject> enemyPoolList;
    private Coroutine attackCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackRangeCollider = GetComponent<Collider2D>();
        if (attackRangeCollider == null)
        {
            Debug.Log("Attack Collider NPE");
        }

        enemyPoolList = new List<GameObject>();
        attackCoroutine = StartCoroutine(TowerAttack());
    } 

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ±êÇãºê Ä¿¹Ô Å×½ºÆ®
        enemyPoolList.Add(other.gameObject); 

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        enemyPoolList.Remove(collision.gameObject);
    }

    private IEnumerator TowerAttack()
    {
        while (true)
        {
            if (enemyPoolList.Count > 0)
            {
                // Attack the first enemy in the list
                GameObject targetEnemy = enemyPoolList[0];
                targetEnemy.GetComponent<EnemyHealth>().TakeDamage(10, targetEnemy);

            }

            yield return new WaitForSeconds(1f);
        }


    }
}
