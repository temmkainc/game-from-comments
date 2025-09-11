using System;
using UnityEngine;

namespace Comments.Level
{
    public class DeathZone : MonoBehaviour
    {
        public event Action PlayerEnteredEvent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out var player))
            {
                PlayerEnteredEvent?.Invoke();
            }
        }
    }
}
