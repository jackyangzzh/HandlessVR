using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GazableButton : GazableObject
{
    protected VRCanvas parentPanel;

    private void Awake()
    {
        parentPanel = GetComponentInParent<VRCanvas>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetButtonColor(Color buttonColor)
    {
        this.GetComponent<Image>().color = buttonColor;
    }

    public override void OnPress(RaycastHit hitInfo)
    {
        if (parentPanel != null)
        {
            parentPanel.SetActiveButton(this);
        }
        else{
            Debug.LogError("Button not a child of VRPanel");
        }
    }

}
