using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Connection;

public class Weapon : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;

    void Update()
    {
        if (!IsOwner) return; // para que solo dispare el duen~o

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootServerRPC();
        }
    }

    [ServerRpc] // avisar al servidor que va a disparar y este lo genere y se sincronice con todos los jugadores
    void ShootServerRPC()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position + transform.right, Quaternion.identity);
        // Modificar todas las variables SyncVar
        // newBullet.GetComponent<Bullet>().ownerId.Value = ownerId;
        newBullet.GetComponent<Rigidbody>().velocity = Vector3.right * bulletSpeed;
        ServerManager.Spawn(newBullet); // Al final, se le avisa a todos los clientes de la nueva bala
    }
}
