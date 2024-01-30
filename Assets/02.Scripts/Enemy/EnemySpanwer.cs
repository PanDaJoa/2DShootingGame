using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    // 역할: 일정시간마다 적을 프리팹으로부터 생성해서 내 위치에 갖다 놓고 싶다.
    // 필요 속성:
    // - 적 프리팹
    // - 일정시간
    // - 현재시간
    public GameObject EnemyPrefab;         // - Basic
    public GameObject EnemyPrefabTarget;   // - Target
    public GameObject EnemyPrefabFollow;   // - Follow

    public float SpawnTime = 1.2f;
    public float CurrentTimer = 0f;

    // - 풀 사이즈
    public int PoolSize = 15;
    // - 오브젝트(Enemy) 풀(창고)
    private List<Enemy> EnemyPool;

    // 목표: 적 생성 시간을 랜덤하게 하고 싶다.
    // 필요 속성:
    // - 최소 시간
    // - 최대 시간
    public float MinTime = 0.5f;
    public float MaxTime = 1.5f;

    private void Start()
    {
        // 시작할 때 적 생성 시간을 랜덤하게 설정한다.
        SetRandomTime();
    }

    private void Awake()
    {
        EnemyPool = new List<Enemy>();
        // (생서 -> 끄고 -> 넣는다) * PoolSize(15).
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject enemyObject = Instantiate(EnemyPrefab);
            enemyObject.SetActive(false);
            EnemyPool.Add(enemyObject.GetComponent<Enemy>());
        }
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject enemyObject = Instantiate(EnemyPrefabTarget);
            enemyObject.SetActive(false);
            EnemyPool.Add(enemyObject.GetComponent<Enemy>());
        }
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject enemyObject = Instantiate(EnemyPrefabFollow);
            enemyObject.SetActive(false);
            EnemyPool.Add(enemyObject.GetComponent<Enemy>());
        }


    }

    private void SetRandomTime()
    {
        SpawnTime = Random.Range(MinTime, MaxTime);
    }

    void Update()
    {
        // 구현 순서:
        // 1. 시간이 흐르다가
        CurrentTimer += Time.deltaTime;

        // 2. 만약에 시간이 일정시간이 되면
        if(CurrentTimer >= SpawnTime)
        {
            // 3. 프리팹으로부터 적을 생성한다.
            // 30% 확률로 Target형, 나머지 확률(70%) Basic형 적 생성하게 하기
            Enemy enemy = null;
            int randomNumber = Random.Range(0, 10);  // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            if(randomNumber < 1)
            {
                foreach(Enemy e in EnemyPool)
                {
                    if(e.gameObject.activeInHierarchy == false && e.EType == EnemyType.Follow)
                    {
                        enemy = e; 
                        break;
                    }
                }
            }
            else if(randomNumber < 4)
            {
                foreach (Enemy e in EnemyPool)
                {
                    if (e.gameObject.activeInHierarchy == false && e.EType == EnemyType.Target)
                    {
                        enemy = e;
                        break;
                    }
                }
            }
            else
            {
                foreach (Enemy e in EnemyPool)
                {
                    if (e.gameObject.activeInHierarchy == false && e.EType == EnemyType.Basic)
                    {
                        enemy = e;
                        break;
                    }
                }
            }




            // 4. 생성한 적의 위치를 내 위치로 바꾼다.

            
            enemy.transform.position = this.transform.position;

            enemy.gameObject.SetActive(true);

            // 타이머 초기화
            CurrentTimer = 0f;

            // 적 생성 시간을 랜덤하게 설정
            SetRandomTime();
        }
    }
}
