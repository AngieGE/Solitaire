using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private bool _IsClicking = false;
    //quiero guardar la carta con la que collisiono
    [SerializeField] private GameObject _OtherCardDCollider = null;


    private void OnCollisionEnter(Collision other)
    {
      Debug.Log("Two decks collided");
        GameObject theOtherSupremeParent =  other.gameObject.transform.parent.gameObject.GetComponent<CardBehaviour>().SupremeParent;
    //    if (_MySupremeParent != theOtherSupremeParent) { }
        _OtherCardDCollider = other.gameObject;

    }
    private void OnCollisionExit(Collision other)
    {
        Debug.Log("eXIT COL");
        _OtherCardDCollider = null;
    }

public GameObject GetOtherCardCollider(){ return _OtherCardDCollider;}


//call only when _OtherCardDCollider != null
 public Card GetOtherCard(){
    return _OtherCardDCollider.transform.parent.gameObject.GetComponent<CardBehaviour>().Getcard();
 }

public GameObject GetOtherCardPileManager(){ 
    return _OtherCardDCollider?.transform.parent.gameObject.GetComponent<CardBehaviour>().SupremeParent;
}
    //si la colision es de distintos padres y el left click no esta presionado
}
