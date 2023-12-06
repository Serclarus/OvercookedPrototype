using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] KitchenObjectsSO KitchenObjectsSO;
    [SerializeField] Transform counterTopPoint;
public void Interact()
    {
        Transform kitchenObjectTransform = Instantiate(KitchenObjectsSO.prefab, counterTopPoint);
        kitchenObjectTransform.localPosition = Vector3.zero;
    }
}
