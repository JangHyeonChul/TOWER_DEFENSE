using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;

    private void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        // Tower를 향한 방향 계산
        Vector3 direction = (target.position - transform.position).normalized;

        // 방향으로 이동
        transform.position += direction * Time.deltaTime * 2.0f;
    }
}
