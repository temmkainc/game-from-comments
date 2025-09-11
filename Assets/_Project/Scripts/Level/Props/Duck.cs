using Comments.Level;
using UnityEngine;

public class Duck : MonoBehaviour
{
    [SerializeField] private GameObject _hat;

    private void Start()
    {
        bool hasHat = Random.value > 0.5f;
        _hat.SetActive(hasHat);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var player))
        {
            player.Health.ChangeHealth(-10);
        }
    }
}
