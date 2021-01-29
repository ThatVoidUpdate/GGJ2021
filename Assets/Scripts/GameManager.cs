using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject WonEnable;
    public GameObject LostEnable;

    // Start is called before the first frame update
    void Start()
    {
        WonEnable.SetActive(false);
        LostEnable.SetActive(false);
    }

    public void WonGame()
    {
        WonEnable.SetActive(true);
    }

    public void LostGame()
    {
        LostEnable.SetActive(true);
    }
}
