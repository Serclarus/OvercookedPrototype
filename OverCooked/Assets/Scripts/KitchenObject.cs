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
        this.clearCounter = clearCounter;
    }

    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}