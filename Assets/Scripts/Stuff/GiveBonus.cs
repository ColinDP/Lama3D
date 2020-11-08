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
            _bonus = gameObject.AddComponent<Bonus>();
        }

        private void OnCollisionEnter(Collision other)
        {
            GenerateRandomBonus(other.rigidbody.GetComponent<Player>());
            gameObject.SetActive(false);
        }

        private void GenerateRandomBonus(Player player)
        {
            switch (_random.Next(3,4))
            {
                case 1 :
                    _bonus.GiveMoreTime();
                    break;
                case 2 :
                    _bonus.ReduceSpeed(player);
                    break;
                case 3 :
                    _bonus.GiveInvincibility(player);
                    break;
            }
        }
    }
}
