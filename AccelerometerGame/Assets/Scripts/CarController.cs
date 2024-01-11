using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float carSpeed = 10f;  
    
    private Rigidbody carRigidbody;
    public float tilt;
    [SerializeField] Text tiltText;

    void Start()
    {
        
        carRigidbody = GetComponent<Rigidbody>();

    }
    /// <summary>
    /// movement: aracýn ileri yönde hareket etmesi
    /// Quaternion.Euler: Euler açýlarýný kullanarak bir döndürme quaternion'u oluþturur. Bu durumda, yani y koordinatý etrafýnda dönme olduðu için sadece tilt deðeri kullanýlýr. Araç sað-sol hareketi
    /// Quaternion.Lerp: iki quaternion arasýnda bir lineer interpolasyon (lerp) uygular.Bu, aracýn rotasyonunu yavaþça hedef rotasyona(targetRotation) doðru güncellemek için kullanýlýr.
    /// tilt.ToString("F2"); : Eðim miktarýný 2 ondalýk basamakla yazdýr
    /// Time.fixedDeltaTime : bu lerp iþlemi sabit bir hýzda gerçekleþir.
    /// </summary>
    void FixedUpdate()
    {
        
        tilt = Input.acceleration.x * 90; 
        Vector3 movement = transform.forward * carSpeed * Time.deltaTime;
        carRigidbody.MovePosition(carRigidbody.position+movement);
        Quaternion targetRotation = Quaternion.Euler(0,tilt,0); 
        carRigidbody.MoveRotation(Quaternion.Lerp(carRigidbody.rotation,targetRotation,1*Time.fixedDeltaTime));
        if (tiltText != null)
        {
            tiltText.text = tilt.ToString("F2"); 
        }
        
    }
   

    
}
