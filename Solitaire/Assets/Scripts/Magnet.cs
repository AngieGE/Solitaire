using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    //quiero guardar la carta con la que collisiono
    [SerializeField] private GameObject _OtherCardDCollider = null;
    [SerializeField] public bool _IsFreeCel ;


    private void OnCollisionEnter(Collision other)
    {
      Debug.Log("Two decks collided");
    //   CardBehaviour cb = other.gameObject.transform.parent.gameObject.GetComponent<CardBehaviour>();
    //   if (cb != null)
    //   {  
    //     GameObject theOtherSupremeParent =  cb.SupremeParent;
    //   }else{

    //   }
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

public GameObject GetOtherCardPileManager(){ //return the object that has the behaviour script for the pile
        if (_OtherCardDCollider.GetComponent<Magnet>()._IsFreeCel) {
            return _OtherCardDCollider.transform.parent.gameObject;
        }
        else{
            Debug.Log("Not a free cell");
            return _OtherCardDCollider?.transform.parent.gameObject.GetComponent<CardBehaviour>().SupremeParent;
        }
}

    public BoardSection GetBoardSection(){

        if (_OtherCardDCollider.GetComponent<Magnet>()._IsFreeCel) return BoardSection.OpenCell;
        else{
            Debug.Log("Not a free cell");
            return GetOtherCard().boardSection;
        }
    }
    //si la colision es de distintos padres y el left click no esta presionado
}
