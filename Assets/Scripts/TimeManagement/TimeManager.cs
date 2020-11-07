using UnityEngine;

namespace TimeManagement
{
    public class TimeManager : MonoBehaviour
    {
        private float _countDown;
        public float CountDown => _countDown;
        private void Awake()
        {
            _countDown = 60;
        }

        private void Update()
        {
            SetCountDown(-Time.deltaTime);
            /*if(_countDown == 0)
                Destroy(GetComponent<Player>());
                */
        }

        public void SetCountDown(float val)
        {
            _countDown += val;
            print(_countDown);
        }
    }
}
