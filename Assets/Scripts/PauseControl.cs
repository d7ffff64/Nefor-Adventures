using System;
using CharacterScripts;
using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(CharacterInput))]
    public class PauseControl : MonoBehaviour
    {
        public event Action OnPauseEvent;
        
        private CharacterInput _characterInput;
        public bool IsPaused { get; private set; }
        
        private CharacterInputActions _characterInputActions;
        private void Awake()
        {
            _characterInput = GetComponent<CharacterInput>();
            
            _characterInputActions = new CharacterInputActions();
            
            _characterInputActions.UI.Pause.performed += callbackContext => Pause();
        }
        private void OnEnable()
        {
            _characterInput.OnPauseEvent += Pause;
        }
        private void OnDisable()
        {
            _characterInput.OnPauseEvent -= Pause;
        }
        private void Pause()
        {
            OnPauseEvent.Invoke();
            
            IsPaused = !IsPaused;
            
            if (IsPaused)
            {
                Time.timeScale = 0;
                AudioListener.pause = true;
            }
            else
            {
                Time.timeScale = 1;
                AudioListener.pause = false;
            }
        }
    }
}