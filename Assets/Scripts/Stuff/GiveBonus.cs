using System;
using UnityEngine;
using Random = System.Random;

namespace Stuff
{
    public class GiveBonus : MonoBehaviour
    {

        private Bonus _bonus;
        private Random _random;
        private GameObject bonusCollided;

        private void Awake()
        {
            _random = new Random();
            _bonus = gameObject.AddComponent<Bonus>();
        }

        private void OnCollisionEnter(Collision other)
        {
            print(other.rigidbody.GetComponent<Player>().GetInstanceID() + " hashcode : " + other.rigidbody.GetComponent<Player>().GetHashCode());
            bonusCollided = gameObject;
            GenerateRandomBonus(other.rigidbody.GetComponent<Player>(), bonusCollided);
        }

        private void GenerateRandomBonus(Player player, GameObject bonusCollided)
        {
            switch (_random.Next(1,5))
            {
                case 1 :
                    _bonus.GiveMoreTime();
                    gameObject.SetActive(false);
                    break;
                case 2 :
                    _bonus.ReduceSpeed(player);
                    gameObject.SetActive(false);
                    break;
                case 3 :
                    _bonus.GiveInvincibility(player, bonusCollided);
                    break;
                case 4 :
                    _bonus.KillAllViruses();
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
}
