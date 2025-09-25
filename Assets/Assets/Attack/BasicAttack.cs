using UnityEngine;

/** 
 BasicAttack은 일반 공격 방식으로써, 적 유닛 1마리에게 대미지가 들어갑니다
 */
public class BasicAttack : MonoBehaviour
{

    private Collider2D collider;
    public GameObject attackObject;

    private Coroutine chaseCoroutine;

    // 싱글톤 인스턴스
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
        // 적과 충돌시 실행
        if (other.gameObject.CompareTag("Enemy"))
        {
            attackObject.SetActive(false);

            GameObject targetEnemy = other.gameObject;
            int towerAttackPower = TowerManager.Instance.GetTowerAttackPower();
            targetEnemy.GetComponent<EnemyHealth>().TakeDamage(towerAttackPower, targetEnemy);
            
        }
    }
}
