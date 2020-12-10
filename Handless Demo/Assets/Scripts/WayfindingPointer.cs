using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayfindingPointer : MonoBehaviour
{
    [SerializeField] Transform goalObject;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(goalObject.position);
    }
}
