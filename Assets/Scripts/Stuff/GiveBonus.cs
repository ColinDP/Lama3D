using UnityEngine;

namespace Stuff
{
    public class GiveBonus : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            GameManager.GameManager.Instance.TimeManager.SetCountDown(3);
            gameObject.SetActive(false);
        }
    }
}
