using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Keys : MonoBehaviour
{
    public UnityEvent GameWon;

    private void OnMouseDown()
    {
        Debug.Log("You found the keys!");
        GameWon.Invoke();
    }
}
