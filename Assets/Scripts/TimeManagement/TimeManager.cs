﻿using System;
using UnityEngine;

namespace TimeManagement
{
    public class TimeManager : MonoBehaviour
    {
        private float _countDown;
        public float CountDown => _countDown;
        public Action<float> onCountDownChange;
        private void Awake()
        {
            _countDown = 60;
        }

        private void Update()
        {
            if(_countDown <0.5)
                GameManager.GameManager.Instance.LoadScene("GameOver");
            else
                SetCountDown(-Time.deltaTime);
        }

        public void SetCountDown(float val)
        {
            _countDown += val;
            onCountDownChange(_countDown);
        }
    }
}
