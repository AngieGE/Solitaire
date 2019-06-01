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
    [SerializeField] private bool _moving = false;
    private Deck deck;
    private float AuxiliaryZIndex;

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

    private void OnMouseDown()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       // Debug.Log("ON BEING DRAG");
        AuxiliaryZIndex = transform.position.z;
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("ON DRAG");
        float distance = 10f;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(objPosition.x, objPosition.y, -0.3f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("ON END DRAG");
        transform.position = new Vector3(transform.position.x, transform.position.y, AuxiliaryZIndex);
        GameObject otherCardCollider = _MyMagnet.GetComponent<Magnet>().GetOtherCard();
        if (otherCardCollider != null)
        {
            Debug.Log("i WANT TO JOIN THIS PILE");
            GameObject otherCardParent = otherCardCollider.transform.parent.GetComponent<CardBehaviour>().SupremeParent;
            otherCardParent.GetComponent<Pile>().AddCardToPilar(this.gameObject);
        }else{ // the player dropped the card on an empty space. didnt put the card on top o any other card.
            Transform parentTransform = this.gameObject.transform.parent;
            this.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y-0.5f, parentTransform.position.z-0.03f);

        }
    }



}
