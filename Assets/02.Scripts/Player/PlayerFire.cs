using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // [총알 발사 제작]
    // 목표: 총알을 만들어서 발사하고 싶다.
    // 속성:
    // - 총알 프리팹
    // - 총구
    // 구현 순서
    // 1. 발사 버튼을 누르면
    // 2. 프리팹으로부터 총알을 동적으로 만들고,
    // 3. 만든 총알의 위치를 총구의 위치로 바꾼다.

    [Header("총알 프리팹")]
    public GameObject BulletPrefab;     // 총알 프리팹
    public GameObject SubBulletPrefab;  // 보조 총알 프리팹
    
    [Header("총구들")]
    public GameObject[] Muzzles;     // 총구들
    public GameObject[] SubMuzzles;  // 보조 총구들
  
    [Header("타이머")]
    public float Timer = 10f;
    public const float COOL_TIME = 0.6f;

    public float BoomTimer = 0f;
    public const float BOOM_COOL_TIME = 5f;


    [Header("자동 모드")]
    public bool AutoMode = false;

    public AudioSource FireSource;


    // 생성할 붐 프리팹
    public GameObject BoomPrefab;



    private void Start()
    {
        Debug.Log(Application.dataPath);
        Timer = 0f;
        AutoMode = false;
    }

    void Update()
    {
        // 타이머 계산
        Timer -= Time.deltaTime;

        CheckAutoMode();

        Fire();

        BoomTimer -= Time.deltaTime;

        // 붐 타이머가 0보다 같거나 작고 && 3번 버튼을 누르면
        if(BoomTimer<= 0f && Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            // 붐 타이머 시간을 다시 쿨타임으로..
            BoomTimer = BOOM_COOL_TIME;

            // 붐 프리팹을 씬으로 생성한다.
            GameObject boomObject = Instantiate(BoomPrefab);
            boomObject.transform.position = Vector2.zero;
            boomObject.transform.position = new Vector2(0, 0);
            boomObject.transform.position = new Vector2(0, 1.6f);
        }
    }

    private void CheckAutoMode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("자동 공격 모드");
            AutoMode = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("수동 공격 모드");
            AutoMode = false;
        }
    }

    private void Fire()
    {
        // 1. 타이머가 0보다 작은 상태에서 발사 버튼을 누르거나 자동 공격 모드면
        bool ready = AutoMode || Input.GetKeyDown(KeyCode.Space);
        if (Timer <= 0 && ready)
        {
            FireSource.Play();

            // 타이머 초기화
            Timer = COOL_TIME;

            // 2. 프리팹으로부터 총알을 만든다.
            //GameObject bullet1 = Instantiate(BulletPrefab);
            //GameObject bullet2 = Instantiate(BulletPrefab);

            // 3. 만든 총알의 위치를 총구의 위치로 바꾼다.
            //bullet1.transform.position = Muzzle.transform.position;
            //bullet2.transform.position = Muzzle2.transform.position;


            // 목표: 총구 개수 만큼 총알을 만들고,
            // 만든 총알의 위치를 각 총구의 위치로 바꾼다.
            for (int i = 0; i < Muzzles.Length; i++)
            {
                // 1. 총알을 만들고
                GameObject bullet = Instantiate(BulletPrefab);

                // 2. 위치를 설정한다.
                bullet.transform.position = Muzzles[i].transform.position;
            }

            // 목표: 보조 총구 개수 만큼 보조 총알을 만들고,
            // 만든 보조 총알의 위치를 각 보조 총구의 위치로 바꾼다.
            foreach(GameObject subMuzzle in SubMuzzles)
            {
                // 1. 총알을 만들고
                GameObject subBullet = Instantiate(SubBulletPrefab);

                // 2. 위치를 설정한다.
                subBullet.transform.position = subMuzzle.transform.position;
            }
        }
    }

}
