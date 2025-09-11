using Cysharp.Threading.Tasks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed { get; private set; } = 20f;
    private Vector2 _direction;

    public async UniTaskVoid Init(Vector2 direction)
    {
        _direction = direction.normalized;
        transform.up = _direction;

        await UniTask.Yield();

        GetComponent<Rigidbody2D>().linearVelocity = _direction * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
