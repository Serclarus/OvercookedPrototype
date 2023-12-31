using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObject {

    public Transform GetKitchenObjectFollowTransform();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();

    public void ClearKtichenObject();

    public bool HasKitchenObject();

}
