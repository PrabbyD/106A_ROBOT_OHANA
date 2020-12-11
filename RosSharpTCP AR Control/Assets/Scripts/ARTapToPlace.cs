using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;


[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlace : MonoBehaviour
{

    public GameObject gameObjectToInstantiate;
    public GameObject wallObject;
    public Toggle placingToggle;
    public Dropdown objectSelect;

    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();

    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (placingToggle.isOn)
            {
                if (objectSelect.captionText.text == "Walls")
                {
                    Instantiate(wallObject, hitPose.position, hitPose.rotation);
                }
                else if (objectSelect.captionText.text == "Turtlebot")
                {
                    if (spawnedObject == null)
                    {
                        spawnedObject = GameObject.Find("turtlebot3_burger_notprefab");
                        float a = 5E-1f;
                        hitPose.position.y += a;
                        spawnedObject.transform.position = hitPose.position;
                    }
                    else
                    {
                        hitPose.position.y += .5;
                        spawnedObject.transform.position = hitPose.position;
                    }
                }
                else if (objectSelect.captionText.text == "block")
                {
                    if (spawnedObject == null)
                    {
                        spawnedObject = GameObject.Find("TurtlebotCube");
                        spawnedObject.transform.position = hitPose.position;
                    }
                    else
                    {
                        spawnedObject.transform.position = hitPose.position;
                    }
                }
            }

        }
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }
}