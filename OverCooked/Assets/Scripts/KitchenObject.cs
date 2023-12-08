using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] KitchenObjectsSO KitchenObjectsSO;
    private IKitchenObjectParent kitchenObjectParent;
    public KitchenObjectsSO GetKitchenObjectSO() { return KitchenObjectsSO; }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent) 
    {
        if(this.kitchenObjectParent != null) { this.kitchenObjectParent.ClearKitchenObject(); }

        this.kitchenObjectParent = kitchenObjectParent;

        if (kitchenObjectParent.HasKitchenObject() ) { Debug.Log("Hata loooZTNkoVR"); }

        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }
}