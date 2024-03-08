using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button button;

    private bool _isFight = false;

    public void Start()
    {
        
    }
    public void BeginFight() 
    {
        StartCoroutine(Combat());
    }

    private IEnumerator Combat() 
    {
        _player.ExecuteBattlePlan();

        yield return new WaitUntil(_player.CanChangeAnimation);

        if(_player.IsCanFight()) 
        {
            StartCoroutine(Combat()); 
        }      
    }
}
