using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Comments.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        public float InputX => _inputX;
        public bool IsGrounded => _isGrounded;
        public event Action JumpEvent;

        [Header("Movement Settings")]
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _jumpForce = 10f;

        [Header("Ground Check Settings")]
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundCheckRadius = 0.2f;
        [SerializeField] private LayerMask _groundLayer;

        private Rigidbody2D _rigidbody;
        private bool _isGrounded;
        private bool _jumpRequested;
        private float _inputX;

        private const float JOYSTICK_MOVEMENT_THRESHOLD = 0.01f;

        private PlayerInput _inputActions;

        private Joystick _joystick;
        private Button _jumpButton;

        [Inject]
        public void Construct(PlayerInputContainer inputContainer)
        {
            _joystick = inputContainer.Joystick;
            _jumpButton = inputContainer.JumpButton;
        }

        public void Stop()
        {
            _rigidbody.linearVelocity = Vector2.zero;
            _inputX = 0f;
            _jumpRequested = false;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _jumpButton.onClick.AddListener(On_JumpButtonPressed);

            _inputActions = new PlayerInput();

            _inputActions.Player.Move.performed += ctx => _inputX = ctx.ReadValue<Vector2>().x;
            _inputActions.Player.Move.canceled += ctx => _inputX = 0f;

            _inputActions.Player.Jump.performed += _ => _jumpRequested = true;
        }

        private void OnEnable() => _inputActions.Player.Enable();
        private void OnDisable() => _inputActions.Player.Disable();

        private void Update()
        {
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

            if (_joystick == null || Mathf.Abs(_joystick.Horizontal) <= JOYSTICK_MOVEMENT_THRESHOLD)
            {
                _inputX = 0f;
                return;
            }

            _inputX = _joystick.Horizontal;
        }

        private void FixedUpdate()
        {
            _rigidbody.linearVelocity = new Vector2(_inputX * _moveSpeed, _rigidbody.linearVelocity.y);

            if (_jumpRequested && _isGrounded)
            {
                _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, 0f);
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

                JumpEvent?.Invoke();
            }

            _jumpRequested = false;
        }

        private void On_JumpButtonPressed() => _jumpRequested = true;
    }
}