using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Sensitivity Settings")]
    [SerializeField] private float mouseSensitivity = 200f;

    [Header("References")]
    [SerializeField] private Transform orientationTransform; 

    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Mouse girdileri
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;   //100 fps alan bir bilgisayar update fonksiyonunu saniyede 100 kere çağırır bunu düzeltiyoruz burada
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;       //tüm bilgisayarlarda aynı perfermoansı vermesini sağlar

        yRotation += mouseX; 
        xRotation -= mouseY;                //x ekseninden bir kalem geçirdiğimizi düşün kulağından kulağına bu onun yukarı aşağı hareket etmesini sağlar (xRotation)

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Yukarı/Aşağı bakış sınırı   clamp zaten kelepçe demek sınırlıyoruz gerççek hayatta başımızı y ekseninde arkaya çeviremiyoruz

       
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);           
        if (orientationTransform != null)
        {
            orientationTransform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        }
    }
}