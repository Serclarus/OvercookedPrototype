using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] KitchenObjectsSO KitchenObjectsSO;
    private ClearCounter clearCounter;
    public KitchenObjectsSO GetKitchenObjectSO() { return KitchenObjectsSO; }

    public void SetClearCounter(ClearCounter clearCounter) 
    {
        if(this.clearCounter != null) { this.clearCounter.ClearKitchenObject(); }

        this.clearCounter = clearCounter;

        if (clearCounter.HasKitchenObject() ) { Debug.Log("Hata looo ZTNkoVR"); }

        clearCounter.SetKitchenObject(this);

        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}