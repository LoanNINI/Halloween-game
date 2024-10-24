using UnityEngine;

public class Trigger2DHandler : MonoBehaviour
{
    private SpriteRenderer friendSpriteRenderer;  // ตัวแปรเก็บ SpriteRenderer ของ Friend

 void Update()
 {
     // ค้นหา GameObject ที่มี Tag เป็น "Friend"
        GameObject friendObject = GameObject.FindWithTag("friend");

        if (friendObject != null)
        {
            // เข้าถึงคอมโพเนนต์ SpriteRenderer ของ GameObject ที่มี Tag เป็น "Friend"
            friendSpriteRenderer = friendObject.GetComponent<SpriteRenderer>();
        }
 }

    // เมื่อ Player เข้ามาชน
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && friendSpriteRenderer != null)  // ตรวจสอบว่าเป็น Player และ friendSpriteRenderer ไม่ใช่ null
        {
            friendSpriteRenderer.enabled = false;  // ปิดการแสดงผล SpriteRenderer
        }
    }

    // เมื่อ Player ออกจากการชน
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && friendSpriteRenderer != null)  // ตรวจสอบว่าเป็น Player และ friendSpriteRenderer ไม่ใช่ null
        {
            friendSpriteRenderer.enabled = true;  // เปิดการแสดงผล SpriteRenderer
        }
    }
}
