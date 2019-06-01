using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundationBehaviour : Pile
{
        [SerializeField] bool _FirstCard = true;
        [SerializeField] Card _CardToPlace;
        [SerializeField] private House _PileHouse;

    public override bool CheckValidMovement()
    {   //descard the card if the house doesnt match the pile
        if (_CardToPlace.house != _PileHouse)return false;
        if (_FirstCard && _CardToPlace.value !=1)return false;
        //It is the first card, it is an ace. No need to check for the house again...
        if (_FirstCard && _CardToPlace.value == 1 )return true;
        //if the card is the next ascending value
        if (_CardToPlace.value == _CardsInPile[_CardsInPile.Count-1].GetComponent<CardBehaviour>().Getcard().value +1)
        {
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetCardToPlace(Card c){
        _CardToPlace = c;
    }

    // Update is called once per frame
    void Update()
    {
        if (_CardsInPile.Count == 0)
        {
            _FirstCard=true;
        }else{
            _FirstCard=false;
        }
    }
}
