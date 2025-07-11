using UnityEngine;

public class RiddleManager : MonoBehaviour
{
    private bool _levelDone = false;

    private bool _box1RiddleSolved = false;
    private bool _counterDone = false;
    private bool _searchSolved = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventManager.instance.box1Solved.AddListener(Box1RiddleSolved);
        EventManager.instance.counterSolved.AddListener(CounterRiddleSolved);
        EventManager.instance.buttonSearchSolved.AddListener(ButtonSearchSolved);
    }

    private void CounterRiddleSolved(bool solved)
    {
        _counterDone = solved;
        CheckRiddleSolved();
    }

    void Box1RiddleSolved(bool solved)
    {
        _box1RiddleSolved = true;
        CheckRiddleSolved();
    }

    void ButtonSearchSolved()
    {
        _searchSolved = true;
        CheckRiddleSolved();
    }

    void CheckRiddleSolved()
    {
        if (_levelDone)
            return;
        if (_box1RiddleSolved && _counterDone && _searchSolved)
        {
            _levelDone = true;
            EventManager.instance.levelDone.Invoke();
        }
    }
}