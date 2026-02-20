using UnityEngine;

public class Health : MonoBehaviour
{
    private float _currentHealth;
    [SerializeField] private UnitData _data;
    void Start()
    {
        _currentHealth = _data.Health;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        Debug.Log($"{gameObject.name} получил урон. ХП: {_currentHealth}");

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
