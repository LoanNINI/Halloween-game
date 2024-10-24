using UnityEngine;
using UnityEngine.UI;

public class BounceOnButton : MonoBehaviour
{
    public GameObject selectedObject;      // GameObject ที่จะเคลื่อนไหว
    public Vector3 startPosition;          // ตำแหน่งเริ่มต้น
    public Vector3 targetPosition;         // ตำแหน่งปลายทาง
    public float moveSpeed = 2f;           // ความเร็วในการเคลื่อนไหว
    private bool isMovingUp = false;       // ตรวจสอบว่ากำลังขยับขึ้นหรือไม่
    private bool isReturning = false;      // ตรวจสอบว่ากำลังกลับลงมาตำแหน่งเริ่มต้นหรือไม่

    public Button bounceButton;            // UI Button

    void Start()
    {
        if (selectedObject != null)
        {
            // กำหนดตำแหน่งเริ่มต้นให้เท่ากับตำแหน่งเริ่มต้นที่เรากำหนดใน Unity Inspector
            selectedObject.transform.position = startPosition;

            // ผูกฟังก์ชัน BounceObject เข้ากับปุ่ม
            bounceButton.onClick.AddListener(BounceObject);
        }
    }

    // ฟังก์ชันสำหรับเริ่มการเคลื่อนไหวเมื่อกดปุ่ม
    public void BounceObject()
    {
        if (!isMovingUp && !isReturning)
        {
            isMovingUp = true;  // เริ่มขยับขึ้น
        }
    }

    void Update()
    {
        // ขยับขึ้นไปที่ตำแหน่งปลายทางที่กำหนด
        if (isMovingUp)
        {
            selectedObject.transform.position = Vector3.MoveTowards(selectedObject.transform.position,
                targetPosition, moveSpeed * Time.deltaTime);

            // เมื่อถึงตำแหน่งปลายทางให้เริ่มกลับลงมา
            if (selectedObject.transform.position == targetPosition)
            {
                isMovingUp = false;
                isReturning = true;
            }
        }

        // กลับมาตำแหน่งเริ่มต้น
        if (isReturning)
        {
            selectedObject.transform.position = Vector3.MoveTowards(selectedObject.transform.position,
                startPosition, moveSpeed * Time.deltaTime);

            // เมื่อกลับถึงตำแหน่งเริ่มต้นให้หยุดการเคลื่อนไหว
            if (selectedObject.transform.position == startPosition)
            {
                isReturning = false;
            }
        }
    }
}