using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haraket : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight; //serializeField sayesinde publi"c olmayanları kullanabiliz 
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRigthTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRigthTransform;
    [SerializeField] Transform backLeftTransform;

    public float hizlanma = 500f; //public olduğundan oyun kısmından değiştirilebilir 
    public float frenGuc = 300f;
    public float maxDonmeAci = 15f;

    private float mevcutHizlama = 0f;
    private float mevcutFrenGuc = 0f;
    private float mevcutDonmeAci = 0f;

    private float hedefHorizontal = 0f; // Hedef değeri
    private float hedefVertical = 0f;   // Hedef değeri

    private float Horizontal = 0f; // Mevcut değer
    private float Vertical = 0f;   // Mevcut değer

    public float gecisHizi = 5f; // Geçiş hızı

    private void FixedUpdate()
    {
        Horizontal = Mathf.Lerp(Horizontal, hedefHorizontal, Time.deltaTime * gecisHizi); //Horizontal ve Vertical değerlerini yumuşak geçiş
        Vertical = Mathf.Lerp(Vertical, hedefVertical, Time.deltaTime * gecisHizi);
        
        frontRight.motorTorque = mevcutHizlama;
        frontLeft.motorTorque = mevcutHizlama;


        frontRight.brakeTorque = mevcutFrenGuc;
        frontLeft.brakeTorque = mevcutFrenGuc;
        backRight.brakeTorque = mevcutFrenGuc;
        backLeft.brakeTorque = mevcutFrenGuc;

        //------DÖNME-------
        mevcutDonmeAci = maxDonmeAci * Horizontal;//button kontrol 

        frontRight.steerAngle = mevcutDonmeAci; //direksiyon açısını sağ ön tekerde mevcut açı değerine eşitle 
        frontLeft.steerAngle = mevcutDonmeAci;  //direksiyon açısını sol ön tekerde mevcut açı değerine eşitle 

        UpdateWheel(frontRight, frontRigthTransform);
        UpdateWheel(backRight, backRigthTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(backLeft, backLeftTransform);
    }
    void UpdateWheel(WheelCollider col , Transform trans) 
    {

        //Get
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);//fonksiyona konulan colliderin pozisyonu ve rotasyonunu buradakilere göre aktarma yapar

        //Set
        trans.position = position;
        trans.rotation = rotation;

    }
    public void Sol()
    {
        hedefHorizontal = -1f; 
    }
    public void Sag()
    {
        hedefHorizontal = 1f;
    }
    public void ileri()
    {
        hedefVertical = 1f;
    }
    public void Geri()
    {
        hedefVertical = -1f;
    }
    public void DurHorizontal()
    {
        hedefHorizontal = 0f; 
    }
    public void DurVertical()
    {
        hedefVertical = 0f;
    }
    public void fren()
    {
        mevcutFrenGuc = frenGuc;
    }
    public void durFren()
    {
        mevcutFrenGuc = 0f;
    }

    

}
