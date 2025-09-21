using UnityEngine;

public class BasicAttack : MonoBehaviour
{

    private Collider2D collider;

    public GameObject basicAttack;

    // 싱글톤 인스턴스
    public static BasicAttack Instance { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;

        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(GameObject targetObject)
    {
        basicAttack.SetActive(true);

        Rigidbody2D attackRigidBody = basicAttack.GetComponent<Rigidbody2D>();

        Vector3 direction = (targetObject.transform.position - basicAttack.transform.position).normalized;

        attackRigidBody.AddForce(direction * 10f, ForceMode2D.Impulse);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("적 공격 당함");
            basicAttack.SetActive(false);
            basicAttack.transform.position = transform.position;

            GameObject targetEnemy = other.gameObject;
            int towerAttackPower = TowerManager.Instance.GetTowerAttackPower();
            targetEnemy.GetComponent<EnemyHealth>().TakeDamage(towerAttackPower, targetEnemy);
        }
    }
}
