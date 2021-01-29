using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    public GameObject DraggingObject;

    public float Distance;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.GetComponent<Draggable>())
                {
                    DraggingObject = hit.collider.gameObject;
                    print("Grabbed Object: " + DraggingObject.name);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            DraggingObject = null;
        }

        if (DraggingObject != null)
        {
            DraggingObject.transform.position = transform.position + transform.forward * Distance;
        }
    }
}
