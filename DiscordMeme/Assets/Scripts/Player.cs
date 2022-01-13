using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

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
}
