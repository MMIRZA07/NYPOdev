using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] WheelCollider frontRight; //serializeField sayesinde publi"c olmayanları kullanabiliz 
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRigthTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRigthTransform;
    [SerializeField] Transform backLeftTransform;

    public float hizlanma = 500f;
    public float frenGüc = 200f;
    public float donmeAci = 20f;


    private float mevcutDonme = 0f;
    private float mevcutHiz = 0f;
    private float mevcutFren = 0f;
    private void FixedUpdate()
    {
        mevcutHiz = hizlanma * Input.GetAxis("Vertical");

        frontRight.motorTorque = mevcutHiz;
        frontLeft.motorTorque = mevcutHiz;

        if (Input.GetKey(KeyCode.Space)){
            mevcutFren = frenGüc;
        } else mevcutFren = 0f;
        
        frontRight.brakeTorque =mevcutFren;
        frontLeft.brakeTorque = mevcutFren;
        backLeft.brakeTorque = mevcutFren;
        backRight.brakeTorque = mevcutFren;

        mevcutDonme =  donmeAci * Input.GetAxis("Horizontal");

        frontRight.steerAngle = mevcutDonme;
        frontLeft.steerAngle = mevcutDonme;


        UpdateWheel(frontRight, frontRigthTransform);
        UpdateWheel(backRight, backRigthTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(backLeft, backLeftTransform);
    }
    void UpdateWheel(WheelCollider col, Transform trans)
    {

        //Get
        
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);//fonksiyona konulan colliderin pozisyonu ve rotasyonunu buradakilere göre aktarma yapar

        //Set
        trans.position = position;
        trans.rotation = rotation;

    }
}
