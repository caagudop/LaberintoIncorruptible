using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInput : MonoBehaviour
{
    //public struct BoxInputState
    //{
    //    public bool pressed;
    //    public bool hold;
    //    public bool released;
    //}
    private float xAxisInput;
    private float zAxisInput;
    //private float maxAngle = 3.9f;
    //private float minAngle = -3.9f;
    private Transform prueba;
    private Rigidbody caja;
    [SerializeField]
    private float movementForce = 90f;    
    [SerializeField]
    private float xrotationspeed = 90f;

    private void Start()
    {
        prueba = this.GetComponent<Transform>();
        caja = this.GetComponent<Rigidbody>();
    }
    void Update()
    {
        //caja.velocity = Vector3.zero;
        xAxisInput = Input.GetAxis("Vertical");
        zAxisInput = Input.GetAxis("Horizontal"); 
        //float currentYrotation = horizontalInput * yrotationspeed * Time.deltaTime;
        //prueba.eulerAngles = new Vector3(prueba.eulerAngles.x, currentYrotation, prueba.eulerAngles.z);

        //float currentXrotation = verticalInput * xrotationspeed * Time.deltaTime;
        //prueba.eulerAngles = new Vector3(currentXrotation, prueba.eulerAngles.y, prueba.eulerAngles.z);
        
    }
    private void FixedUpdate()
    {
        //prueba.transform.position = new Vector3(0, -5.90999985f, 0.0599999987f);
        //caja.velocity = Vector3.zero;


        // get relative range +/- Siempre 3.9
        float relRangeX = 6.7f;
        

        // convert to a relative value
        Vector3 angles = prueba.transform.eulerAngles;
        float x = ((angles.x + 540) % 360) - 180;


        // if outside range
        if (Mathf.Abs(x) > relRangeX)
        {
            angles.x = relRangeX * Mathf.Sign(x);
            prueba.transform.eulerAngles = angles;
            Vector3 vel1 = caja.angularVelocity; // reads the property
            vel1.x = 0;
            caja.angularVelocity = vel1;  // writes the property
        }

        // get relative range +/- Siempre 2.7
        float relRangeZ = 4.45f;

        // convert to a relative value
        Vector3 angles2 = prueba.transform.eulerAngles;
        float z = ((angles2.z + 540) % 360) - 180;

        // if outside range
        if (Mathf.Abs(z) > relRangeZ)
        {
            angles.z = relRangeZ * Mathf.Sign(z);
            prueba.transform.eulerAngles = angles2;
            Vector3 vell2 = caja.angularVelocity; // reads the property
            vell2.z = 0;
            caja.angularVelocity = vell2;  // writes the property
        }
        Vector3 vel2 = caja.angularVelocity; // reads the property
        vel2.y = 0;
        caja.angularVelocity = vel2;  // writes the property


        caja.AddTorque(Vector3.back * zAxisInput * movementForce, ForceMode.Force);
        caja.AddTorque(Vector3.right * xAxisInput * movementForce, ForceMode.Force);
       
    }
}
