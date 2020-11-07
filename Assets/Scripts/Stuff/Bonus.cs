using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Bonus : MonoBehaviour
{
    private Random _random;
    private Player _player;

    private void Awake()
    {
        _random = new Random();
        _player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
    }
    
    public void GiveMoreTime()
    {
        GameManager.GameManager.Instance.TimeManager.SetCountDown(_random.Next(10, 45));
    }
    
    
    //Malus
    public void ReduceSpeed()
    {
        if (_player != null)
        {
            print(_player.name);
            _player.Speed -= _random.Next(2, 4);
        }
    }
    

}