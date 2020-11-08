using UnityEngine;

namespace DeathManagement
{
    public class KillOnCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if(!other.rigidbody.GetComponent<Player>().IsInvincible())
                other.rigidbody.GetComponent<IDeath>()?.OnDeath();
        }
    }
}
