using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class Cube: MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _targetPosition;

    private float _timeForPrepare = 0.2f;
    private float _timeForMove = 1f;
    private float _timeFoRotate = 0.1f;
    private Vector3 _cubeStartRotationValue = new Vector3(0, 0, 0);
    private int[] _rotationValuesByX = { 0, 90, 180, 270 };
    private int[] _rotationValuesByZ = { 0, 90, 270 };
    private Vector3 _rotationResult;
    private int _rotationByX;
    private int _rotationByY;
    private int _rotationByZ;
    private int _rollResult;

    public void PrepareToRoll()
    {
        transform.DOMove(_startPosition, _timeForPrepare);
        transform.DORotate(_cubeStartRotationValue, _timeFoRotate);
    }

    public void RollDice()
    {
        transform.DOMove(_targetPosition, _timeForMove).SetEase(Ease.OutBounce);
        transform.DORotate(_rotationResult, _timeForMove);
    }

    public void DeterminAngle()
    {
        _rotationByX = _rotationValuesByX[Random.Range(0, _rotationValuesByX.Length)];
        _rotationByZ = _rotationValuesByZ[Random.Range(0, _rotationValuesByZ.Length)];
        _rotationByY = 0;
        _rotationResult = new Vector3(_rotationByX, _rotationByY, _rotationByZ);

        DeterminRollResult();
    }

    public int DeterminRollResult() 
    {
        if(_rotationResult.z != 0 && _rotationResult.x == 180 || _rotationResult.x == 0) 
        {
            _rollResult = 3;
        }
        else 
        {
            _rollResult = 2;
        }

        return _rollResult;
    }
}
