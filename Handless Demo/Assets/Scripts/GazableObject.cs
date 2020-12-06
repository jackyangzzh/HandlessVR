using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazableObject : MonoBehaviour
{
    public virtual void OnGazeEnter(RaycastHit hitInfo){

    }

    public virtual void OnGaze(RaycastHit hitInfo){

    }

    public virtual void OnGazeExit(){

    }

    public virtual void OnPress(RaycastHit hitInfo){

    }

    public virtual void OnHold(RaycastHit hitInfo){

    }

    public virtual void OnRelease(){
        
    }
}
