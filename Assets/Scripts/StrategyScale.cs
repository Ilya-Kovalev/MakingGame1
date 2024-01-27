using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrategyScale : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _minValue = 0;
    private float _maxValue = 1;
    private float _sizeOfChange = 0.1f;
    private int _indexOfChange = 1;
    private Coroutine _sliderCorutine;

    private IEnumerator DetermineStrategyScaleValue()
    {
        _slider.value += _sizeOfChange * _indexOfChange;

        if(_slider.value <= _minValue) 
        {
            _indexOfChange = 1;
        }
        else if(_slider.value >= _maxValue) 
        {
            _indexOfChange = -1;
        }

        yield return null;

        StartDetermineStrategeScaleValue();
    }

    public void StartDetermineStrategeScaleValue()
    {
        _sliderCorutine = StartCoroutine(DetermineStrategyScaleValue());
    }

    public void StopDetermineStrategeScaleValue() 
    {
        StopCoroutine(_sliderCorutine);
    }
}
