using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform bulletPoolParent;
    [SerializeField] private int poolLenght = 30;

    private void Start()
    {
        PoolManager.CreatePool<Bullet>(30,PREFAB_NAMES.BULLET);
        
    }


    [SerializeField] private Bullet tankBulletPrefab;
    [SerializeField] private Transform turret,firePoint;
    [SerializeField] private float turretRotateSpeed = 100f;
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            turret.Rotate(0, turretRotateSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.LeftArrow))
            turret.Rotate(0, -turretRotateSpeed * Time.deltaTime, 0);
        else if (Input.GetKeyDown(KeyCode.Space))
            FireBullet();
    }

    void FireBullet()
    {
        Bullet tankBulletCreated = PoolManager.GetPooledObject<Bullet>(PREFAB_NAMES.BULLET);
        tankBulletCreated.transform.position = firePoint.position;
        tankBulletCreated.SetInfo(transform.TransformDirection(firePoint.position));
    }
}
