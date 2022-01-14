using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _speed;

    private PlayerData _playerData;
    private Collider _collider;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _playerData = GetComponentInParent<PlayerData>();

        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;

        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerData>(out PlayerData playerData))
        {
            if(playerData.Index != this._playerData.Index)
            {
                playerData.ApplyDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
