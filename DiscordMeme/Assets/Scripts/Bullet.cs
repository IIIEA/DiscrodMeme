﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 10f);
    }
}
