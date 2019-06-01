using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private bool _IsClicking = false;
    //quiero guardar la carta con la que collisiono
    [SerializeField] private GameObject othercard;
    //[SerializeField]  private Card _thisCard;
   //  [SerializeField]  private GameObject _MySupremeParent;
    private void Start()
    {
       // _thisCard =  this.gameObject.transform.parent.gameObject.GetComponent<CardBehaviour>().SupremeParent;
      // _MySupremeParent = this.gameObject.transform.parent.gameObject.GetComponent<CardBehaviour>().SupremeParent;
    }

    private void OnCollisionEnter(Collision other)
    {
      Debug.Log("Two decks collided");
        GameObject theOtherSupremeParent =  other.gameObject.transform.parent.gameObject.GetComponent<CardBehaviour>().SupremeParent;
    //    if (_MySupremeParent != theOtherSupremeParent) { }
        othercard = other.gameObject;

    }
    private void OnCollisionExit(Collision other)
    {
        Debug.Log("eXIT COL");
                othercard = null;
    }
    private void OnMouseUp() //called when mouse released after dragging
    {
        Debug.Log("Finished Dragging");
        _IsClicking = false;
    }
    
    private void OnMouseDown() //called when mouse clock for dragging
    {
        Debug.Log("Finished Dragging");
        _IsClicking=true;
    }


public GameObject GetOtherCard(){ return othercard;}
    //si la colision es de distintos padres y el left click no esta presionado
}
