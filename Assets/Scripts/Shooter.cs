using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Vector3 shootPos;
    [SerializeField] private Bullet bulletPrefab;

    [SerializeField] private float timeBeetwenShoots;

    private BulletPool bulletPool;

    private float timer;

    private void Awake()
    {
        bulletPool = new BulletPool(bulletPrefab, 5, true);
    }

    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
    }

    public void Shoot(Vector3 target)
    {
        if (timer <= 0)
        {
            timer = timeBeetwenShoots;
            var bullet = bulletPool.GetElement();
            bullet.transform.position = transform.TransformPoint(shootPos);
            bullet.Shoot(target);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.TransformPoint(shootPos), 0.25f);
    }
}