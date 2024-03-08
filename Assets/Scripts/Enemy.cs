using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Enemy : Personage
{
    private const int _minPointsNumber = 4;
    private const int _maxPointsNumber = 6;

    protected override void Start()
    {
        _animator = GetComponent<Animator>();
        _healthBar.value = _health;
    }

    public override void DeterminNumberOfTechniques()
    {
        _numberOfTechniques = Random.Range(_minPointsNumber, _maxPointsNumber);
    }

    public override void DistributePoints()
    {
        _numberOfAttaks = System.Convert.ToInt32(_numberOfTechniques * Random.value);
        _numberOfBlocks = _numberOfTechniques - _numberOfAttaks;

        MakeBattlePlan();
    }
}
