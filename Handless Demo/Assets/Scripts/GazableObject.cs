using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazableObject : MonoBehaviour
{
    public virtual void OnGazeEnter(RaycastHit hitInfo){
        Debug.Log("On gaze enter " + gameObject.name);
    }

    public virtual void OnGaze(RaycastHit hitInfo){
        Debug.Log("On gaze " + gameObject.name);
    }

    public virtual void OnGazeExit(){
        Debug.Log("On gaze exit " + gameObject.name);
    }

    public virtual void OnPress(RaycastHit hitInfo){
        Debug.Log("On press " + gameObject.name);
    }

    public virtual void OnHold(RaycastHit hitInfo){
        Debug.Log("On hold " + gameObject.name);
    }

    public virtual void OnRelease(RaycastHit hitInfo){
        Debug.Log("On release " + gameObject.name);
    }
}
