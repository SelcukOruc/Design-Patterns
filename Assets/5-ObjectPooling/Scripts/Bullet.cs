using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    Vector3 dir;
    Rigidbody rb;
    [SerializeField] private float moveSpeed = 1.0f;
    private void Awake()=> rb = GetComponent<Rigidbody>();

    public void SetInfo(Vector3 _dir)=> dir = _dir;

    private void FixedUpdate()
    {
        if (dir == null)
        {
            Debug.Log("NULL");
            return;
        }

        rb.MovePosition(rb.position + dir * Time.fixedDeltaTime * (moveSpeed));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Wall _wall))
            PoolManager.ReturnPooledObject(PREFAB_NAMES.BULLET, this);
    }

    public void OnRetrieved()
    {
        if (returnToPoolCor == null)
            StartCoroutine(IReturnToPool());

        Debug.Log("Bullet Retrieved!");
    }

    public void OnReturnedPool()
    {
        if (returnToPoolCor != null)
        {
            StopCoroutine(IReturnToPool());
            returnToPoolCor = null;
        }

        Debug.Log("Bullet Returned To Pool!");
    }

    Coroutine returnToPoolCor = null;
    WaitForSeconds returnTime = new WaitForSeconds(3);
    IEnumerator IReturnToPool()
    {
        yield return returnTime;
        PoolManager.ReturnPooledObject(PREFAB_NAMES.BULLET, this);
    }

}
