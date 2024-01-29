using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * 디자인패턴: 옛날부터 소프트웨어 개발 과정에서 발견된 설계 노하우에
 *              이름을 붙여 재사용 하기 좋은 형태로 묶어 정리한 것
 * 장점:
 * - 서로 같은 패턴을 알고 있을 때 의사 소통이 잘된다.(내용, 설계 원칙, 특성, 조건 등)
 * - 모범 사례이므로 가독성 / 유지보수 / 확장성 / 신뢰성 UP
 * 
 * 단점: 
 * - 오용과 남용 (써보고 싶은 마음에 억지로 쓴다.)
 * - 초기에 학습 곡선이 있다. (처음 적용에 시간이 든다.)
 * 
 * 알면 좋은 패턴: 싱글톤, 오브젝트 풀, 상태, 옵저버, 팩토리
 */


// 역할: 점수를 관리하는 점수 관리자
public class ScoreManager : MonoBehaviour
{
    // 목표: 적을 잡을때마다 점수를 올리고, 현재 점수를 UI에 표시하고 싶다.
    // 필요 속성
    // - 현재 점수를 표시할 UI
    public Text ScoreTextUI;
    // - 현재 점수를 기억할 변수
    private int _Score = 0;

    // 최고 점수 관련 속성
    public Text BestScoreTextUI;
    public int BestScore = 0;

    // ScoreManager가 점수를 관리하는 유일한 매니저(관리자)이므로 싱글톤을 적용하는게 편한다.
    public static ScoreManager instance; // ScoreManager 객체

    private void Awake()
    {
        Debug.Log("ScoreManager 객체의 Awake 호출!");
        // 싱글톤 패턴: 오직 한 개의 클래스 인스턴스를 갖도록 보장하고
        //              전역적인 접근점을 제공한다. (아무데서나 쉽게 이 하나의 객체에 접근 가능)
        // 사용 이유: 
        // 게임 개발에서 매니저/관리자 클래스에 싱글톤 패턴을 적용하는 것은 일반적인 관행
        // - 전역 접근, 코드 단순화 (해당 관리자를 찾기 위한 복잡한 로직이 필요 없다.)
        // - 중복 생성 방지 (메모리 및 리소스 관리 능력 UP)

        if (instance == null)
        {
            Debug.Log("새로 생성된 것이다!");
            instance = this;
        }
        else
        {
            Debug.Log("이미 있다.");
            Destroy(gameObject);
        }
    }


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


    // 목표: score 속성에 대한 캡슐화 (get/set)
    public int GetScore() 
    { 
        return _Score; 
    }

    public void AddScore()
    {
        SetScore(_Score + 1);
    }

    public void SetScore(int score)
    {
        // 유효성 검사
        if(score < 0)
        {
            return;
        }
        _Score = score;

        // 목표: 스코어를 화면에 표시한다.
        ScoreTextUI.text = $"점수: {_Score}";


        // 목표: 최고 점수를 갱신하고 UI에 표시하고 싶다.
        // 1. 만약에 현재 점수가 최고 점수보다 크다면
        if (_Score > BestScore)
        {
            // 2. 최고 점수를 갱신하고,
            BestScore = _Score;


            // 목표: 최고 점수를 저장
            // 'PlayerPrefs' 클래스를 사용
            // -> 데이터를 '키(Key)'와 '값(Value)' 형태로 저장하는 클래스
            // 저장할 수 있는 데이터타입: int, float, string
            // 타입별로 저장/로드가 가능한 Set/Get 메서드가 있다.
            PlayerPrefs.SetInt("BestScore", BestScore);


            // 3. UI에 표시한다.
            BestScoreTextUI.text = $"최고 점수: {_Score}";
        }
    }
}




