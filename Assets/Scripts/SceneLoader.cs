using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        public SceneLoader Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void LoadArena()
        {
            LoadScene("Arena");
        }
        public void LoadMainMenu()
        {
            LoadScene("MainMenu");
        }
        public void LoadDayOne()
        {
            LoadScene("DayOne");
        }
        public void LoadNightOne()
        {
            LoadScene("NightOne");
        }
        private void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
