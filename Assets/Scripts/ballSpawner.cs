using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject[] objectPrefab; // 물체 프리팹
    private GameObject currentObject; // 현재 생성된 물체를 추적하는 변수

    private bool isStopped = true;

    private Transform spawnerTransform; // 스포너의 Transform
    public GameObject spawner;
    int indexNumber = 1; // 처음 인덱스를 1로 설정
    private Vector2 _initPos;

    private bool isFollowingSpawner = false; // BallSpawner가 spawner를 따라다니는지 여부

    void Start()
    {
        _initPos = transform.position;
        spawnerTransform = spawner.transform; // 스포너의 Transform 초기화

        Reset();
        SpawnObject();
    }

    void Update()
    {
        if (isStopped)
        {
            ObjectMove();

            // 마우스 왼쪽 버튼을 클릭하면 DropAndSpawn 함수 호출
            if (Input.GetMouseButtonDown(0))
            {
                DropAndSpawn();
            }
        }
        else
        {
            if (isFollowingSpawner)
            {
                // BallSpawner가 spawner를 따라 이동
                Vector3 spawnerPosition = spawnerTransform.position;
                transform.position = new Vector3(spawnerPosition.x, transform.position.y, transform.position.z);
            }
        }
    }

    public void SpawnObject()
    {
        // 물체를 생성하고 인덱스를 부여
        int i = Random.Range(0, 3);
        GameObject newObject = Instantiate(objectPrefab[i], transform.position, Quaternion.identity);

        newObject.name = "Object" + indexNumber;
        currentObject = newObject;
        indexNumber++; // 인덱스를 증가시킴

        // Rigidbody2D를 가져와서 중력 값을 0으로 설정
        Rigidbody2D rb2d = newObject.GetComponent<Rigidbody2D>();

        if (rb2d != null)
        {
            rb2d.gravityScale = 0.0f; // 중력 값을 0으로 설정
            rb2d.isKinematic = true; // 리지드바디를 키네매틱으로 설정하여 움직임을 멈춥니다.
        }

        // 콜라이더 비활성화
        Collider2D collider = newObject.GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // 생성 후 BallSpawner가 공을 따라다니도록 변경
        isFollowingSpawner = true; // 버튼을 누를 때까지 BallSpawner가 따라다니도록 변경
    }

    public void Reset()
    {
        isStopped = true;
        transform.parent = spawner.transform;
        isFollowingSpawner = true; // BallSpawner가 spawner를 따라다니도록 리셋
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
        // Screen 좌표계인 mousePosition을 World 좌표계로 바꾼다
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Constrain the x-coordinate to be within the range of -3.0f to 3.0f
        mousePos.x = Mathf.Clamp(mousePos.x, -3.0f, 3.0f);

        // 오브젝트는 x로만 움직여야 하기 때문에 y는 고정
        mousePos.y = currentObject.transform.position.y;
        mousePos.z = currentObject.transform.position.z;

        currentObject.transform.position = mousePos;
    }
}