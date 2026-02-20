using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
   
   [SerializeField] private UnitData _enemyData;
   private NavMeshAgent _agent;
   private Transform _player;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _agent.speed = _enemyData.Speed;
    }

   
    void Update()
    {
        if(_player != null)
        {
            _agent.SetDestination(_player.position);
        }
    }
}
