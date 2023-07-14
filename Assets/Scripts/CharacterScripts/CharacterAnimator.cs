using System;
using Scripts;
using UnityEngine;

namespace CharacterScripts
{
    [RequireComponent(typeof(CharacterInput), typeof(CharacterMovement), typeof(PauseControl))]
    public class CharacterAnimator : MonoBehaviour
    {
        private CharacterInput _characterInput;
        private CharacterMovement _characterMovement;
        private PauseControl _pauseControl;
        private Animator _animator;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _characterInput = GetComponent<CharacterInput>();
            _characterMovement = GetComponent<CharacterMovement>();
            _pauseControl = GetComponent<PauseControl>();
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            if (!_pauseControl.IsPaused)
            {
                _animator.SetBool("IsRunning", _characterInput.IsMoving);
                if (_characterMovement.IsGrounded())
                {
                    _animator.SetBool("IsJumping", false);
                }
                else
                {
                    _animator.SetBool("IsJumping", true);
                }
            }
            _animator.SetFloat("VelocityY", _rigidbody2D.velocity.y);
        }
    }
}