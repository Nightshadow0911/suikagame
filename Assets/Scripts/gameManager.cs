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
        if (!isDefeat) // ������ �й����� �ʾҴٸ�
        {
            // Y�� 3.0f���� ���̸� �߻�
            Ray ray = new Ray(new Vector3(0, 3.0f, 0), Vector3.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // �浹�� ���� ������Ʈ�� �±׸� Ȯ��
                foreach (string targetTag in targetTags)
                {
                    if (hit.collider.CompareTag(targetTag))
                    {
                        timer += Time.deltaTime;

                        if (timer >= 5f)
                        {
                            Defeat();
                            isDefeat = true; // �й� ���·� ����
                            break;
                        }
                    }
                }
            }
            else
            {
                // ���̰� ��ü�� ���� ������ Ÿ�̸� �ʱ�ȭ
                timer = 0f;
            }
        }
    }

    void Defeat()
    {
        // �й� �� ������ �ڵ�
        Debug.Log("Defeat!");
    }
}
