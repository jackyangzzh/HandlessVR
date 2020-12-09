using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputMode
{
    None,
    Teleport,
    Walk,
    Float
}

public class VRPlayer : MonoBehaviour
{

    public static VRPlayer instance;
    public InputMode activeMode = InputMode.None;

    [SerializeField] float playerSpeed = 2.0f;

    private void Awake()
    {
        if (instance != null)
        {
            GameObject.Destroy(instance.gameObject);
        }
        instance = this;

        GetComponent<Rigidbody>().useGravity = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TryWalking();
        TryFloating();
    }

    public void TryWalking()
    {
        if (Input.GetMouseButton(0) && activeMode == InputMode.Walk)
        {
            Vector3 forward = Camera.main.transform.forward;

            Vector3 newPosition = transform.position + forward * Time.deltaTime * playerSpeed;
            newPosition.y = instance.gameObject.transform.position.y;

            GetComponent<Rigidbody>().useGravity = true;

            transform.position = newPosition;
        }
    }


    public void TryFloating()
    {
        if (Input.GetMouseButton(0) && activeMode == InputMode.Float)
        {
            Vector3 forward = Camera.main.transform.forward;

            Vector3 newPosition = transform.position + forward * Time.deltaTime * playerSpeed / 2;

            GetComponent<Rigidbody>().useGravity = false;

            transform.position = newPosition;
        }
    }
}
