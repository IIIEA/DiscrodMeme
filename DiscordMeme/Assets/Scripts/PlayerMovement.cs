using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rayLenght;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private Vector3 _moveDirection;
    private bool _isMoving;
    private bool _isRotates;

    private const string Up = "Up";
    private const string Down = "Down";
    private const string Left = "Left";
    private const string Right = "Right";

    private void Update()
    {
        if (_isRotates)
        {
            if(Vector3.Angle(Vector3.forward, _moveDirection)>1f || Vector3.Angle(Vector3.forward, _moveDirection) == 0f)
            {
                transform.rotation = Quaternion.LookRotation(_moveDirection);
                _isRotates = false;
            }
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
            case Up:
                _moveDirection = (Vector3.forward);
                if (!Physics.Raycast(_rayPoint.position, Vector3.forward, _rayLenght))
                {
                    _targetPosition = transform.position + Vector3.forward;
                    _startPosition = transform.position;
                    _isMoving = true;
                }
                _isRotates = true;
                break;

            case Down:
                _moveDirection = (Vector3.back);
                if (!Physics.Raycast(_rayPoint.position, Vector3.back, _rayLenght))
                {
                    _targetPosition = transform.position + Vector3.back;
                    _startPosition = transform.position;
                    _isMoving = true;
                }
                _isRotates = true;
                break;

            case Left:
                _moveDirection = (Vector3.left);
                if (!Physics.Raycast(_rayPoint.position, Vector3.left, _rayLenght))
                {
                    _targetPosition = transform.position + Vector3.left;
                    _startPosition = transform.position;
                    _isMoving = true;
                }
                _isRotates = true;
                break;

            case Right:
                _moveDirection = (Vector3.right);
                if (!Physics.Raycast(_rayPoint.position, Vector3.right, _rayLenght))
                {
                    _targetPosition = transform.position + Vector3.right;
                    _startPosition = transform.position;
                    _isMoving = true;
                }
                _isRotates = true;
                break;
        }
    }
}
