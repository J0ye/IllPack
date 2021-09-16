using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateManager : MonoBehaviour
{
    public List<State> states = new List<State>();
    public bool startOnAwake = false;
    [Header("Keyboard Shortcut")]
    [Tooltip("Use this event to test functions by pressing return on the keyboard.")]
    public UnityEvent OnPressEnter = new UnityEvent();

    protected int counter = 0;

    public void Start()
    {
        if (startOnAwake)
            states[counter].Begin();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            OnPressEnter.Invoke();
        }
    }

    public void PlayThisState()
    {
        states[counter].Begin();
    }

    public void PlayNextState()
    {
        states[counter].Finish();
        counter++;
        if (counter >= states.Count)
            return;

        states[counter].Begin();
    }

    public void PlayPreviousState()
    {
        counter--;
        if (counter < 0)
            counter = 0;

        states[counter].Begin();
    }

    public void JumpToState(int target)
    {
        states[counter].Finish();
        counter = target;
        counter = Mathf.Clamp(counter, 0, states.Count - 1);
        states[counter].Begin();
    }

    public void PlayNextStateAfter(float seconds)
    {
        Invoke("PlayNextState", seconds);
    }
}
