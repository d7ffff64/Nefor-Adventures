using System;
using Scripts;
using UnityEngine;

namespace CharacterScripts
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CharacterInput), typeof(PauseControl))]
    public class CharacterMovement : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float _movementSpeed;
        
        [Header("Jump Settings")]
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private float _jumpForce;
        
        [Header("Jump References")]
        [SerializeField] private Transform _groundCheck;
        
        private CharacterInput _characterInput;
        private PauseControl _pauseControl;
        private Rigidbody2D _rigidbody2D;
        public bool IsFacingRight { get; private set; } = true;
        private void Awake()
        {
            _characterInput = GetComponent<CharacterInput>();
            _pauseControl = GetComponent<PauseControl>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void OnEnable()
        {
            _characterInput.OnJumpEvent += Jump;
        }
        private void Update()
        {
            if (!_pauseControl.IsPaused)
            {
                Move();
                FlipUpdate();
            }
        }
        private void OnDisable()
        {
            _characterInput.OnJumpEvent -= Jump;
        }
        private void Move()
        {
            _rigidbody2D.velocity = new Vector2(_characterInput.MovementAxis.x * _movementSpeed, _rigidbody2D.velocity.y);
        }
        public bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayerMask);
        }
        private void FlipUpdate()
        {
            if (_characterInput.MovementAxis.x > 0 && !IsFacingRight)
            {
                Flip();
            }
            else if (_characterInput.MovementAxis.x < 0 && IsFacingRight)
            {
                Flip();
            }
        }
        public void Jump()
        {
            if (IsGrounded())
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            }
        }
        private void Flip()
        {
            transform.Rotate(0f, 180f, 0f);
            
            IsFacingRight = !IsFacingRight;
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Platform"))
            {
                if (other.transform != null)
                {
                    transform.parent = other.transform;
                }
            }
        }
        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Platform"))
            {
                if (other.transform != null)
                {
                    transform.parent = null;
                }
            }
        }
    }
}