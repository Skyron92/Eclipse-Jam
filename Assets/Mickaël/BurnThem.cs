using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnThem : MonoBehaviour
{

    void Update()
    {
        if (!GameManager.Paused)
        {
            foreach (CiviliansAI ai in CiviliansAI.m_AIList)
            {
                float value = transform.position.x * ai.gameObject.transform.position.x + transform.position.y * ai.gameObject.transform.position.y + transform.position.z * ai.gameObject.transform.position.z;
                if (value > 0)
                {
                    ai.isBurning = true;
                }
                else
                {
                    ai.isBurning = false;
                }
            }
            CiviliansAI.FinishThem();
        }
    }
}
