using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace Stuff
{
    public class Bonus : MonoBehaviour
    {
        private Random _random;
        private float _interval;
        private bool _startCoroutine;
        private Player _player;

        private void Awake()
        {
            _startCoroutine = false;
            _player = null;
            _interval = 10;
            _random = new Random();
        }

        private void Update()
        {
            print(_startCoroutine);
            if (_startCoroutine)
            {
                StartCoroutine(Invincible());
            }
        }

        public void GiveMoreTime()
        {
            GameManager.GameManager.Instance.TimeManager.SetCountDown(_random.Next(10, 45));
        }
    
        public void ReduceSpeed(Player player)
        {
            player.Speed -= _random.Next(2, 4);
        }
    
        public void GiveInvincibility(Player player)
        {
            _startCoroutine = true;
            _player = player;
        }

        private IEnumerator Invincible()
        {
            _player.SetInvincible(true);
            print("DEBUUUUUT");
            yield return new WaitForSeconds(_interval);
            _player.SetInvincible(false);
            _startCoroutine = false;
            print("FIIIIIN");
        }
    

    }
}