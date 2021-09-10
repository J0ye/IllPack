using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
