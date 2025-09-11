using UnityEngine;

public interface IGun
{
    void Shoot(Vector2 direction);
    float FireRate { get; }
}
