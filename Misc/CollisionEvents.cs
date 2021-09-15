using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvents : MonoBehaviour
{
    public bool isReverseListening = false;
    public string[] tagsToListenTo;
    public GameObject[] objectsToListenTo;
    public int requiredNumberOfObjects = 1;
    public UnityEvent onCollisionEnter;
    public UnityEvent onCollisionExit;

    private List<GameObject> triggeredObjects;
    public int numberOfObjects = 0;

    // Start is called before the first frame update
    void Start()
    {
        Collider collider = GetComponent<Collider>();

        if (collider != null)
        {
            collider.isTrigger = false;
        }
        else
        {
            Destroy(this);
        }

        triggeredObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyObjects()
    {
        foreach (GameObject triggeredObject in triggeredObjects)
        {
            Destroy(triggeredObject);
        }
    }

    public void ChangeTagOfObject(string newTag)
    {
        foreach (GameObject triggeredObject in triggeredObjects)
        {
            triggeredObject.tag = newTag;
        }
    }

    public void TeleportGameObjects(Transform newPosition)
    {
        foreach (GameObject triggeredObject in triggeredObjects)
        {
            triggeredObject.transform.position = newPosition.position;
            triggeredObject.transform.rotation = newPosition.rotation;
        }
    }

    public void ChangeMaterialOfObject(Material material)
    {
        foreach (GameObject triggeredObject in triggeredObjects)
        {
            triggeredObject.GetComponent<Renderer>().material = material;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isValid(other.gameObject))
        {
            triggeredObjects.Add(other.gameObject);

            numberOfObjects++;

            if (numberOfObjects >= requiredNumberOfObjects)
                onCollisionEnter.Invoke();

            return;
        }
    }


    private void OnCollisionExit(Collision other)
    {
        if (isValid(other.gameObject))
        {
            if (numberOfObjects == requiredNumberOfObjects)
                onCollisionExit.Invoke();

            numberOfObjects--;

            triggeredObjects.Remove(other.gameObject);
        }
    }

    private bool isValid(GameObject other)
    {
        foreach (string tag in tagsToListenTo)
        {
            if (tag.Equals(other.gameObject.tag))
            {
                return !isReverseListening;
            }
        }

        foreach (GameObject thisObject in objectsToListenTo)
        {
            if (thisObject == other.gameObject)
            {
                return !isReverseListening;
            }
        }

        foreach (GameObject thisObject in triggeredObjects)
        {
            if (thisObject == other.gameObject)
            {
                return !isReverseListening;
            }
        }



        return isReverseListening;
    }
}
