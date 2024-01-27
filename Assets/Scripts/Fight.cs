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
        BeginFight();
    }
    public void BeginFight() 
    {
        StartCoroutine(Combat());
        /* _isFight = true;

         while(_isFight) 
         {
             _player.TryAttak();
             _player.TryProtection();

             if(!_player.IsCanFight()) 
             {
                 _isFight = false;
             }
         }*/
    }

    private IEnumerator Combat() 
    {
        _player.TryAttak();
        _player.TryProtection();
        
        yield return new WaitUntil(_player.CanChangeAnimation);
        StartCoroutine(Combat());      
    }
}
