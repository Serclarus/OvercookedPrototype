using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs { public ClearCounter selectedCounter; }

    [SerializeField] float moveSpeed;
    [SerializeField] GameInput gameInput;
    [SerializeField] LayerMask countersLayerMask;
    private bool isWalking;
    public Vector3 lastMoveDir;

    ClearCounter selectedCounter;

    private void Awake()
    {
        Instance= this;
    }
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if(selectedCounter != null)
        {
            selectedCounter.Interact();
        }
    }
    
    void Update()
    {
        HandleInteractions();
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * 2, .7f, moveDir, moveDistance);

        //if (canMove) transform.position += moveDir * moveSpeed * Time.deltaTime;

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * 2, .7f, moveDirX, moveDistance);

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
        if (canMove) { transform.position += moveDir * moveDistance; }


        isWalking = moveDir != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        Debug.Log(inputVector);
    }

    public bool IsMoving()
    {
        return isWalking;
    }

    private void HandleInteractions()
    {
        float interactRange = 2f;

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
    
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        if(moveDir != Vector3.zero) { lastMoveDir = moveDir; }

        if (Physics.Raycast(transform.position, lastMoveDir, out RaycastHit raycastHit, interactRange, countersLayerMask))
        {
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
               if (clearCounter != selectedCounter)
                {
                    SetSelectedCounter(selectedCounter);
                }
            } else { SetSelectedCounter(null); }
        }else { SetSelectedCounter(null); }

    }

    void SetSelectedCounter(ClearCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = selectedCounter
        });
    }
}