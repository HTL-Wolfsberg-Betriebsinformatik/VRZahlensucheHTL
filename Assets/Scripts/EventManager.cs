using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private static EventManager _eventManager;
    
    public static EventManager instance {
        get {
            if (!_eventManager) {
                _eventManager = FindFirstObjectByType(typeof(EventManager)) as EventManager;

                if (!_eventManager) {
                    Debug.LogError("There needs to be one active EventManager script on a GameObject in your scene.");
                } else {
                    _eventManager.Init();
                    DontDestroyOnLoad(_eventManager);
                }
            }
            return _eventManager;
        }
    }

    /// <summary>
    /// Solved all riddles
    /// </summary>
    public UnityEvent levelDone;
    
    /// <summary>
    /// Dummy Riddle
    /// </summary>
    public UnityEvent solvedButtonPress;
    
    public UnityEvent<bool> counterSolved;
    
    void Init()
    {
        levelDone ??= new UnityEvent();
        solvedButtonPress ??= new UnityEvent();
        counterSolved ??= new UnityEvent<bool>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (EventManager.instance != this)
        {
            Debug.LogError(
                "There must be exactly one instance of EventManager script on a GameObject in your scene. " +
                "Destroy this instance.");
            DestroyImmediate(this);
        }
    }

    public void InvokeSolvedButtonPress()
    {
        levelDone.Invoke();
    }

}
