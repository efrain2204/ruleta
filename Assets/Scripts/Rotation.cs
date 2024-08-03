using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10000f;
    bool dragging = false;

    public float torqueAmount;

    public Transform objectTransform;

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

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(objectTransform.position).z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 localPosition = objectTransform.InverseTransformPoint(worldPosition);
            
            float x = Input.GetAxis("Mouse X") * rotationSpeed*Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;
            
            Debug.Log(y);
            Debug.Log(x);

            Debug.Log(localPosition);

            if(localPosition.y > 0){
                y = y*-1;
                x = x*-1;
            }

            rb.AddTorque(Vector3.down*x);
            rb.AddTorque(Vector3.right*y);
        }    

    }

}
