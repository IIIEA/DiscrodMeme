using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string _index;
    private string _nickName;

    public void Init(string index, string nickName)
    {
        _index = index;
        _nickName = nickName;
    }
}
