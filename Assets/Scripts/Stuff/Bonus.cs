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
        private GameObject canvas;
        private Sprite currentBonusSprite;

        private void Awake()
        {
            _startCoroutine = false;
            _player = null;
            _interval = 10;
            _random = new Random();
            // canvas = GameObject.FindWithTag("canvas");
            // currentBonusSprite = canvas.transform.Find("Icon").GetComponent<SpriteRenderer>().sprite;
        }

        private void Update()
        {
            // if (_startCoroutine)
            // {
            //     StartCoroutine(Invincible());
            // }
        }

        public void GiveMoreTime()
        {
            GameManager.GameManager.Instance.TimeManager.SetCountDown(_random.Next(10, 45));
        }


        public void KillAllViruses()
        {
            var allViruses = GameObject.FindGameObjectsWithTag("virusagent");
            foreach (var virus in allViruses)
            {
               Destroy(virus);
            }
        }
        
        
        
        public void ReduceSpeed(Player player)
        {
            player.Speed -= _random.Next(2, 4);
        }
    
        public void GiveInvincibility(Player player, GameObject bonusCollided)
        {
            print(player.GetInstanceID() + " hashcode : " + player.GetHashCode());
            _player = player;
            // _startCoroutine = true;
            GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(Invincible(bonusCollided));
        }

        private IEnumerator Invincible(GameObject bonusCollided)
        {
            _player.SetInvincible(true);
            print("DEBUUUUUT");
            currentBonusSprite = null;
            yield return new WaitForSeconds(_interval);
            _player.SetInvincible(false);
            _startCoroutine = false;
            print("FIIIIIN");
            bonusCollided.SetActive(false);
        }
        
    }
}