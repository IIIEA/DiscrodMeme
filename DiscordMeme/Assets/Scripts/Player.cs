using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private Transform _shootPoint;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void Shoot()
    {
        Instantiate(_bulletTemplate, _shootPoint.position, transform.rotation, transform);
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
