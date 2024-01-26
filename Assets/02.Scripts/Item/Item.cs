using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    private const float EAT_TIME    = 1f;
    private const float FOLLOW_TIME = 3f;


    private float _timer = 0f; // 시간을 체크할 변수

    public int MyType = 0;     // 0: 체력을 올려주는 타입, 1: 스피드를 올려주는 타입

    public Animator MyAnimator;

    public GameObject EatVFXPrefab;

    private void Start()
    {
        _timer = 0f;

        MyAnimator = GetComponent<Animator>();

        MyAnimator.SetInteger("ItemType", (int)MyType);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= FOLLOW_TIME)
        {
            // 1. 플레이어 게임오브젝를 찾고
            GameObject target = GameObject.FindGameObjectWithTag("Player");
            
            // 2. 방향을 정하고,
            Vector3 dir = target.transform.position - this.transform.position;
            dir.Normalize();

            // 3. 스피드에 맞게 이동
            Vector3 newPosition = transform.position + dir * 10f * Time.deltaTime;
            this.transform.position = newPosition;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collison Enter!");
    }

    // (다른 콜라이더에 의해) 트리거가 발동될 때 
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("트리거 시작!");
    }


    // (다른 콜라이더에 의해) 트리거가 발동 중일때
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        _timer += Time.deltaTime;
       
        if(_timer >= EAT_TIME)
        {
            if(MyType == 0) 
            {
                Player player = otherCollider.GetComponent<Player>();
                player.Health += 1;
            }
            else if(MyType == 1) 
            {
                // 타입이 1이면 플레이어의 스피드올려주기
                PlayerMove playerMove = otherCollider.GetComponent<PlayerMove>();
                playerMove.Speed += 0.0001f;
            }

            GameObject vfx = Instantiate(EatVFXPrefab);
            vfx.transform.position = otherCollider.transform.position;

            Destroy(this.gameObject);
        }

       // Debug.Log("트리거 중!");
    }
    // (다른 콜라이더에 의해) 트리거가 끝났을때
    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        _timer = 0f;
        Debug.Log("트리거 종료!");
    }

}
