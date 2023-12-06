using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] Transform tomatoPrefab;
    [SerializeField] Transform counterTopPoint;
public void Interact()
    {
        Transform tomatoTransform = Instantiate(tomatoPrefab, counterTopPoint);
        tomatoTransform.localPosition = Vector3.zero;
    }
}
