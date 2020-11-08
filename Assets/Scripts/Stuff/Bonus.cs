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
        private const float _interval = 7;
        private RawImage icon;
        private Texture transpImage;
        private Texture trollImage;
        private Texture timerImage;
        private Texture maskImage;
        private Texture sprayImage;

        private void Awake()
        {
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
            StartCoroutine(CoroutineGiveMoreTime());
        }

        public void KillAllViruses(GameObject go)
        {
            var allViruses = GameObject.FindGameObjectsWithTag("virusagent");
            foreach (var virus in allViruses)
            {
               Destroy(virus);
            }
            icon.texture = sprayImage;
            StartCoroutine(CoroutineKillAllViruses(go));
        }
        
        public void ReduceSpeed(Player player, GameObject bonusCollided)
        {
            bonusCollided.GetComponent<MeshRenderer>().enabled = false;
            bonusCollided.GetComponent<SphereCollider>().enabled = false;
            icon.texture = trollImage;
            StartCoroutine(CoroutineReduceSpeed(player,bonusCollided));
        }

        public void GiveInvincibility(Player player, GameObject bonusCollided)
        {
            bonusCollided.GetComponent<MeshRenderer>().enabled = false;
            bonusCollided.GetComponent<SphereCollider>().enabled = false;
            icon.texture = maskImage;
            StartCoroutine(CoroutineGiveInvincibility(player,bonusCollided));
        }
        
        private IEnumerator CoroutineGiveMoreTime()
        {
            print("before yielded");
            yield return new WaitForSeconds(1);
            print("yielded");
            icon.texture = transpImage;
            // go.SetActive(false);
        }
        
        private IEnumerator CoroutineKillAllViruses(GameObject go)
        {
            yield return new WaitForSeconds(1);
            icon.texture = transpImage;
        }
        
        private IEnumerator CoroutineReduceSpeed(Player player, GameObject bonusCollided)
        {
            var initialSpeed = player.Speed;
            player.Speed -= _random.Next(1, 4);
            yield return new WaitForSeconds(3);
            player.Speed = initialSpeed;
            icon.texture = transpImage;
        }

        private IEnumerator CoroutineGiveInvincibility(Player player, GameObject bonusCollided)
        {
            player.Invincible = true;
            yield return new WaitForSeconds(_interval);
            player.Invincible = false;
            icon.texture = transpImage;
        }
    }
}