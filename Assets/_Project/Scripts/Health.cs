using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private Slider _healthSlider;

    private float _currentHealth;
    [SerializeField] private UnitData _data;
    void Start()
    {
        _currentHealth = _data.Health;
        UpdateUI();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        UpdateUI();

       Debug.Log($"{gameObject.name} получил урон. ХП: {_currentHealth}");

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateUI()
    {
        if (_healthSlider != null)
        {
            _healthSlider.value = _currentHealth / _maxHealth;
        }
    }

    private void Die()
    {

        Debug.Log($"{gameObject.name} + погиб");

        Destroy(gameObject);
    }

}
