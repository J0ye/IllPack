using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CounterEvent : MonoBehaviour
{

    public int currentNumberOfTicks;
    public int maxNumber = 0;
    public UnityEvent onNumberReached;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNumber(int number)
    {
        this.currentNumberOfTicks = number;

        this.checkNumber();
    }

    public void IncreaseNumber()
    {
        this.currentNumberOfTicks++;

        this.checkNumber();
    }

    public void DecreaseNumber()
    {
        this.currentNumberOfTicks--;

        this.checkNumber();
    }

    private void checkNumber()
    {
        if(this.currentNumberOfTicks >= this.maxNumber)
        {
            this.onNumberReached.Invoke();
        }
    }
}
