using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeechBubble", menuName = "Dialouge/New Speechbubble", order = 1)]
public class SpeechBubble : ScriptableObject
{
    public int SecondToShow = 0;
    [TextArea]
    public string text;
}
