using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Magnet : MonoBehaviour
{
    //quiero guardar la carta con la que collisiono
    [SerializeField] private GameObject _OtherCardDCollider = null;
    [SerializeField] public bool _IsFreeCel ;
    [SerializeField] private BoardSection  bs = 0; // default value, to eliminate the warning

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

        Debug.Log(_OtherCardDCollider.GetComponent<Magnet>().bs);
        if (_OtherCardDCollider.GetComponent<Magnet>().bs == BoardSection.Foundation)
        {
             Debug.Log("Is a foundation cell");
            //if it is not the first one return the actual behaviour object not the parent
            FoundationBehaviour fb = null;
                fb = _OtherCardDCollider.transform.parent.gameObject.GetComponent<FoundationBehaviour>();
                if (fb == null)
                {
                    return _OtherCardDCollider.transform.parent.gameObject.GetComponent<CardBehaviour>().SupremeParent;
                }else{
                   return _OtherCardDCollider.transform.parent.gameObject;
                }
        }
         if (_OtherCardDCollider.GetComponent<Magnet>()._IsFreeCel) {
             Debug.Log("Is a free cell");
             return _OtherCardDCollider.transform.parent.gameObject;
        }
          Debug.Log("Is a tableau");
          TableauBehaviour tb = null;
          tb = _OtherCardDCollider.transform.parent.gameObject.GetComponent<TableauBehaviour>();
          if (tb!= null)
          {  
              Debug.Log("UNO");
              return _OtherCardDCollider.transform.parent.gameObject;
          }else{
              Debug.Log("DOS");
            return  _OtherCardDCollider.transform.parent.gameObject.GetComponent<CardBehaviour>()?.SupremeParent;
          }
}

    public BoardSection GetBoardSection(){

        if (_OtherCardDCollider.GetComponent<Magnet>()._IsFreeCel){
            return BoardSection.OpenCell;
        } 
        else if(_OtherCardDCollider.transform.parent.name.Contains("fp")){
            return BoardSection.Foundation;
        }else{
            return BoardSection.Tableau;
        }
    }
}
