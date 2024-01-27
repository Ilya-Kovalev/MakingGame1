using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Cube _cube1;
    [SerializeField] private Cube _cube2;
    [SerializeField] private Slider _playerBar;
    [SerializeField] private Slider _strategyScale;

    private Animator _animator;
    private float _health = 10;
    private int _numberOfTechniques;
    private int _numberOfAttaks;
    private int _numberOfBlocks;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerBar.value = _health;
    }

    public void DeterminNumberOfTechniques() 
    {
        _numberOfTechniques = _cube1.DeterminRollResult() + _cube2.DeterminRollResult();
    }

     public void DistributePoints() 
     {
         _numberOfAttaks =  System.Convert.ToInt32(_numberOfTechniques * _strategyScale.value);
         _numberOfBlocks = _numberOfTechniques - _numberOfAttaks;
        Debug.Log("At= " + _numberOfAttaks + " Bl= " + _numberOfBlocks);
     }

   /* public int DeterminNumberOfAttaks() 
    {
        _numberOfAttaks = System.Convert.ToInt32(_numberOfTechniques * _strategyScale.value);
        Debug.Log("attaks = " + _numberOfAttaks);
        return _numberOfAttaks;
    }

    public int DeterminNumberOfBlocks() 
    {
        _numberOfBlocks = _numberOfTechniques - _numberOfAttaks;
        Debug.Log("blocks = " + _numberOfBlocks);
        return _numberOfBlocks;
    }*/

   /* public void Attak() 
    {
        _animator.SetBool("IsHit",true);
    }*/

    public void StopAttak() 
    {
        _animator.SetBool("IsHit", false);
    }

   /* public void Protection() 
    {
        _animator.SetBool("IsProtecting", true);
    }*/

    public void StopProtection() 
    {
        _animator.SetBool("IsProtecting", false);

        Debug.Log("ZBC");
    }

    public void TryAttak() 
    {
        if(_numberOfAttaks > 0) 
        {
            _animator.SetBool("IsHit", true);
            _numberOfAttaks -= 1;
        }
    }

    public void TryProtection() 
    {
        if(_numberOfBlocks > 0) 
        {
            _animator.SetBool("IsProtecting", true);
            _numberOfBlocks -= 1;
            Debug.Log("WTF");
        }
    }

    public bool IsCanFight() 
    {
        return _numberOfAttaks > 0 || _numberOfBlocks > 0;
    }

    public bool CanChangeAnimation() 
    {
        return
            !_animator.GetBool("IsHit") &&
            !_animator.GetBool("IsProtecting");
    }
}
