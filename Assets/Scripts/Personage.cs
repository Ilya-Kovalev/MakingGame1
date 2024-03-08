using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Personage : MonoBehaviour
{
    [SerializeField] protected Slider _healthBar;
    [SerializeField] protected float _health;

    protected Animator _animator;
    protected int _numberOfTechniques;
    protected int _numberOfAttaks;
    protected int _numberOfBlocks;
    protected List<string> _tecniques = new List<string>();

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
        _healthBar.value = _health;
    }

    public List<string> MakeBattlePlan()
    {
        _tecniques.Clear();

        while(_numberOfAttaks > 0 || _numberOfBlocks > 0) 
        {
            if(_numberOfAttaks > 0) 
            {
                _tecniques.Add("Attack");
                _numberOfAttaks -= 1;
            }
            if(_numberOfBlocks > 0) 
            {
                _tecniques.Add("Block");
                _numberOfBlocks -= 1;
            }
        }
        return _tecniques;
    }

    public abstract void DeterminNumberOfTechniques();

    public abstract void DistributePoints();

    public void StopAttak()
    {
        _animator.SetBool("IsHit", false);
    }

    public void StopProtection()
    {
        _animator.SetBool("IsProtecting", false);
    }

    public void ExecuteBattlePlan()
    {
        if(_tecniques[0] == "Attack") {
            _animator.SetBool("IsHit", true);
        }
        else if(_tecniques[0] == "Block") {
            _animator.SetBool("IsProtecting", true);
        }
        _tecniques.RemoveAt(0);
    }

    public bool IsCanFight()
    {
        return _tecniques.Count > 0;
    }

    public bool CanChangeAnimation()
    {
        return
            !_animator.GetBool("IsHit") &&
            !_animator.GetBool("IsProtecting");
    }
}
