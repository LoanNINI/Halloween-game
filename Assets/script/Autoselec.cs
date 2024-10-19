using UnityEngine;

public class Autoselec : MonoBehaviour
{
   
    // กำหนดตัวแปรสำหรับ GameObject ที่เราต้องการเปิด/ปิด
    public GameObject targetObject;

    // ฟังก์ชันที่จะเปิด/ปิด GameObject
    public void ToggleObject()
    {
        // ตรวจสอบสถานะปัจจุบันของ GameObject
        bool isActive = targetObject.activeSelf;

        // สลับสถานะเปิด/ปิด
        targetObject.SetActive(true);
    }
}


