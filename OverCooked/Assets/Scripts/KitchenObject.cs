using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] KitchenObjectsSO KitchenObjectsSO;
    private IKitchenObject kitchenObjectParent;
    public KitchenObjectsSO GetKitchenObjectSO() { return KitchenObjectsSO; }

    public void SetKitchenObjectParent(IKitchenObject kitchenObjectParent) 
    {
        if(this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKtichenObject();
        }

        this.kitchenObjectParent = kitchenObjectParent;
        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition= Vector3.zero;
    }

    public IKitchenObject GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }
}