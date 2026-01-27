using UnityEngine;
using TMPro;
using System;

public class TimerScript : MonoBehaviour
{
    private bool TimerActive = false;
    private float CurrentTime;
    [SerializeField] private TMP_Text TimerUI;
    void Start()
    {
        CurrentTime = 0;
    }

    void Update()
    {
        if (TimerActive)
        {
            CurrentTime = CurrentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);  
        TimerUI.text = time.Minutes.ToString() + ": " + time.Seconds.ToString() + ": " + time.Milliseconds.ToString();
    }

    public void StartTimer()
    {
        TimerActive = true;
    }

    public void StopTimer()
    {
        TimerActive = false;
    }
}
