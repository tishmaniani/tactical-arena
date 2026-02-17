
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UnitData _data;

    private Vector2 _moveInput;

    private void OnMove(InputValue value) 
    {
        _moveInput = value.Get<Vector2>();
    }

// InputValue value - Это специальный «контейнер» (объект-обертка), который Unity присылает вместе с событием. Внутри него лежат данные о нажатии.

    void Start()
    {

    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 movement = new Vector3(_moveInput.x, 0, _moveInput.y) * _data.Speed * Time.deltaTime;
        transform.Translate(movement);
    }

}
