using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _snapDistance;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private bool _isMoving;

    private void Update()
    {
        if (_isMoving)
        {
            if(Vector3.Distance(_startPosition, transform.position) > 1f)
            {
                transform.position = _targetPosition;
                _isMoving = false;
                return;
            }

            transform.position += (_targetPosition - _startPosition) * _movementSpeed * Time.deltaTime;
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _targetPosition = transform.position + Vector3.forward;
            _startPosition = transform.position;
            _isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _targetPosition = transform.position + Vector3.back;
            _startPosition = transform.position;
            _isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _targetPosition = transform.position + Vector3.left;
            _startPosition = transform.position;
            _isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _targetPosition = transform.position + Vector3.right;
            _startPosition = transform.position;
            _isMoving = true;
        }
    }
}
