using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class TimerScript : MonoBehaviour
{
    private bool timerActive = false;
    private float currentTime;
    [SerializeField] private List<TMP_Text> UIElements;
    [SerializeField] FloatVariable floatVariable;

    void Update()
    {
        if (timerActive)
        {
            currentTime = currentTime + Time.deltaTime;
            floatVariable.fl = currentTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);  
        foreach (var element in UIElements)
        {
            element.text = time.Minutes.ToString() + ": " + time.Seconds.ToString() + ": " + time.Milliseconds.ToString();
        }
        
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
