using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Personage
{
    [SerializeField] private Cube _cube1;
    [SerializeField] private Cube _cube2;
    [SerializeField] protected Slider _strategyScale;

    protected override void Start()
    {
        _animator = GetComponent<Animator>();
        _healthBar.value = _health;
    }

    public override void DeterminNumberOfTechniques() 
    {
        _numberOfTechniques = _cube1.DeterminRollResult() + _cube2.DeterminRollResult();
    }

     public override void DistributePoints() 
     {
         _numberOfAttaks =  System.Convert.ToInt32(_numberOfTechniques * _strategyScale.value);
         _numberOfBlocks = _numberOfTechniques - _numberOfAttaks;

        MakeBattlePlan();
     }
}
