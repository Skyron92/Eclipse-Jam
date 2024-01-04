using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenOption : MonoBehaviour
{
    
    void Start(){
        Screen.fullScreen = true; 
    }

    public void FullScreenClick(){
        Screen.fullScreen = !Screen.fullScreen;
    }

   
}
