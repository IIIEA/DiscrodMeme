using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Player _player;

    private string _index;
    private string _nickName;

    public string Index => _index;
    public string Name => _nickName;

    public void Init(string index, string nickName)
    {
        _index = index;
        _nickName = nickName;
    }

    public void Move(string direction)
    {
        _playerMovement.Move(direction);
    }

    public void ApplyDamage(int damage)
    {
        _player.ApplyDamage(damage);
    }

    public void Shoot()
    {
        _player.Shoot();
    }
}
