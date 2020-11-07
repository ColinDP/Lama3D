using TMPro;
using UnityEngine;

namespace TimeManagement
{
    [RequireComponent(typeof(TMP_Text))]
    public class TimeText : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

       /* private void OnEnable()
        {
            UpdateTime(GameManager.Instance.TimeManager.CountDown);
            GameManager.Instance.TimeManager.onScoreChange += UpdateTime;
        }*/

        private void UpdateTime(int value)
        {
            text.text = value.ToString();
        }
    }
}
