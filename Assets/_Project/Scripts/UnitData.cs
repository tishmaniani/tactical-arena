using UnityEngine;

[CreateAssetMenu(fileName = "NewUnitData", menuName = "TacticalArena/Unit Data")]
public class UnitData : ScriptableObject
{
    [SerializeField] private float _health = 100f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private int _damage = 10;
    [SerializeField] private Sprite _icon;


    public float Health => _health;
    public float Speed => _speed;
    public int Damage => _damage;
    public Sprite Icon => _icon;
}