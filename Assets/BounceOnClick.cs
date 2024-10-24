using UnityEngine;
using UnityEngine.UI;

public class BounceOnButton : MonoBehaviour
{
    public GameObject selectedObject;      // GameObject ��������͹���
    public Vector3 startPosition;          // ���˹��������
    public Vector3 targetPosition;         // ���˹觻��·ҧ
    public float moveSpeed = 2f;           // ��������㹡������͹���
    private bool isMovingUp = false;       // ��Ǩ�ͺ��ҡ��ѧ��Ѻ����������
    private bool isReturning = false;      // ��Ǩ�ͺ��ҡ��ѧ��Ѻŧ�ҵ��˹���������������

    public Button bounceButton;            // UI Button

    void Start()
    {
        if (selectedObject != null)
        {
            // ��˹����˹�������������ҡѺ���˹�������鹷����ҡ�˹�� Unity Inspector
            selectedObject.transform.position = startPosition;

            // �١�ѧ��ѹ BounceObject ��ҡѺ����
            bounceButton.onClick.AddListener(BounceObject);
        }
    }

    // �ѧ��ѹ����Ѻ������������͹�������͡�����
    public void BounceObject()
    {
        if (!isMovingUp && !isReturning)
        {
            isMovingUp = true;  // �������Ѻ���
        }
    }

    void Update()
    {
        // ��Ѻ���价����˹觻��·ҧ����˹�
        if (isMovingUp)
        {
            selectedObject.transform.position = Vector3.MoveTowards(selectedObject.transform.position,
                targetPosition, moveSpeed * Time.deltaTime);

            // ����Ͷ֧���˹觻��·ҧ����������Ѻŧ��
            if (selectedObject.transform.position == targetPosition)
            {
                isMovingUp = false;
                isReturning = true;
            }
        }

        // ��Ѻ�ҵ��˹��������
        if (isReturning)
        {
            selectedObject.transform.position = Vector3.MoveTowards(selectedObject.transform.position,
                startPosition, moveSpeed * Time.deltaTime);

            // ����͡�Ѻ�֧���˹�������������ش�������͹���
            if (selectedObject.transform.position == startPosition)
            {
                isReturning = false;
            }
        }
    }
}