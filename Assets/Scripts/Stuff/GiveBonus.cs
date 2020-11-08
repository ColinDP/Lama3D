using System;
using UnityEngine;
using Random = System.Random;

namespace Stuff
{
    public class GiveBonus : MonoBehaviour
    {

        private Bonus _bonus;
        private Random _random;

        private void Awake()
        {
            _random = new Random();
            _bonus = GameObject.FindWithTag("gameManager").AddComponent<Bonus>();
        }

        private void OnCollisionEnter(Collision other)
        {
            GenerateRandomBonus(other.rigidbody.GetComponent<Player>());
        }

        private void GenerateRandomBonus(Player player)
        {
            switch (_random.Next(1,5))
            {
                case 1 :
                    _bonus.GiveMoreTime();
                    gameObject.SetActive(false);
                    break;
                case 2 :
                    _bonus.ReduceSpeed(player, gameObject);
                    gameObject.SetActive(false);
                    break;
                case 3 :
                    _bonus.GiveInvincibility(player, gameObject);
                    gameObject.SetActive(false);
                    break;
                case 4 :
                    _bonus.KillAllViruses(gameObject);
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
}
