using System;
using UnityEngine;
using UnityEngine.UI;

public class CounterRiddle : MonoBehaviour
{
    public int solution = 12;
    // TODO: Connect eventsystem and IncrementCounterBtn
    
    public IncrementCounterBtn incrementCounterBtn1er;
    public IncrementCounterBtn incrementCounterBtn10er;
    public IncrementCounterBtn incrementCounterBtn100er;
    public AudioSource winSound;

    int digit1er = 0;
    int digit10er = 0;
    int digit100er = 0;

    void Start()
    {
        incrementCounterBtn1er.onIncrement.AddListener(Receive1er);
        incrementCounterBtn10er.onIncrement.AddListener(Receive10er);
        incrementCounterBtn100er.onIncrement.AddListener(Receive100er);
    }

    void Receive1er(int cnt)
    {
        digit1er = cnt;
        CheckSolution();
    }
    
    void Receive10er(int cnt)
    {
        digit10er = cnt;
        CheckSolution();
    }
    
    void Receive100er(int cnt)
    {
        digit100er = cnt;
        CheckSolution();
    }

    void CheckSolution()
    {
        if ((digit1er + digit10er * 10 + digit100er * 100) == solution)
        {
            EventManager.instance.counterSolved.Invoke(true);
            Debug.Log("Counter Riddle Solved");
            if (winSound != null)
                winSound.Play();
        }
        else
        {
            EventManager.instance.counterSolved.Invoke(false);
            if (winSound != null)
                winSound.Stop();
        }
    }
}