using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision3 : MonoBehaviour
{
    public GameObject ball4; // ball2 ������
    public int indexNumber = 1;
    private GameObject currentObject;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball3"))
        {
            // ���� ��ü�� �浹�� ��ü�� �̸����� ���ڸ� ����
            int currentObjectNumber = GetNumberFromName(gameObject.name);
            int otherObjectNumber = GetNumberFromName(collision.gameObject.name);

            // ���ڸ� ���Ͽ� �� ū ���� ��ü�� ó��
            if (currentObjectNumber > otherObjectNumber)
            {
                indexNumber++; // �ε����� ������Ŵ
                BigHandleCollisionBall(collision);
            }
            if(currentObjectNumber < otherObjectNumber)
            {
                SmallHandleCollisionBall(collision);
            }
        }
    }

    int GetNumberFromName(string name)
    {
        // �̸����� ���ڸ� ���� (��: "Object123"���� 123 ����)
        int number = 0;
        int startIndex = name.IndexOf("Object") + 6; // "Object" �������� ���� ����
        if (startIndex >= 0)
        {
            string numberStr = name.Substring(startIndex);
            int.TryParse(numberStr, out number);
        }
        return number;
    }

    void BigHandleCollisionBall(Collision2D collision)
    {
        // ���� ��ü�� �ı�
        Destroy(gameObject);
        GameObject newObject = Instantiate(ball4, collision.contacts[0].point, Quaternion.identity);
        newObject.name = "Object" + indexNumber;
        currentObject = newObject;
        
    }
    void SmallHandleCollisionBall(Collision2D collision)
    {
        // ���� ��ü�� �ı�
        Destroy(gameObject);
    }
}