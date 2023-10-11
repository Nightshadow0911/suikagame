using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject[] objectPrefab; // ��ü ������
    private GameObject currentObject; // ���� ������ ��ü�� �����ϴ� ����

    private bool isStopped = true;

    private Transform spawnerTransform; // �������� Transform
    public GameObject spawner;
    int indexNumber = 1; // ó�� �ε����� 1�� ����
    private Vector2 _initPos;

    private bool isFollowingSpawner = false; // BallSpawner�� spawner�� ����ٴϴ��� ����

    void Start()
    {
        _initPos = transform.position;
        spawnerTransform = spawner.transform; // �������� Transform �ʱ�ȭ

        Reset();
        SpawnObject();
    }

    void Update()
    {
        if (isStopped)
        {
            ObjectMove();

            // ���콺 ���� ��ư�� Ŭ���ϸ� DropAndSpawn �Լ� ȣ��
            if (Input.GetMouseButtonDown(0))
            {
                DropAndSpawn();
            }
        }
        else
        {
            if (isFollowingSpawner)
            {
                // BallSpawner�� spawner�� ���� �̵�
                Vector3 spawnerPosition = spawnerTransform.position;
                transform.position = new Vector3(spawnerPosition.x, transform.position.y, transform.position.z);
            }
        }
    }

    public void SpawnObject()
    {
        // ��ü�� �����ϰ� �ε����� �ο�
        int i = Random.Range(0, 3);
        GameObject newObject = Instantiate(objectPrefab[i], transform.position, Quaternion.identity);

        newObject.name = "Object" + indexNumber;
        currentObject = newObject;
        indexNumber++; // �ε����� ������Ŵ

        // Rigidbody2D�� �����ͼ� �߷� ���� 0���� ����
        Rigidbody2D rb2d = newObject.GetComponent<Rigidbody2D>();

        if (rb2d != null)
        {
            rb2d.gravityScale = 0.0f; // �߷� ���� 0���� ����
            rb2d.isKinematic = true; // ������ٵ� Ű�׸�ƽ���� �����Ͽ� �������� ����ϴ�.
        }

        // �ݶ��̴� ��Ȱ��ȭ
        Collider2D collider = newObject.GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // ���� �� BallSpawner�� ���� ����ٴϵ��� ����
        isFollowingSpawner = true; // ��ư�� ���� ������ BallSpawner�� ����ٴϵ��� ����
    }

    public void Reset()
    {
        isStopped = true;
        transform.parent = spawner.transform;
        isFollowingSpawner = true; // BallSpawner�� spawner�� ����ٴϵ��� ����
    }

    public void DropAndSpawn()
    {
        if (currentObject != null)
        {
            Rigidbody2D rb2d = currentObject.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.gravityScale = 1.0f;
            }

            // Re-enable the Collider
            Collider2D collider = currentObject.GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = true;
            }

            // You can also reset the isKinematic property if needed
            rb2d.isKinematic = false;
        }

        // Spawn a new object
        SpawnObject();
    }
    private void ObjectMove()
    {
        // Screen ��ǥ���� mousePosition�� World ��ǥ��� �ٲ۴�
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Constrain the x-coordinate to be within the range of -3.0f to 3.0f
        mousePos.x = Mathf.Clamp(mousePos.x, -3.0f, 3.0f);

        // ������Ʈ�� x�θ� �������� �ϱ� ������ y�� ����
        mousePos.y = currentObject.transform.position.y;
        mousePos.z = currentObject.transform.position.z;

        currentObject.transform.position = mousePos;
    }
}