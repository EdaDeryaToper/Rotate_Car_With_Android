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
    /// movement: arac�n ileri y�nde hareket etmesi
    /// Quaternion.Euler: Euler a��lar�n� kullanarak bir d�nd�rme quaternion'u olu�turur. Bu durumda, yani y koordinat� etraf�nda d�nme oldu�u i�in sadece tilt de�eri kullan�l�r. Ara� sa�-sol hareketi
    /// Quaternion.Lerp: iki quaternion aras�nda bir lineer interpolasyon (lerp) uygular.Bu, arac�n rotasyonunu yava��a hedef rotasyona(targetRotation) do�ru g�ncellemek i�in kullan�l�r.
    /// tilt.ToString("F2"); : E�im miktar�n� 2 ondal�k basamakla yazd�r
    /// Time.fixedDeltaTime : bu lerp i�lemi sabit bir h�zda ger�ekle�ir.
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
