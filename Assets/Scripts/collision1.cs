using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision1 : MonoBehaviour
{
    public GameObject ball2; // ball2 프리팹
    static int indexNumber = 1;
    private GameObject currentObject;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball1"))
        {
            // 현재 물체와 충돌한 물체의 이름에서 숫자를 추출
            int currentObjectNumber = GetNumberFromName(gameObject.name);
            int otherObjectNumber = GetNumberFromName(collision.gameObject.name);

            // 숫자를 비교하여 더 큰 쪽의 물체만 처리
            if (currentObjectNumber > otherObjectNumber)
            {
                indexNumber++; // 인덱스를 증가시킴
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
        // 이름에서 숫자를 추출 (예: "Object123"에서 123 추출)
        int number = 0;
        int startIndex = name.IndexOf("Object") + 6; // "Object" 다음부터 숫자 추출
        if (startIndex >= 0)
        {
            string numberStr = name.Substring(startIndex);
            int.TryParse(numberStr, out number);
        }
        return number;
    }

    void BigHandleCollisionBall1(Collision2D collision)
    {
        indexNumber++; // 인덱스를 증가시키는 대신 이전 인덱스를 그대로 사용
        // 현재 물체를 파괴
        
        GameObject newObject = Instantiate(ball2, collision.contacts[0].point, Quaternion.identity);
        newObject.name = "Object" + indexNumber;
        currentObject = newObject;
        Debug.Log(indexNumber);
        Destroy(gameObject);
    }

    void SmallHandleCollisionBall1(Collision2D collision)
    {
        // 현재 물체를 파괴
        Destroy(gameObject);
    }
}