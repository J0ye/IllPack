using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public Rigidbody target;
    public float length = 1f;
    public float flexibillity = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > length)
        {
            float diff = distance - length;
            Vector3 towards = transform.position - target.transform.position;

            if(distance > length + flexibillity)
            {
                target.transform.position += towards * (distance - (length + flexibillity));
            } else
            {
                target.velocity += towards * diff;
            }
        }
    }
}
