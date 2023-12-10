using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] KitchenObjectsSO KitchenObjectsSO;
    [SerializeField] Transform counterTopPoint;
    private KitchenObject kitchenObject;
    [SerializeField] ClearCounter secondClearCounter;
    bool testing;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(kitchenObject != null)
            {
                kitchenObject.SetClearCounter(secondClearCounter);
                //Debug.Log(kitchenObject.GetClearCounter());
            }
        }
    }
    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(KitchenObjectsSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
            kitchenObjectTransform.localPosition = Vector3.zero;

            kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            kitchenObject.SetClearCounter(this);
        }
        else Debug.Log(kitchenObject.GetClearCounter()) ;
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() {        
        return kitchenObject; }

    public void ClearKtichenObject() {
        kitchenObject = null; }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }

}
