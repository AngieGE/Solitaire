using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
   [SerializeField] private Card card;
    [SerializeField] private SpriteRenderer spriteR;
    [SerializeField] private Sprite img;
    private Deck deck;
    
    void Start()
    {
    }

    public void Instantiate(int i){
        deck = FindObjectOfType<Deck>();
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        card = deck.getCardAt(i);
        spriteR.sprite = card.cardImage;
    }
}
