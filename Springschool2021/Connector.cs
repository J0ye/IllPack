using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public Rigidbody target;
    public float length = 1f;
    public float flexibillity = 0f;
    public float temp = 5f;

    private Vector3 oldpos;
    // Start is called before the first frame update
    void Start()
    {
        oldpos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > length) // target reaches end of connection
        {
            float diff = distance - length;
            Vector3 towards = transform.position - target.transform.position;
            if(distance >= length + flexibillity)
            {
                target.transform.position += towards.normalized * (distance - (length + flexibillity));
            }
            target.velocity += towards * diff;
        }
    }
}
