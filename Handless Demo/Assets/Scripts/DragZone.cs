using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragZone : GazableObject
{
    private VRCanvas parentPanel;
    private Transform originalParent;
    private InputMode saveInputMode = InputMode.None;

    // Start is called before the first frame update
    void Awake()
    {
        parentPanel = GetComponentInParent<VRCanvas>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnPress(RaycastHit hitInfo)
    {
        base.OnPress(hitInfo);

        originalParent = parentPanel.transform.parent;
        parentPanel.transform.parent = Camera.main.transform;

        saveInputMode = VRPlayer.instance.activeMode;
        VRPlayer.instance.activeMode = InputMode.Drag;
    }

    public override void OnRelease(RaycastHit hitInfo)
    {
        base.OnRelease(hitInfo);

        parentPanel.transform.parent = originalParent;
        VRPlayer.instance.activeMode = saveInputMode;
    }
}
