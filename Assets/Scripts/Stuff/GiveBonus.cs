using TimeManagement;
using UnityEngine;

namespace Stuff
{
    public class GiveBonus : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            other.gameObject.GetComponent<TimeManager>().SetCountDown(2*Time.deltaTime);
        }
    }
}
