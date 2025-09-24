using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private List<GameObject> enemyPoolList = new();

    void Start()
    {

    } 

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
        // 적이 공격 사정거리 내에 들어왔을 경우 삭제
        if (other.CompareTag("Enemy")) 
        { 
            enemyPoolList.Remove(other.gameObject);
        }
    }

    public List<GameObject> GetEnemyList()
    {
        return enemyPoolList;
    }
}
