using System;
using UnityEngine;

namespace CharacterScripts
{
    public class CharacterInput : MonoBehaviour
    {
        public event Action OnJumpEvent;
        public event Action OnPauseEvent;
        public Vector2 MovementAxis { get; private set; }
        public bool IsMoving { get; private set; }
        
        private CharacterInputActions _characterInputActions;

        private void Awake()
        {
            _characterInputActions = new CharacterInputActions();
            
            _characterInputActions.Player.Jump.performed += callbackContext => OnJump();
            _characterInputActions.UI.Pause.performed += callbackContext => OnPause();
        }
        private void Update()
        {
            OnMove();
        }
        private void OnEnable()
        {
            _characterInputActions.Enable();
        }
        private void OnDisable()
        {
            _characterInputActions.Disable();
        }
        private void OnMove()
        {
            MovementAxis = _characterInputActions.Player.Move.ReadValue<Vector2>();
            IsMoving = MovementAxis != Vector2.zero;
        }
        private void OnJump()
        {
            OnJumpEvent?.Invoke();
        }
        private void OnPause()
        {
            OnPauseEvent?.Invoke();
        }
    }
}