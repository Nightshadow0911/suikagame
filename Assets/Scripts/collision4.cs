using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision4 : MonoBehaviour
{
    public GameObject ball5; // ball2 ������
    public int indexNumber = 1;
    private GameObject currentObject;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball4"))
        {
            // ���� ��ü�� �浹�� ��ü�� �̸����� ���ڸ� ����
            int currentObjectNumber = GetNumberFromName(gameObject.name);
            int otherObjectNumber = GetNumberFromName(collision.gameObject.name);

            // ���ڸ� ���Ͽ� �� ū ���� ��ü�� ó��
            if (currentObjectNumber > otherObjectNumber)
            {
                indexNumber++; // �ε����� ������Ŵ
                BigHandleCollisionBall1(collision);
            }
            if(currentObjectNumber < otherObjectNumber)
            {
                SmallHandleCollisionBall1(collision);
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

    void BigHandleCollisionBall1(Collision2D collision)
    {
        // ���� ��ü�� �ı�
        Destroy(gameObject);
        GameObject newObject = Instantiate(ball5, collision.contacts[0].point, Quaternion.identity);
        newObject.name = "Object" + indexNumber;
        currentObject = newObject;
       
    }
    void SmallHandleCollisionBall1(Collision2D collision)
    {
        // ���� ��ü�� �ı�
        Destroy(gameObject);
    }
}