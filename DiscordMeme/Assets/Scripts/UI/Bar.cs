using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider _slider;

    private float _delayToFill = 0.3f;

    private void Start()
    {
        _slider.value = _slider.maxValue;
    }

    protected void OnHealthChanged(int value, int maxValue)
    {
        if (maxValue != 0)
            _slider.DOValue((float)value / maxValue, _delayToFill);
    }
}
