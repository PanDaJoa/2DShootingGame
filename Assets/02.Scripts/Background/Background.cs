using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float Speed = 1f;

    private void Update()
    {
        // 배경 스크롤
        // -> 게임 화면에서 배경 이미지를 일정한 속도로
        // 움직여 캐릭터나 몬스터 등의 움직임을 더 동적으로 만들어주는 기술
        // (캐릭터는 그대로 두고 배경만 움직여서 캐릭터가 움직이는 거처럼 눈속임을 한다.)

        // 목표: 아래로 이동하고 싶다.
        // 순서:
        // 1. 방향을 구하고
        Vector2 dir = Vector2.down;

        // 2. 이동한다.
        Vector2 newPosition = transform.position + (Vector3)dir * Speed * Time.deltaTime;
        if(newPosition.y < -12.6f)
        {
            newPosition.y = 12.6f;
        }
        transform.position = newPosition;
    }
}
