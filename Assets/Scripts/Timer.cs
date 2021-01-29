using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float StartTimeSeconds = 60;
    public Text text;
    public bool running = true;

    public UnityEvent GameLost;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            StartTimeSeconds -= Time.deltaTime;

        }
        text.text = $"Time Remaining: 00:{(int)StartTimeSeconds:D2}";

        if (StartTimeSeconds <= 0)
        {
            GameLost.Invoke();
            running = false;
        }

    }
}
