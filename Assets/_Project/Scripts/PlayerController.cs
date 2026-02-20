
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UnitData _data;

    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private Transform _muzzle;




    private Vector2 _moveInput;
    private Vector2 _mousePosition;
    private Camera _mainCamera;

    void Awake()
    {
        _mainCamera = Camera.main; //Кэшируем камеру для производительности   
    }

    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            Shoot();
        }
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        _mousePosition = value.Get<Vector2>();
    }


    // InputValue value - Это специальный «контейнер» (объект-обертка), который Unity присылает вместе с событием. Внутри него лежат данные о нажатии.

    void Start()
    {

    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        Vector3 direction = new Vector3(_moveInput.x, 0, _moveInput.y);
        transform.Translate(direction * _data.Speed * Time.deltaTime, Space.World);
    }

    private void HandleRotation()
    {
        Ray ray = _mainCamera.ScreenPointToRay(_mousePosition);

        Plane groundPlane = new Plane(Vector3.up, transform.position);

        if (groundPlane.Raycast(ray, out float rayDistance))
        {
            Vector3 hitPoint = ray.GetPoint(rayDistance);

            Vector3 lookDirection = hitPoint - transform.position;
            lookDirection.y = 0;

            if (lookDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_prefabBullet, _muzzle.position, _muzzle.rotation);
        Debug.Log(_muzzle.position);
    }

}
