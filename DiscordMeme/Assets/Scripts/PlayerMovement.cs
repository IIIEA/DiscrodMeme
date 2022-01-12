using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }

    public void MoveUp()
    {
        SetNextPositionZ(_stepSize);
    }

    public void MoveDown()
    {
        SetNextPositionZ(-_stepSize);
    }

    public void MoveRight()
    {

        SetNextPositionX(_stepSize);

    }

    public void MoveLeft()
    {
        SetNextPositionX(-_stepSize);
    }

    private void SetNextPositionX(float stepSize)
    {
        _targetPosition = new Vector3(_targetPosition.x + stepSize, _targetPosition.y, _targetPosition.z);
    }

    private void SetNextPositionZ(float stepSize)
    {
        _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y, _targetPosition.z + stepSize);
    }
}
