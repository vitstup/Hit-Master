using UnityEngine;

public class Bullet : MonoBehaviour, IResatable
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float maxLifeTime;

    private float currentLifeTime;

    public void Shoot(Vector3 target)
    {
        transform.LookAt(target);

        currentLifeTime = maxLifeTime;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        currentLifeTime -= Time.deltaTime;

        if (currentLifeTime <= 0) DeActivate();
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();

        if (damagable != null) damagable.Damage(damage);

        Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();

        if (otherRigidbody != null)
        {
            Vector3 forceDirection = other.transform.position - transform.position;
            forceDirection.Normalize();

            otherRigidbody.AddForce(forceDirection * 1f, ForceMode.Impulse);
        }

        DeActivate();
    }

    private void DeActivate()
    {
        gameObject.SetActive(false);
    }

    public void ResetAll()
    {
        DeActivate();
    }
}