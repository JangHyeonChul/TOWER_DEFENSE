using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private Collider2D attackRangeCollider;

    private List<GameObject> enemyPoolList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackRangeCollider = GetComponent<Collider2D>();
        if (attackRangeCollider == null)
        {
            Debug.Log("Attack Collider NPE");
        }
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        enemyPoolList.Add(other.gameObject); 

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemyPoolList.Remove(collision.gameObject);
    }
}
