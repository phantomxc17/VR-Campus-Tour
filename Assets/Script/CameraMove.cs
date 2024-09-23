using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraMove : MonoBehaviour
{
    public float YMin = -50f;
    public float YMax = 100f;
 
    public Transform lookAt;
 
    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensivity_x = 600.0f;
    public float sensivity_y = 100f;
    public float curr_z;
    public float add_y;
    public float height = 12.38f;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

// Update is called once per frame
    void LateUpdate()
    {
        Move();
        Vector3 pos = transform.position;
        pos.y = height;
        transform.position = pos;
    }
 
    
    void Move()
    {
 
        currentX += Input.GetAxis("Mouse X") * sensivity_x * Time.deltaTime;
        currentY -= Input.GetAxis("Mouse Y") * sensivity_y * Time.deltaTime;
 
        currentY = Mathf.Clamp(currentY, YMin, YMax);
 
        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY + add_y, currentX, curr_z);
        transform.position = lookAt.position + rotation * Direction;
 
        transform.LookAt(lookAt.position);
    }
}