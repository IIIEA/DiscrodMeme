using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _nickName;
    [SerializeField] private PlayerData _playerData;

    void Start()
    {
        _nickName.text = _playerData.Name;
    }
}
