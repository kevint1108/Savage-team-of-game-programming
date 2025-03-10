using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXandY;
    public float sensitivityHor = 5.0f;
    public float sensitivityVert = 5.0f;
    public float sensH = 9.0f;
    public float sensV = 9.0f;

    public float minimumVert = -45f;
    public float maximumVert = 45f;

    private float verticalRot = 0;

    private void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SENS_CHANGED, OnSensChanged);
    }

    private void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SENS_CHANGED, OnSensChanged);
    }

    private void OnSensChanged(float value)
    {
        float minSens = 5f;
        sensH =  Mathf.Max(sensitivityHor * value, minSens);
        sensV =  Mathf.Max(sensitivityVert * value, minSens);
    }

    private void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            //Horizontal rotation
            transform.Rotate(0, sensH * Input.GetAxis("Mouse X"), 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            // Vertical rotation
            verticalRot -= Input.GetAxis("Mouse Y") * sensV;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float horizontalRot = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
        else
        {
            // Horizontal and vertical rotation 
            verticalRot -= Input.GetAxis("Mouse Y") * sensV;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensH;
            float horizontalRot = transform.localEulerAngles.y + delta;
            
            transform.localEulerAngles = new Vector3(horizontalRot, horizontalRot, 0);

        }
    }
}
       
