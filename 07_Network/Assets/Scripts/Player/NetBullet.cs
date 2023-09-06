using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetBullet : NetworkBehaviour
{
    public float speed = 10.0f;
    public float lifeTime = 5.0f;
    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public override void OnNetworkSpawn()
    {
        rigid.velocity = speed * transform.forward;
        StartCoroutine(SelfDespawn());
    }

    IEnumerator SelfDespawn()
    {
        yield return new WaitForSeconds(lifeTime);

        this.NetworkObject.Despawn();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!this.NetworkObject.IsSpawned)
            return;

        // 스폰 이후에만 동작
        Debug.Log($"충돌 : {collision.gameObject.name}");
        this.NetworkObject.Despawn();
    }
}
