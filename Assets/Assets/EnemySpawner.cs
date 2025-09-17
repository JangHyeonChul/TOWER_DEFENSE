using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // ���� ī�޶� ����
    private Camera mainCamera;

    // �� ��ü ����
    public GameObject enemyPrefab;
    private List<GameObject> enemyPool;
    private Coroutine spawnCorutine;

    void Start()
    {
        Debug.Log("EnemySpawner started");

        // ���� ī�޶� �ʱ�ȭ
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("[EnemySpawner] Main camera not found!");
            return;
        }

        // �� ��ü Ǯ �ʱ�ȭ
        InitializePool();

        // �� ���� �ڷ�ƾ ����
        spawnCorutine = StartCoroutine(EnemySpawnCorutine());
    }

    // �� ��ü Ǯ �ʱ�ȭ
    private void InitializePool()
    {
        List<GameObject> enemyPoolList = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPoolList.Add(enemy);
        }

        enemyPool = enemyPoolList;
    }


    private IEnumerator EnemySpawnCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        // Ǯ�� ���� �������� �������
        if (enemyPool == null || enemyPool.Count == 0)
        {
            return;
        }

        // Ǯ���� ��ȭ�� �� ��ü�� ������
        GameObject enemy = GetPooledEnemy();
        if (enemy != null)
        {
            // ī�޶� ȭ�� ��� ���� ���� ��ġ ���
            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPosition = mainCamera.transform.position + (Vector3)spawnDirection * 10f;

            enemy.transform.position = spawnPosition;
            enemy.SetActive(true);
        }
    }

    // Ǯ���� ��ȭ�� �� ��ü�� ��ȯ
    private GameObject GetPooledEnemy()
    {
        foreach (var enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }
        return null;
    } 

    // �� ��ü�� Ǯ�� ��ȯ�ϴ� �޼��� (�� ��ü�� ��ȭ�� �� ȣ��)
    public void ReturnToPool(GameObject enemy)
    {
        enemy.SetActive(false);
    }
}
