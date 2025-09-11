using UnityEngine;

public class Shotgun : GunBase
{
    [SerializeField] private int pellets = 5;
    [SerializeField] private float spread = 15f;

    public override void Shoot(Vector2 direction)
    {
        if (Time.time - _lastShootTime < _fireRate) return;

        _lastShootTime = Time.time;

        for (int i = 0; i < pellets; i++)
        {
            float angle = Random.Range(-spread, spread);
            Vector2 dir = Quaternion.Euler(0, 0, angle) * direction;

            Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = dir.normalized * 10f;
        }
    }
}
