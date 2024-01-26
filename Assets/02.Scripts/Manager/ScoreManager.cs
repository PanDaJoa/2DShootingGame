using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 역할: 점수를 관리하는 점수 관리자
public class ScoreManager : MonoBehaviour
{
    // 목표: 적을 잡을때마다 점수를 올리고, 현재 점수를 UI에 표시하고 싶다.
    // 필요 속성
    // - 현재 점수를 표시할 UI
    public Text ScoreTextUI;
    // - 현재 점수를 기억할 변수
    public int Score = 0;

    // 최고 점수 관련 속성
    public Text BestScoreTextUI;
    public int BestScore = 0;


    // 목표: 게임을 시작할 때 최고 점수를 불러오고, UI에 표시하고 싶다.
    // 구현 순서:
    // 1. 게임을 시작할 때
    private void Start()
    {
        // 2. 최고 점수를 불러온다.
        BestScore = PlayerPrefs.GetInt("BestScore", 0);

        // 3. UI에 표시한다.
        BestScoreTextUI.text = $"최고 점수: {BestScore}";
    } 













    // 목표: 적을 잡을때마다 점수를 올리고, 현재 점수를 UI에 표시하고 싶다.
    // 구현 순서
    // 1. 만약에 적을 잡으면?
    // 2. 스코어를 증가 시킨다.
    // 3. 스코어를 화면에 표시한다.
}
