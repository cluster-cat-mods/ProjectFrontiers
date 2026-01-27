using UnityEngine;
using TMPro;
using System;

public class TimerScript : MonoBehaviour
{
    private bool timerActive = false;
    private float currentTime;
    [SerializeField] private TMP_Text timerUI;
    [SerializeField] FloatVariable floatVariable;
    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime = currentTime + Time.deltaTime;
            floatVariable.Float = currentTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);  
        timerUI.text = time.Minutes.ToString() + ": " + time.Seconds.ToString() + ": " + time.Milliseconds.ToString();
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}
