using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCanvas : MonoBehaviour
{
    public GazableButton currentActiveButton;

    [SerializeField] Color unSelectedColor = Color.white;
    [SerializeField] Color selectedColor = Color.green;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }

    public void SetActiveButton(GazableButton activeButton)
    {
        if (currentActiveButton != null)
        {
            currentActiveButton.SetButtonColor(unSelectedColor);
        }

        if (activeButton != null && currentActiveButton != activeButton)
        {
            currentActiveButton = activeButton;
            currentActiveButton.SetButtonColor(selectedColor);
        }
        else
        {
            Debug.Log("Resetting");
            currentActiveButton = null;
            VRPlayer.instance.activeMode = InputMode.None;
        }

    }

    private void LookAtPlayer()
    {
        Vector3 playerPos = VRPlayer.instance.transform.position;
        Vector3 posToPlayer = playerPos - transform.position;

        Vector3 lookAtPos = transform.position - posToPlayer;

        transform.LookAt(lookAtPos);
    }
}
