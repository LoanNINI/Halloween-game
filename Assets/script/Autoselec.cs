using UnityEngine;

public class Autoselec : MonoBehaviour
{
   
    // ��˹����������Ѻ GameObject �����ҵ�ͧ����Դ/�Դ
    public GameObject targetObject;

    // �ѧ��ѹ�����Դ/�Դ GameObject
    public void ToggleObject()
    {
        // ��Ǩ�ͺʶҹлѨ�غѹ�ͧ GameObject
        bool isActive = targetObject.activeSelf;

        // ��Ѻʶҹ��Դ/�Դ
        targetObject.SetActive(true);
    }
}


