using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // 목표: 다른 물체와 충돌하면 충돌한 물체를 파괴(삭제)해버린다.
    // 구현순서:
    // 1. 만약에 다른 물체와 충돌하면
    // 2. 충돌한 물체를 파괴해버린다.


    // 1. 만약에 다른 물체와 충돌하면
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // 2. 충돌한 물체를 파괴해버린다.
        Destroy(otherCollider.gameObject);
    }

   
}
