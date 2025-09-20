using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // 메인 카메라 참조
    private Camera mainCamera;

    // 적 객체 생성
    public GameObject enemyPrefab;
    private List<GameObject> enemyPool;
    private Coroutine spawnCorutine;

    // 싱글톤 인스턴스
    public static EnemySpawner Instance { get; private set; }

    private void Awake()
    {
        // 싱글톤 패턴 구현
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 중복된 객체를 파괴
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 파괴되지 않도록 설정
    }

    void Start()
    {
        Debug.Log("EnemySpawner started");

        // 메인 카메라 초기화
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("[EnemySpawner] Main camera not found!");
            return;
        }

        // 적 객체 풀 초기화
        InitializePool();

        // 적 스폰 코루틴 시작
        spawnCorutine = StartCoroutine(EnemySpawnCorutine());
    }

    // 적 객체 풀 초기화
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
            yield return new WaitForSeconds(10f);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        // 풀에 적이 존재하지 않을경우
        if (enemyPool == null || enemyPool.Count == 0)
        {
            return;
        }

        // 풀에서 비활성화된 적 객체를 가져옴
        GameObject enemy = GetPooledEnemy();
        if (enemy != null)
        {
            // 카메라 화면 경계 밖의 랜덤 위치 계산
            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPosition = mainCamera.transform.position + (Vector3)spawnDirection * 10f;

            enemy.transform.position = spawnPosition;
            enemy.SetActive(true);
        }
    }

    // 풀에서 비활성화된 적 객체를 반환
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

    // 적 객체를 풀로 반환하는 메서드 (적 객체가 비활성화될 때 호출)
    public void ReturnToPool(GameObject enemy)
    {
        enemy.GetComponent<EnemyHealth>().ResetEnemyHealth();
        enemy.SetActive(false);
    }
}
