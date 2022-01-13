using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed = 0.1f;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private Vector3 _moveDirection;
    private bool _isMoving;
    private bool _isRotates;

    private void Update()
    {
        if (_isRotates)
        {
            if(Vector3.Angle(Vector3.forward, _moveDirection)>1f || Vector3.Angle(Vector3.forward, _moveDirection) == 0f)
            {
                Vector3 direction = Vector3.RotateTowards(transform.forward, _moveDirection, _movementSpeed, _rotationSpeed);
                _isRotates = false;
            }

            transform.rotation = Quaternion.LookRotation(_moveDirection);
        }

        if (_isMoving)
        {
            if (Vector3.Distance(_startPosition, transform.position) > 1f)
            {
                transform.position = _targetPosition;
                _isMoving = false;
                return;
            }

            transform.position += (_targetPosition - _startPosition) * _movementSpeed * Time.deltaTime;
            return;
        }
    }

    public void Move(string direction)
    {

        switch (direction)
        {
            case "Up":
                _moveDirection = (Vector3.forward);
                _targetPosition = transform.position + Vector3.forward;
                _startPosition = transform.position;
                _isMoving = true;
                _isRotates = true;
                break;
            case "Down":
                _moveDirection = (Vector3.back);
                _targetPosition = transform.position + Vector3.back;
                _startPosition = transform.position;
                _isMoving = true;
                _isRotates = true;
                break;
            case "Left":
                _moveDirection = (Vector3.left);
                _targetPosition = transform.position + Vector3.left;
                _startPosition = transform.position;
                _isMoving = true;
                _isRotates = true;
                break;
            case "Right":
                _moveDirection = (Vector3.right);
                _targetPosition = transform.position + Vector3.right;
                _startPosition = transform.position;
                _isMoving = true;
                _isRotates = true;
                break;
        }
    }
}
