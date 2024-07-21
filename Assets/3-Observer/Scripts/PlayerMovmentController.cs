using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float moveSpeed = 5;
    private bool canMove = true;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!canMove)
            return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 playerPos = transform.position;

        rb.MovePosition(playerPos +  new Vector3(horizontal,0, vertical) * Time.deltaTime * moveSpeed);

    }

    public void OnObjectiveReachedSizeLimit(Objective _objective)
    {
        canMove = false;     
    }

}
