using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class Draggable : MonoBehaviour
{
    public Rigidbody rb;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (source.clip != null)
        {
            float audioLevel = collision.relativeVelocity.magnitude / 10.0f;
            source.PlayOneShot(source.clip, audioLevel);
        }
    }
}
