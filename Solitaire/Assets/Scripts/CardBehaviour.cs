using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour,  IBeginDragHandler, IDragHandler, IEndDragHandler
{
   [SerializeField] private Card card;
    [SerializeField] private SpriteRenderer spriteR;
    [SerializeField] private Sprite img;
    private Deck deck;
    private float AuxiliaryZIndex;
    void Start()
    {
    }

    public void Instantiate(int i){
        deck = FindObjectOfType<Deck>();
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        //now card has all the data i need to know about this card.
        card = deck.getCardAt(i);
        //render card image
        spriteR.sprite = card.cardImage;
    }

    //  void OnMouseDrag()
    // {
    //     Debug.Log("DRAG");
    //     float distance = 10f;
    //     Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
    //     Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //     transform.position = objPosition;
    // }

    private void OnMouseDown()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("ON BEING DRAG");
        AuxiliaryZIndex = transform.position.z;
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
         Debug.Log("ON DRAG");
         //this.transform.position += (Vector3)eventData.position;
                float distance = 10f;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(objPosition.x, objPosition.y, -0.3f);
        
        //throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("ON END DRAG");
        transform.position = new Vector3(transform.position.x, transform.position.y, AuxiliaryZIndex);
       // throw new System.NotImplementedException();
    }
}
