using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts
{
    public class ParallaxLayer : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private Vector3 _movementScale = Vector3.one;

        private Transform _camera;

        private void Awake()
        {
            _camera = Camera.main.transform;
        }
        private void LateUpdate()
        {
            transform.position = Vector3.Scale(_camera.position, _movementScale);
        }
    }   
}
