using UnityEngine;

public abstract class GunBase : MonoBehaviour, IGun
{
    public float FireRate => _fireRate;

    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected float _fireRate = 0.25f;

    protected float _lastShootTime;

    public abstract void Shoot(Vector2 direction);
}
