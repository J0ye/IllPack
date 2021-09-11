using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enables the player to construct complex object by colliding the correct parts into the main part.
/// Creates a list of parts based on the children of this object. These parts will be disabled on start and enabled, 
/// if a part with the same name collides with this.
/// </summary>
public class ThingCollection : MonoBehaviour
{
    public List<GameObject> parts = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Child Count: " + transform.childCount);
        foreach(Transform child in transform)
        {
            parts.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        ActivatePart(collision.gameObject);
    }

    protected void ActivatePart(GameObject target)
    {
        foreach (GameObject part in parts)
        {
            if (part.name == target.name)
            {
                part.SetActive(true);
                target.SetActive(false);
            }
        }
    }
}
