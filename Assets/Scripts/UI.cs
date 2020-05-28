using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onDisableUI += OnDisableUI;   
        GameEvents.current.onEnableUI += OnEnableUI;
    }

    //Don't show UI
    private void OnDisableUI(){
        gameObject.SetActive(false);
    }

    //Show UI
    private void OnEnableUI(){
        gameObject.SetActive(true);
    }
    
}
