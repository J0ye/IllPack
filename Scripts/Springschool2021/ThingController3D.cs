using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingController3D : MonoBehaviour
{  
    public LayerMask layerMask;
    [Range(0.1f, 100f)]
    public float speed = 2f;
    public bool debug = false;

    protected RaycastHit hit;
    protected Transform target;
    protected Vector3 inputPos = Vector3.zero;

    // Update is called once per frame
    protected virtual void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Position of mouse relative to camera    
        inputPos = ray.GetPoint(5f);
        
        #region Grab thing
        if(Input.GetButton("Fire1"))    // Left Mouse Button Click
        {

            if(debug) Debug.DrawRay(transform.position, ray.direction*10, Color.green, Time.deltaTime);

            Physics.Raycast(ray, out hit, 10f, layerMask);

            if(hit.collider != null)
            {
                // register new target, if its an interactable
                if(!target) SetTarget(hit.transform.gameObject);
            }

            PullTarget(); // Pulls target closer if it exists
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            if (debug) Debug.Log("Removed target");
            // Release target on left mouse button up
            target = null;
        }
        #endregion
        #region Delete/Reset Thing
        else if(Input.GetButton("Fire2")) // Right Mouse Button Click
        {
            Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, out hit, Mathf.Infinity, layerMask);

            if (hit.collider != null)
            {
                if (hit.transform.gameObject.GetComponent<Thing>() != null)
                {
                    //hit.transform.gameObject.GetComponent<Thing>().ResetPosition();
                } else
                {
                    if(debug) Debug.LogWarning("Target has no Thing component");
                }
            }
        }
        #endregion
    }

    protected void SetTarget(GameObject go)
    {
        if (debug) Debug.Log("Target: " + hit.collider.gameObject.name);
        if (go.GetComponent<Thing>() != null)
        {
            if (debug) Debug.Log("Sucssefull hit");
            if (!go.gameObject.CompareTag("Thing"))
            {
                target = hit.transform; // Only set target if it is the playball and within the bounds
            }
            else if (hit.transform.gameObject.CompareTag("Thing"))
            {
                target = hit.transform; // If it is not the playball set it to the target
            }
        }
    }

    protected void PullTarget()
    {
        if (target != null)
        {
            //Pull the target towards the position of input. Force relative to distance.
            Vector3 targetPos = inputPos - target.position;
            targetPos = new Vector3(targetPos.x, 0, targetPos.z);
            target.GetComponent<Rigidbody>().velocity = targetPos * speed;
        }
    }
}
