using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    [HideInInspector]
    public Draggable DraggingObject;

    public float Distance;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                print(hit.collider.name);
                if (hit.collider.gameObject.GetComponent<Draggable>())
                {
                    DraggingObject = hit.collider.GetComponent<Draggable>();
                    print("Grabbed Object: " + DraggingObject.name);
                    DraggingObject.transform.parent = null;
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
            DraggingObject.rb.velocity = Vector3.zero;
        }
    }
}
