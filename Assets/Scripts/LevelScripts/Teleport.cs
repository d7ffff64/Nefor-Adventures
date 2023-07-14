using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Teleport : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private Transform _toPosition;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.gameObject.transform.position = _toPosition.transform.position;
            }
        }
    }
}
