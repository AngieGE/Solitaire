using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("TOUCHING ME");
        if (Input.GetMouseButton(0))
        {
             Debug.Log(" MOUSE BUTTON");
        }
        if(Input.GetMouseButtonDown(0)){
            Debug.Log(" MOUSE BUTTON DOWM");
        }
    }
}
