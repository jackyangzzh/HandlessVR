using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureButton : GazableButton
{
    [SerializeField] Object prefab;

    public override void OnPress(RaycastHit hitInfo)
    {
        base.OnPress(hitInfo);

        VRPlayer.instance.activeMode = InputMode.Furniture;

        VRPlayer.instance.activeFurniturePrefab = prefab;
    }


}
