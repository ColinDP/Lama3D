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
        private RawImage icon;
        private Texture transpImage;
        private Texture trollImage;
        private Texture timerImage;
        private Texture maskImage;
        private Texture sprayImage;

        private void Awake()
        {
            _interval = 10;
            _random = new Random();
            icon = GameObject.FindWithTag("icon").GetComponent<RawImage>();
        }

        private void Start()
        {
            transpImage = Resources.Load("Sprites/transp") as Texture;
            trollImage = Resources.Load("Sprites/troll-face") as Texture;
            timerImage = Resources.Load("Sprites/timer") as Texture;
            maskImage = Resources.Load("Sprites/mask") as Texture;
            sprayImage = Resources.Load("Sprites/spray") as Texture;
        }

        public void GiveMoreTime()
        {
            GameManager.GameManager.Instance.TimeManager.SetCountDown(_random.Next(10, 45));
            icon.texture = timerImage;
        }

        public void KillAllViruses()
        {
            var allViruses = GameObject.FindGameObjectsWithTag("virusagent");
            foreach (var virus in allViruses)
            {
               Destroy(virus);
            }
            icon.texture = sprayImage;
        }
        
        public void ReduceSpeed(Player player, GameObject bonusCollided)
        {
            icon.texture = maskImage;
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
            icon.texture = trollImage;
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