using System.Collections;
using UnityEngine;

public class CompassWay : MonoBehaviour
{
    public GameObject compassIndicatorPrefab; // Prefab ของเข็มทิศ
    public Transform[] targets; // Array ของตำแหน่งเป้าหมาย
    private GameObject compassIndicator;
    private int currentTargetIndex = 0; // ใช้เพื่อจัดการตำแหน่งเป้าหมายปัจจุบัน

    void Start()
    {
        DeactivateCompassWay();
    }

    public void ActivateCompassWay()
    {
        // สร้างเข็มทิศถ้ายังไม่มี
        if (compassIndicator == null && targets.Length > 0)
        {
            compassIndicator = Instantiate(compassIndicatorPrefab, transform.position, Quaternion.identity);
            compassIndicator.transform.SetParent(this.transform);
        }

        UpdateCompass();
    }

    void Update()
    {
        // อัปเดตเข็มทิศตามตำแหน่งเป้าหมาย
        if (compassIndicator != null && targets.Length > 0)
        {
            UpdateCompass();
        }
    }

    void UpdateCompass()
    {
        if (targets.Length > 0)
        {
            // คำนวณทิศทางจากผู้เล่นไปยังเป้าหมายปัจจุบัน
            Vector3 direction = (targets[currentTargetIndex].position - Camera.main.transform.position).normalized;
            compassIndicator.transform.forward = direction;
        }
    }

    public void DeactivateCompassWay()
    {
        // ปิดเข็มทิศ
        if (compassIndicator != null)
        {
            Destroy(compassIndicator);
            compassIndicator = null;
        }
    }

    // ฟังก์ชันสำหรับเปลี่ยนเป้าหมาย
    public void SetTargetIndex(int index)
    {
        if (index >= 0 && index < targets.Length)
        {
            currentTargetIndex = index;
        }
    }
}
