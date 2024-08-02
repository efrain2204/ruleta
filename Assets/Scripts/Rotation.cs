using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10000f;
    bool dragging = false;

    public float torqueAmount;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDrag()
    {
        dragging = true;
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }

    void FixedUpdate() 
    {
        if(dragging)
        {
            // float x = Input.GetAxis("Mouse X") * rotationSpeed*Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;
            Debug.Log(y);
            // rb.AddTorque(Vector3.down*x);
            rb.AddTorque(Vector3.right*y);
        }    

    }

}
