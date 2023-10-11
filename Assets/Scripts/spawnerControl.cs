using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerControl : MonoBehaviour
{
    public float spawnerSpeed = 5f; //생성 위치 이동속도
    public GameObject spawner; // 생성된 공의 참조
    public Transform playerSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            Vector3 currentScale = playerSpawner.localScale;
            float spawnerHalfLength = currentScale.x / 2f;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);

            float screenWidth = 3.0f;
            float clampX = Mathf.Clamp(transform.position.x, -screenWidth + spawnerHalfLength, transform.position.z);

            transform.position = new Vector3(clampX, transform.position.y, transform.position.z);
    }
}
