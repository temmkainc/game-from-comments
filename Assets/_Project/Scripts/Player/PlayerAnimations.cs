using UnityEngine;

namespace Comments.Player
{
    public class PlayerAnimations : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _visuals;

        private PlayerMovement _movement;

        private bool _wasGroundedLastFrame;

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
            _movement.JumpEvent += On_PlayerJump;
        }

        private void OnDestroy()
        {
            _movement.JumpEvent -= On_PlayerJump;
        }

        private void FixedUpdate()
        {
            float speed = Mathf.Abs(_movement.InputX);
            bool isRunning = speed > 0.01f;
            _animator.SetBool("IsRunning", isRunning);

            bool isGrounded = _movement.IsGrounded;
            if (!_wasGroundedLastFrame && isGrounded)
            {
                Debug.Log("Landed");
                _animator.SetTrigger("Land");
            }

            _animator.SetBool("IsRunning", isRunning);
            _animator.SetBool("IsGrounded", isGrounded);
            _wasGroundedLastFrame = isGrounded;

            if (_movement.InputX > 0.01f)
                _visuals.localScale = new Vector3(1, 1, 1);
            else if (_movement.InputX < -0.01f)
                _visuals.localScale = new Vector3(-1, 1, 1);
        }

        private void On_PlayerJump()
        {
            _animator.SetTrigger("Jump");
        }
    }
}
