using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingText : MonoBehaviour
{
    // displayTime will be set to a public float
    // so that you can easily change it in the Unity UI
    public float displayTime = 1;

    private float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = displayTime;
    }

    // Update is called once per frame
    // but only while the object is active
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0)
        {
            timeRemaining = displayTime;
            this.gameObject.SetActive(false);
        }
    }
}
