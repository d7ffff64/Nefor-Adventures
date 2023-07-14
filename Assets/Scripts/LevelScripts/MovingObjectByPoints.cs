using UnityEngine;

namespace LevelScripts
{
    public class MovingObjectByPoints : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _movementSpeed; 
        
        [Header("References")]
        [SerializeField] private Transform _startPosition;
        [SerializeField] private Transform _endPosition;

        private Vector3 _targetPosition;

        private void Start()
        {
            _targetPosition = _endPosition.position;
        }

        private void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);

            if (transform.position == _targetPosition)
            {
                if (_targetPosition == _endPosition.position)
                    _targetPosition = _startPosition.position;
                else
                    _targetPosition = _endPosition.position;
            }
        }
    }
}