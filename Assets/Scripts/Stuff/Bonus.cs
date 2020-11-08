using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
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
        private RawImage icon;
        private Texture transpImage;
        private Texture trollImage;
        private Texture timerImage;
        private Texture maskImage;
        private Texture sprayImage;

        private void Awake()
        {
            _startCoroutine = false;
            _player = null;
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
        
        public void ReduceSpeed(Player player)
        {
            player.Speed -= _random.Next(2, 4);
            icon.texture = maskImage;
        }

        public void GiveInvincibility(Player player, GameObject bonusCollided)
        {
            print(player.GetInstanceID() + " hashcode : " + player.GetHashCode());
            _player = player;
            GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Texture>();
            icon.texture = trollImage;
            StartCoroutine(Invincible(bonusCollided));
        }

        private IEnumerator Invincible(GameObject bonusCollided)
        {
            _player.SetInvincible(true);
            yield return new WaitForSeconds(_interval);
            _player.SetInvincible(false);
            bonusCollided.SetActive(false);
        }
    }
}