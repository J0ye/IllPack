using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public Rigidbody target;
    public float maxDistance = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > maxDistance) // target reaches end of connection
        {
            float diff = distance - maxDistance;
            Vector3 towards = transform.position - target.transform.position;
            target.transform.position += towards * diff;
            target.velocity = GetComponent<Rigidbody>().velocity;
        }
    }
}
