using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameInput gameInput;
    [SerializeField] LayerMask countersLayerMask;
    private bool isWalking;
    public Vector3 lastMoveDir;


    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        if (moveDir != Vector3.zero) { lastMoveDir = moveDir; }

        if (Physics.Raycast(transform.position, lastMoveDir, out RaycastHit raycastHit, 2, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }
        }
    }
    //
    void Update()
    {
        HandleInteractions();
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * 2, .7f, moveDir, moveSpeed * Time.deltaTime);

        if (canMove) transform.position += moveDir * moveSpeed * Time.deltaTime;

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

    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
    
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        if(moveDir != Vector3.zero) { lastMoveDir = moveDir; }

        if (Physics.Raycast(transform.position, lastMoveDir, out RaycastHit raycastHit, 2, countersLayerMask))
        {
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
               // clearCounter.Interact();
            }
        }


    }

}