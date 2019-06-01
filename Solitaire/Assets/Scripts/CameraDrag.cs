using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraDrag : MonoBehaviour
{
//  public float panSpeed = 20;
//     public Vector2 XLimit = new Vector2(0,50), YLimit = new Vector2(0, 50); // xMin , xMin & yMin , yMin
//     public Vector3 oldPos, panOrigin;
//     public bool DragUI;


//     void Update()
//     {
//         // Check if the mouse was clicked over a UI element
//         if (EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
//         {
//             Debug.Log("Clicked on the UI");
//             DragUI = true;
//         }

//         if (Input.GetMouseButtonDown(0))
//         {
//                 oldPos = transform.position;
//                 panOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
//         }

//         if (Input.GetMouseButton(0) && !DragUI)
//         {
//             Debug.Log("Clicked on the Object");
//             Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;
//             transform.position = oldPos - pos * panSpeed;
//             transform.position = new Vector3(Mathf.Clamp(transform.position.x, XLimit.x, XLimit.y), Mathf.Clamp(transform.position.y, YLimit.x, YLimit.y), transform.position.z);
//         }

//         if (Input.GetMouseButtonUp(0))
//         {
//             DragUI = false;
//         }
//     }
}
