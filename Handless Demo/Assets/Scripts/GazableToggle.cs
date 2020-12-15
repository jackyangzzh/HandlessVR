using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazableToggle : GazableObject
{
    private Toggle toggle;
    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        toggle.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnPress(RaycastHit hitInfo)
    {
        if (toggle.isOn)
        {
            toggle.isOn = false;
        }
        else
        {
            toggle.isOn = true;
        }

    }
}
