using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCounter : MonoBehaviour
{
    [SerializeField] GameObject selectedVisual;
    [SerializeField] ClearCounter clearCounter;
    void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if(e.selectedCounter == clearCounter)
        {
            selectedVisual.SetActive(true);
        }else  selectedVisual.SetActive(false);
    }

    void Update()
    {
        
    }
}
