using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeSystem : MonoBehaviour
{
    [SerializeField] GameObject reticle;

    [SerializeField] Color inactiveColor = Color.gray;
    [SerializeField] Color activeColor = Color.green;

    private GazableObject currentGazeObject;
    private GazableObject currentSelectedObject;

    private RaycastHit lastHit;

    // Start is called before the first frame update
    void Start()
    {
        SetReticleColor(inactiveColor);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessGaze();
        CheckForInput(lastHit);

    }

    public void ProcessGaze(){
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        Debug.DrawRay(ray.origin, ray.direction * 100);

        if(Physics.Raycast(ray, out hitInfo)){

            GameObject hitObj = hitInfo.collider.gameObject;
            GazableObject gazeObj = hitObj.GetComponent<GazableObject>();

            if(gazeObj != null){
                if(gazeObj != currentGazeObject){
                    ClearCurrentObject();
                    currentGazeObject = gazeObj;
                    currentGazeObject.OnGazeEnter(hitInfo);
                    SetReticleColor(activeColor);
                }else{
                    ClearCurrentObject();
                }
            }
            else{
                currentGazeObject.OnGaze(hitInfo);
            }
        }else{
            ClearCurrentObject();
        }

        lastHit = hitInfo;
    }

    private void SetReticleColor(Color reticleColor){
        reticle.GetComponent<Renderer>().material.SetColor("_Color", reticleColor);
    }

    private void CheckForInput(RaycastHit hitInfo){
        if(Input.GetMouseButtonDown(0) && currentGazeObject != null){
            currentSelectedObject = currentGazeObject;
            currentSelectedObject.OnPress(hitInfo);
        }
        else if(Input.GetMouseButton(0) && currentSelectedObject != null){
            currentSelectedObject.OnHold(hitInfo);
        }
        else if(Input.GetMouseButtonUp(0) && currentSelectedObject != null){
            currentSelectedObject.OnRelease(hitInfo);
            currentSelectedObject = null;
        }

    
    }

    private void ClearCurrentObject(){
        if(currentGazeObject != null){
            currentGazeObject.OnGazeExit();
            SetReticleColor(inactiveColor);
            currentGazeObject = null;
        }
    }
    
}
