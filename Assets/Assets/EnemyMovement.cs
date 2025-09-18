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
        // Tower�� ���� ���� ���
        Vector3 direction = (target.position - transform.position).normalized;

        // �������� �̵�
        transform.position += direction * Time.deltaTime * 2.0f;
    }
}
