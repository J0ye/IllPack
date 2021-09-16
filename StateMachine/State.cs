using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "New State", menuName = "State Machine/Create New State", order = 1)]
public class State : MonoBehaviour
{
    public UnityEvent OnStateStart = new UnityEvent();
    public UnityEvent OnStateEnd = new UnityEvent();

    public void Begin()
    {
        OnStateStart.Invoke();
    }

    public void Finish()
    {
        OnStateEnd.Invoke();
    }
}
