using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private Collider2D attackRangeCollider;

    private List<GameObject> enemyPoolList;
    private Coroutine attackCoroutine;

    public GameObject basicAttack;

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
        // 적이 공격 사정거리 내에 들어왔을 경우 등록
        if (other.CompareTag("Enemy"))
        {
            enemyPoolList.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        enemyPoolList.Remove(other.gameObject);
    }

    private IEnumerator TowerAttack()
    {
        while (true)
        {
            if (enemyPoolList.Count > 0)
            {
                // Attack the first enemy in the list
                GameObject targetEnemy = enemyPoolList[0];
                BasicAttack.Instance.Attack(targetEnemy);
                //basicAttack.gameObject.SetActive(true);
                //Vector3 attackPosition = basicAttack.transform.position;
                //Vector3 targetPosition = targetEnemy.transform.position;

                //Vector3 attackMovePosition = attackPosition - targetPosition;

                //Vector3 direction = attackMovePosition.normalized;
                //basicAttack.transform.position = direction * 10f;

                //int towerAttackPower = TowerManager.Instance.GetTowerAttackPower();
                
                //targetEnemy.GetComponent<EnemyHealth>().TakeDamage(towerAttackPower, targetEnemy);

            }

            yield return new WaitForSeconds(1f);
        }
    }
}
