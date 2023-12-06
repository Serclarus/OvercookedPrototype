using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] KitchenObjectsSO KitchenObjectsSO;

    public KitchenObjectsSO GetKitchenObjectSO() { return KitchenObjectsSO; }
}
