using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _leftTime = 3f;


    void Start()
    {
        Destroy(gameObject, _leftTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(10);
            Destroy(gameObject);
        }
    }

}
