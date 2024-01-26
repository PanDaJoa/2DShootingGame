using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background2 : MonoBehaviour
{
    // 목표: 머터리얼의 오프셋을 이용해서 배경 스크롤이 되도록 하고 싶다.
    // 필요 속성
    // - 머터리얼
    // - 스크롤 속도
    public Material MyMaterial;
    public float ScrollSpeed = 0.2f;

    // 구현 순서
    // 0. 매 프레임마다
    private void Update()
    {
        // 1. 방향을 구한다.
        Vector2 dir = Vector2.up;

        // 2. (오프셋을 변경해서) 스크롤을 한다.
        MyMaterial.mainTextureOffset += dir * ScrollSpeed * Time.deltaTime; 
    }
}
