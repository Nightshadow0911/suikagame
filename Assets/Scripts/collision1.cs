using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public int objectIndex; // �� ��ü�� �ε����� ���� (Inspector���� ����)
    public GameObject ball2; // ball2 ������

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹 �̺�Ʈ�� �߻��ϸ� ���� ��ü�� �ε����� �ٸ� ��ü�� �ε��� ��
        Collision otherCollision = collision.collider.GetComponent<Collision>();

        if (otherCollision != null)
        {
            if (objectIndex > otherCollision.objectIndex)
            {
                HandleCollisionBall1(collision);
            }
        }
    }

    void HandleCollisionBall1(Collision2D collision)
    {
        // ���� ��ü�� �ı�
        Destroy(gameObject);

        // Create a single ball2 object at the collision point
        if (ball2 != null)
        {
            Instantiate(ball2, collision.contacts[0].point, Quaternion.identity);
        }
    }
}