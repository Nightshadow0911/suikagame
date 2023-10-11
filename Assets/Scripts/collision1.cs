using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public int objectIndex; // 각 물체의 인덱스를 지정 (Inspector에서 설정)
    public GameObject ball2; // ball2 프리팹

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌 이벤트가 발생하면 현재 물체의 인덱스와 다른 물체의 인덱스 비교
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
        // 현재 물체를 파괴
        Destroy(gameObject);

        // Create a single ball2 object at the collision point
        if (ball2 != null)
        {
            Instantiate(ball2, collision.contacts[0].point, Quaternion.identity);
        }
    }
}