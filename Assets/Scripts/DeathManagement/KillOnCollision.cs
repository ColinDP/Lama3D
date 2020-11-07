using UnityEngine;

namespace DeathManagement
{
    public class KillOnCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            other.rigidbody.GetComponent<IDeath>()?.OnDeath();
        }
    }
}
