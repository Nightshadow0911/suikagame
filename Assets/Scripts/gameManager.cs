using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] public string[] targetTags = { "ball1", "ball2", "ball3", "ball4", "ball5", "ball6", "ball7", "ball8" };

    private bool isDefeat = false;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (!isDefeat) // 이전에 패배하지 않았다면
        {
            // Y축 3.0f에서 레이를 발사
            Ray ray = new Ray(new Vector3(0, 3.0f, 0), Vector3.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 충돌한 게임 오브젝트의 태그를 확인
                foreach (string targetTag in targetTags)
                {
                    if (hit.collider.CompareTag(targetTag))
                    {
                        timer += Time.deltaTime;

                        if (timer >= 5f)
                        {
                            Defeat();
                            isDefeat = true; // 패배 상태로 변경
                            break;
                        }
                    }
                }
            }
            else
            {
                // 레이가 물체에 닿지 않으면 타이머 초기화
                timer = 0f;
            }
        }
    }

    void Defeat()
    {
        // 패배 시 실행할 코드
        Debug.Log("Defeat!");
    }
}
