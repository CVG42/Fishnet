using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;

public class Bullet : NetworkBehaviour 
{
    float timeToDestroy = 5f;
    //public readonly SyncVar<int> ownerId; // Id de quien dispaa

    [Server]
    private void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
            Despawn(gameObject);
    }
}
