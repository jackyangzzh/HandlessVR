﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeButton : GazableButton
{
    [SerializeField] private InputMode mode;

    public override void OnPress(RaycastHit hitInfo)
    {
        base.OnPress(hitInfo);

        if (parentPanel.currentActiveButton != null)
        {
            VRPlayer.instance.activeMode = mode;
        }

    }
}
