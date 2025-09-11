using UnityEngine;

public class Pistol : GunBase
{
    private Rigidbody2D playerRb;

    private void Awake()
    {
        playerRb = transform.root.GetComponent<Rigidbody2D>();
    }

    public override void Shoot(Vector2 direction)
    {
        if (Time.time - _lastShootTime < _fireRate) return;
        _lastShootTime = Time.time;

        float spawnOffset = 0.2f;
        Vector3 spawnPos = _firePoint.position + (Vector3)direction.normalized * spawnOffset;
        Bullet bullet = Instantiate(_bulletPrefab, spawnPos, Quaternion.identity);
        bullet.Init(direction).Forget();
    }
}
