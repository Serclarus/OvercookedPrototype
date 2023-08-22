using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameInput gameInput;
    private bool isWalking;
    void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * 2, .7f, moveDir, moveSpeed * Time.deltaTime);
        
        if(canMove) transform.position += moveDir * moveSpeed * Time.deltaTime;
        //should check here
        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * 2, .7f, moveDirX, moveSpeed * Time.deltaTime);

            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * 2, .7f, moveDirZ, moveSpeed * Time.deltaTime);
                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else { }
            }
        }
        if (canMove) { transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * 10); }
        

        isWalking = moveDir != Vector3.zero;
        Debug.Log(inputVector);
    }

    public bool IsMoving()
    {
        return isWalking;
    }
}