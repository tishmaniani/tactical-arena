using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private float _spawnRadius = 10f;
    
    void Start()
    {
        InvokeRepeating(nameof(Spawn), _spawnInterval, _spawnInterval);
    }

    private void Spawn()
    {
        Vector2 randomPoint = Random.insideUnitCircle * _spawnRadius;

        Vector3 spawnPosition = new Vector3(randomPoint.x, 0, randomPoint.y) + transform.position;

        Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
