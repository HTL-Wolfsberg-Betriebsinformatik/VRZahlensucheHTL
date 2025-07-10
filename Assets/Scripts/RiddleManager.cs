using UnityEngine;

public class RiddleManager : MonoBehaviour
{
    private bool _dummyRiddleSolved = true;
    private bool _levelDone = false;
    private bool _counterDone = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventManager.instance.solvedButtonPress.AddListener(DummyRiddleSolved);
        EventManager.instance.counterSolved.AddListener(CounterRiddleSolved);
    }

    private void CounterRiddleSolved(bool solved)
    {
        _counterDone = solved;
        CheckRiddleSolved();
    }

    void DummyRiddleSolved()
    {
        _dummyRiddleSolved = true;
        CheckRiddleSolved();
    }

    void CheckRiddleSolved()
    {
        if (_levelDone)
            return;
        if (_dummyRiddleSolved && _counterDone)
        {
            _levelDone = true;
            EventManager.instance.levelDone.Invoke();
        }
    }
}
