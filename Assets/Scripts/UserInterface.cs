using System;
using CharacterScripts;
using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(PauseControl))]
    public class UserInterface : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private GameObject _pauseMenu;

        private PauseControl _pauseControl;
        private void Awake()
        {
            _pauseControl = GetComponent<PauseControl>();
        }
        private void OnEnable()
        {
            _pauseControl.OnPauseEvent += PauseMenu;
        }
        private void OnDisable()
        {
            _pauseControl.OnPauseEvent -= PauseMenu;
        }
        private void PauseMenu()
        {
            if (_pauseMenu.activeInHierarchy)
            {
                _pauseMenu.SetActive(false);
            }
            else
            {
                _pauseMenu.SetActive(true);
            }
        }
    }
}