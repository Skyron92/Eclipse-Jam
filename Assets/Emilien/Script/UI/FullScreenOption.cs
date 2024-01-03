using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenOption : MonoBehaviour
{
    
    void Start(){
        Screen.fullScreen = !Screen.fullScreen; 
    }

    public void FullScreenClick(){
        Screen.fullScreen = !Screen.fullScreen;
    }

   
}
