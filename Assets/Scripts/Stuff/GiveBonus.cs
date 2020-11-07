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
            GenerateRandomBonus();
            gameObject.SetActive(false);
        }

        private void GenerateRandomBonus()
        {
            switch (_random.Next(1,3))
            {
                case 1 :
                    _bonus.GiveMoreTime();
                    break;
                case 2 :
                    _bonus.ReduceSpeed();
                    break;
            }
        }
    }
}
