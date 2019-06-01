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
        _OtherCardDCollider = other.gameObject;
    }
    private void OnCollisionExit(Collision other)
    {
        Debug.Log("eXIT COL");
        _OtherCardDCollider = null;
    }

public GameObject GetOtherCardCollider(){ return _OtherCardDCollider;}


 public Card GetOtherCard(){ //call only when _OtherCardDCollider != null
    return _OtherCardDCollider.transform.parent.gameObject.GetComponent<CardBehaviour>().Getcard();
 }

public GameObject GetOtherCardPileManager(){ //return the object that has the behaviour script for the pile
        if (_OtherCardDCollider.GetComponent<Magnet>()._IsFreeCel) {
            Debug.Log("Is a free cell");
            return _OtherCardDCollider.transform.parent.gameObject;
        }else if(_OtherCardDCollider.transform.parent.name.Contains("fp")){
            Debug.Log("Is a foundation cell");
            //if it is not the first one return the actual behaviour object not the parent
            return _OtherCardDCollider.transform.parent.gameObject;
        }else{
            return _OtherCardDCollider?.transform.parent.gameObject.GetComponent<CardBehaviour>().SupremeParent;
        }
}

    public BoardSection GetBoardSection(){

        if (_OtherCardDCollider.GetComponent<Magnet>()._IsFreeCel){
            return BoardSection.OpenCell;
        } 
        else if(_OtherCardDCollider.transform.parent.name.Contains("fp")){
            return BoardSection.Foundation;
        }else{
            Debug.Log(_OtherCardDCollider.transform.parent.name);
            Debug.Log("Not a free cell");
            return GetOtherCard().boardSection;
        }
    }
    //si la colision es de distintos padres y el left click no esta presionado
}
