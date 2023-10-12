# 담당
B04 조병우
# 프로젝트 소개
게임 캐릭터의 이미지를 사용하여 만들어졌으며,

수박 게임의 형식인 게임으로 같은 그림끼리 부딪히면 더 큰 공이 만들어지고 이를 계속 만들어가면 됩니다.

# 개발 기간
2023.10.09 ~ 2023.10.12


# 게임 설명
![image](https://github.com/Nightshadow0911/suikagame/assets/99133865/9eca24c2-81fc-49c7-b75b-92e330792381)

위와 같은 수박 게임으로 같은 크기, 같은 그림의 공이 부딪히면 다음 크기의 공으로 바뀌고 점점 키우는 형식

마우스가 움직이면 클릭하기 전까지 공이 마우스를 따라 좌우로 이동하여 원하는 위치에서 클릭시 공이 떨어지기 시작.

같은 태그를 달고있는 공이 부딪히면 모든 공에 인덱스 번호가 부여되어 있어 두 공은 모두 파괴된 후 다음 공을 하나만 생성.

    
int GetNumberFromName(string name)
    {
        int number = 0;
        int startIndex = name.IndexOf("Object") + 6;
        if (startIndex >= 0)
        {
            string numberStr = name.Substring(startIndex);
            int.TryParse(numberStr, out number);
        }
        return number;
    }
    
    void BigHandleCollisionBall1(Collision2D collision)
    {
        indexNumber++;
        GameObject newObject = Instantiate(ball2, collision.contacts[0].point, Quaternion.identity);
        newObject.name = "Object" + indexNumber;
        currentObject = newObject;
        Debug.Log(indexNumber);
        Destroy(gameObject);
    }

    void SmallHandleCollisionBall1(Collision2D collision)
    {
        Destroy(gameObject);
    }
}


