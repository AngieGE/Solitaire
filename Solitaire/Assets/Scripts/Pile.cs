using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pile : MonoBehaviour
{
    [SerializeField] protected List<GameObject> _CardsInPile = new List<GameObject>();

    public void AddCardToPilar(GameObject card){
        //Only the cards at the bottom of each pile can allow other cards to join that pile.
        //therefor, only the last card has a collider active. This collider is to check when a card is attached to that card.
        EnableCollider(card);

        if (_CardsInPile.Count == 0)
        {
            card.transform.SetParent(this.transform);
            card.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z-0.03f);
        }else{
            Transform parentTransform = _CardsInPile[_CardsInPile.Count-1].transform;
            card.transform.SetParent(parentTransform);
            card.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y-0.5f, parentTransform.position.z-0.03f);

            //disabe colider of the last card
            DisableCollider( _CardsInPile[_CardsInPile.Count-1]);
        }
        //The supreme parent of the card is this pile object
        card.GetComponent<CardBehaviour>().SupremeParent = this.gameObject;
        _CardsInPile.Add(card);
    }

    public void AddCardToPilar(GameObject cardDraged, GameObject pileManager){
       Debug.Log("Adding card...");
        //Add the card to this pillar
        AddCardToPilar(cardDraged);
        //remove the card from the ex cards pilar list
        pileManager.GetComponent<Pile>().RemoveCardFromList(cardDraged);
        //Enable the collider of the last card of the ex card's pilar
        pileManager.GetComponent<Pile>().EnableLastCardCollider();

    }

    //force the child classes to implement this method
    public abstract bool CheckValidMovement();

    public void RemoveCardFromPile(GameObject card){

    }

    private void DisableCollider(GameObject obj)
    {
        obj.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
    }

    private void EnableCollider(GameObject obj)
    {
        obj.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
    }

    private void EnableLastCardCollider()
    {
        Debug.Log("Enabling new card collider...");

        _CardsInPile[_CardsInPile.Count-1].gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
    }

    private void RemoveCardFromList(GameObject cardToRemove){
        Debug.Log("Removing from old pile...");
        _CardsInPile.Remove(cardToRemove);
    }
}
