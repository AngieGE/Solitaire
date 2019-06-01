using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour,  IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Card card;
    [SerializeField] private SpriteRenderer spriteR;
    [SerializeField] public GameObject SupremeParent;
    [SerializeField] private GameObject _MyMagnet;
    private Deck deck;
    private float AuxiliaryZIndex;
    //this flag was created for the case when the player wants to drag multiple cards at a time
    // they are draggable if this flag is up. 
    //Always checking if it is draggale on update
    [SerializeField] private bool _IsDraggable = true;

    void Start(){
        _MyMagnet = this.gameObject.transform.GetChild(0).gameObject;
    }

    public void Instantiate(int i){
        deck = FindObjectOfType<Deck>();
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        //now card has all the data i need to know about this card.
        card = deck.getCardAt(i);
        //render card image
        spriteR.sprite = card.cardImage;
    }
    //TODO pass all this to the Tableau behaviour class
    private void Update()
    {
        //iterate through all the children of the card ---> while child(0) != null

        Transform trans = transform;
        if (trans.childCount == 1) _IsDraggable=true;

        while (trans.childCount >1)
        {   

            Card childCard = trans.GetChild(1).GetComponent<CardBehaviour>().Getcard();
            // You can move the top card of a pile on the Tableau onto another Tableau pile, if that pile's top card is one higher than the moved card and in a different color. 
            if ( !(card.value == (childCard.value +1)) || card.color == childCard.color ){ // || the color is equal
                    _IsDraggable = false;
            }
            trans = trans.GetChild(1);
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!_IsDraggable) return;

        Debug.Log("ON BEING DRAG");
        AuxiliaryZIndex = transform.position.z;
        Debug.Log(eventData.pointerEnter);

        //TODO if i am dragging more than one card change collider to the most parent one. To the eventData.pointerEnter
        //Remove collider from the last card

    }

    public void OnDrag(PointerEventData eventData)
    {
         if(!_IsDraggable) return;
        // Debug.Log("ON DRAG");
        float distance = 10f;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(objPosition.x, objPosition.y, -0.3f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
         if(!_IsDraggable) return;
         //TODO If i moved more than one card remove collider from intermdiate card
         //TODO Add collider to the last card
        transform.position = new Vector3(transform.position.x, transform.position.y, AuxiliaryZIndex);
         GameObject otherCardCollider = _MyMagnet.GetComponent<Magnet>().GetOtherCardCollider();
         if (otherCardCollider != null)
         {
        //get the board section in order to call the metod that checks if the movement is valid
           
            BoardSection bs = _MyMagnet.GetComponent<Magnet>().GetBoardSection();
            GameObject otherCardPileManager = _MyMagnet.GetComponent<Magnet>().GetOtherCardPileManager();

             bool validMovement=false;
            switch (bs)
            {
                case BoardSection.Foundation:
                    otherCardPileManager.GetComponent<FoundationBehaviour>().SetCardToPlace(card);
                     validMovement = otherCardPileManager.GetComponent<FoundationBehaviour>().CheckValidMovement();
                break;
                case BoardSection.OpenCell:
                     validMovement = otherCardPileManager.GetComponent<OpenCellBehaviour>().CheckValidMovement();
                break;
                case BoardSection.Tableau:
                    validMovement = otherCardPileManager.GetComponent<TableauBehaviour>().CheckValidMovement();
                break;
                default:
                break;
            }
           if (validMovement) ChangeCardOfPile(otherCardPileManager);
           else ResetPosition();

        }else{ // the player dropped the card on an empty space. didnt put the card on top of any other card.
        //return the card back to its original pile
            ResetPosition();
        }
    }

    private void ResetPosition(){
         Transform parentTransform = this.gameObject.transform.parent;
            float yoffset=0.3f;
            if(this.gameObject.transform.parent.name.Contains("oc")) yoffset = 0;
            this.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y - yoffset, parentTransform.position.z-0.03f);
    }

    private void ChangeCardOfPile(GameObject otherCardPileManager)
    {
        Debug.Log("i WANT TO JOIN THIS PILE");
        otherCardPileManager.GetComponent<Pile>().AddCardToPilar(this.gameObject, SupremeParent);    
    }

    public Card Getcard(){return card;}
}
