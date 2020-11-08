using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = System.Random;

namespace Stuff
{
    public class Bonus : MonoBehaviour
    {
        private Random _random;
        private float _interval;
        private GameObject _canvas;
        private RawImage icon;

        private void Awake()
        {
            _interval = 10;
            _random = new Random();
            _canvas = GameObject.FindWithTag("canvas");
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
        
        public void ReduceSpeed(Player player, GameObject bonusCollided)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            StartCoroutine(CoroutineReduceSpeed(player,bonusCollided));
        }
        
        private IEnumerator CoroutineReduceSpeed(Player player, GameObject bonusCollided)
        {
            var initialSpeed = player.Speed;
            player.Speed -= _random.Next(1, 4);
            yield return new WaitForSeconds(2);
            player.Speed = initialSpeed;
            bonusCollided.SetActive(false);
        }

        public void GiveInvincibility(Player player, GameObject bonusCollided)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            StartCoroutine(CoroutineGiveInvincibility(player,bonusCollided));
        }

        private IEnumerator CoroutineGiveInvincibility(Player player, GameObject bonusCollided)
        {
            player.Invincible = true;
            yield return new WaitForSeconds(_interval);
            player.Invincible = false;
            bonusCollided.SetActive(false);
        }
    }
}