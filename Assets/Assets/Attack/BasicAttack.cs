using UnityEngine;

/** 
 BasicAttack�� �Ϲ� ���� ������ν�, �� ���� 1�������� ������� ���ϴ�
 */
public class BasicAttack : MonoBehaviour
{

    private Collider2D collider;
    public GameObject attackObject;

    private Coroutine chaseCoroutine;

    // �̱��� �ν��Ͻ�
    public static BasicAttack Instance { get; private set; }

    void Start()
    {
        Instance = this;
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack(GameObject targetObj)
    {
        attackObject.SetActive(true);
        Rigidbody2D attackRigidBody = attackObject.GetComponent<Rigidbody2D>();

        Vector3 direction = (targetObj.transform.position - attackObject.transform.position).normalized;

        attackRigidBody.AddForce(direction * 10f, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ���� �浹�� ����
        if (other.gameObject.CompareTag("Enemy"))
        {
            attackObject.SetActive(false);

            GameObject targetEnemy = other.gameObject;
            int towerAttackPower = TowerManager.Instance.GetTowerAttackPower();
            targetEnemy.GetComponent<EnemyHealth>().TakeDamage(towerAttackPower, targetEnemy);
            
        }
    }
}
