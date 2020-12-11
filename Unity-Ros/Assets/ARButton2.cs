using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARButton2 : MonoBehaviour, OnTouch3D
{
    public Text messageText;

    public void OnTouch()
    {
        messageText.gameObject.SetActive(true);
        messageText.text = "Button2Pressed";
    }
}
