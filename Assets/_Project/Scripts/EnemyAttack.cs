using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
   [SerializeField] private UnitData _dataEnemy;
    private float _attackCooldown = 1.0f;
    private float _lastAttackTime;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
        Debug.Log("Работает??");
            if(Time.time >= _lastAttackTime + _attackCooldown)
            {
                Health playerHealth = collision.gameObject.GetComponent<Health>();
                if(playerHealth != null)
                {
                    playerHealth.TakeDamage(_dataEnemy.Damage);

                    Debug.Log(playerHealth);

                    _lastAttackTime = Time.time;
                    Debug.Log("Враг укусил игрока");
                }
            }
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
