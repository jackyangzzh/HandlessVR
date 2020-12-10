using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazableObject : MonoBehaviour
{

    public bool transformable = false;

    private int objectLayer;
    private const int Ignore_Raycast_Layer = 2;

    private Vector3 initialObjectRotation;
    private Vector3 initialPlayerRotation;
    private Vector3 initialObjectScale;

    public virtual void OnGazeEnter(RaycastHit hitInfo)
    {
        // Debug.Log("On gaze enter " + gameObject.name);
    }

    public virtual void OnGaze(RaycastHit hitInfo)
    {
        // Debug.Log("On gaze " + gameObject.name);
    }

    public virtual void OnGazeExit()
    {
        // Debug.Log("On gaze exit " + gameObject.name);
    }

    public virtual void OnPress(RaycastHit hitInfo)
    {
        if (transformable)
        {
            objectLayer = gameObject.layer;
            gameObject.layer = Ignore_Raycast_Layer;

            initialObjectRotation = transform.rotation.eulerAngles;
            initialPlayerRotation = Camera.main.transform.eulerAngles;

            initialObjectScale = transform.localScale;
        }
        // Debug.Log("On press " + gameObject.name);
    }

    public virtual void OnHold(RaycastHit hitInfo)
    {
        // Debug.Log("On hold " + gameObject.name);

        if (transformable)
        {
            GazeTransform(hitInfo);
        }
    }

    public virtual void OnRelease(RaycastHit hitInfo)
    {
        if (transformable)
        {
            gameObject.layer = objectLayer;
        }

        // Debug.Log("On release " + gameObject.name);
    }

    public virtual void GazeTransform(RaycastHit hitInfo)
    {
        switch (VRPlayer.instance.activeMode)
        {
            case InputMode.Translate:
                GazeTranslate(hitInfo);
                break;

            case InputMode.Rotate:
                GazeRotate(hitInfo);
                break;

            case InputMode.Scale:
                GazeScale(hitInfo);
                break;
        }
    }

    public virtual void GazeTranslate(RaycastHit hitInfo)
    {
        if (hitInfo.collider != null && hitInfo.collider.GetComponent<VRFloor>())
        {
            transform.position = hitInfo.point;
        }
    }

    public virtual void GazeRotate(RaycastHit hitInfo)
    {
        float rotationSpeed = 5.0f;

        Vector3 currentPlayerRotation = Camera.main.transform.rotation.eulerAngles;

        Vector3 currentObjectRotation = transform.rotation.eulerAngles;

        Vector3 rotationDelta = currentPlayerRotation - initialPlayerRotation;

        float updownRotation = currentObjectRotation.x;

        // If looking up
        if (rotationDelta.x < 0 && rotationDelta.x > -180.0f || rotationDelta.x >= 180.0f && rotationDelta.x <= 360.0f)
        {
            if (rotationDelta.x > 180.0f)
            {
                rotationDelta.x = 360.0f - rotationDelta.x;
            }
            updownRotation = initialObjectRotation.x + Mathf.Abs(rotationDelta.x) * rotationSpeed;

        }
        else
        {
            if (rotationDelta.x < -180.0f)
            {
                rotationDelta.x = 360.0f + rotationDelta.x;
            }
            updownRotation = initialObjectRotation.x - (rotationDelta.x * rotationSpeed);
            Debug.Log(rotationDelta.x);
        }

        Vector3 newRotation = new Vector3(updownRotation, initialObjectRotation.y + (rotationDelta.y * rotationSpeed), 0);


        transform.rotation = Quaternion.Euler(newRotation);

    }

    public virtual void GazeScale(RaycastHit hitInfo)
    {
        float scaleSpeed = 0.1f;
        float scaleFactor = 1;

        Vector3 currentPlayerRotation = Camera.main.transform.rotation.eulerAngles;
        Vector3 rotationDelta = currentPlayerRotation - initialPlayerRotation;

        // If looking up
        if (rotationDelta.x < 0 && rotationDelta.x > -180.0f || rotationDelta.x > 180.0f && rotationDelta.x < 360.0f)
        {
            if (rotationDelta.x > 180.0f)
            {
                rotationDelta.x = 360.0f - rotationDelta.x;
            }

            scaleFactor = 1.0f + Mathf.Abs(rotationDelta.x) * scaleSpeed;
        }
        else
        {
            if (rotationDelta.x < -180.0f)
            {
                rotationDelta.x = 360.0f + rotationDelta.x;
            }

            scaleFactor = Mathf.Max(0.1f, 1.0f - (Mathf.Abs(rotationDelta.x) * (1.0f / scaleSpeed)) / 180.0f);
        }

        transform.localScale = scaleFactor * initialObjectScale;
    }
}
