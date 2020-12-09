using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazableObject : MonoBehaviour
{

    public bool transformable = false;

    private int objectLayer;
    private const int Ignore_Raycast_Layer = 2;

    public virtual void OnGazeEnter(RaycastHit hitInfo)
    {
        Debug.Log("On gaze enter " + gameObject.name);
    }

    public virtual void OnGaze(RaycastHit hitInfo)
    {
        Debug.Log("On gaze " + gameObject.name);
    }

    public virtual void OnGazeExit()
    {
        Debug.Log("On gaze exit " + gameObject.name);
    }

    public virtual void OnPress(RaycastHit hitInfo)
    {
        if (transformable)
        {
            objectLayer = gameObject.layer;
            gameObject.layer = Ignore_Raycast_Layer;
        }
        Debug.Log("On press " + gameObject.name);
    }

    public virtual void OnHold(RaycastHit hitInfo)
    {
        Debug.Log("On hold " + gameObject.name);

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

        Debug.Log("On release " + gameObject.name);
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

    }

    public virtual void GazeScale(RaycastHit hitInfo)
    {

    }
}
