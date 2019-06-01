using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BoardSection{
    Tableau =0,
    OpenCell,
    Foundation
}

public enum House{
    clubs =0,
    diamonds,
    hearts,
    spades
}

public struct Card
{
    public int value;
    public House house;
    public Sprite cardImage;
    public string cardImageName;
    public BoardSection boardSection;
    public Card(int v, House h, string cn, BoardSection bs, Sprite ci)
    {
        value = v;
        house = h;
        cardImageName = cn;
        boardSection = bs;
        cardImage = ci;
    }
}
public class Deck : MonoBehaviour
{
    [SerializeField] private Card[] _Deck = new Card[52];
    [SerializeField] private GameObject[] _Tableau = new GameObject[8];
    [SerializeField] private GameObject _CardDummy;
    [SerializeField] private Sprite[] sprites = new Sprite[52];

    private int CardsPerHouse = 13;
    private int Houses = 4;
    // Initializes any variables or game state before the game starts
    void Awake()
    {
        CreateDeck();
        ShuffleDeck();
    }

    private void ShuffleDeck()
    {
        System.Random r = new System.Random();
       // Knuth shuffle algorithm 
        for (int i = 0; i < _Deck.Length; i++ )
        {
            Card tmpCard = _Deck[i];
            int randomIndex = r.Next(i, _Deck.Length);
            _Deck[i] = _Deck[randomIndex];
            _Deck[randomIndex] = tmpCard;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlaceCardsInBoard();
    }

    private void PlaceCardsInBoard()
    {
         GameObject tmpCard;
         float yoffset=0f;
         float zoffset=0.03f;
         int CardsPerPillar = 7;
         int index=0;
        //place the cards on each pillar
        for (int i = 0; i < _Tableau.Length; i++)
        {
            if (i ==4)CardsPerPillar=6;
            yoffset = 0;
            zoffset=0.03f;
            for (int j = 0; j < CardsPerPillar; j++)
            {                
                //instantiate card
                tmpCard =Instantiate(_CardDummy, new Vector3(_Tableau[i].transform.position.x, _Tableau[i].transform.position.y - yoffset,  _Tableau[i].transform.position.z - zoffset), Quaternion.identity);//_Tableau[i].transform.position.x, _Tableau[i].transform.position.y+2,  _Tableau[i].transform.position.z) );
                tmpCard.name = _Deck[index].cardImageName;
               tmpCard.GetComponent<CardBehaviour>().Instantiate(index);

                //Add to pile
                _Tableau[i].GetComponent<TableauBehaviour>().AddCardToPilar(tmpCard);

               //Update loop variables
                yoffset+=0.5f;
                zoffset+=0.03f;
                index++;
            }

        }
    }    

    public void PrintCards()
    {
        foreach (var card in _Deck)
        {   
            Debug.Log($"val: {card.value}, house: {card.house}, png name: {card.cardImageName}, board sect: {card.boardSection}");
        }
    }

    void CreateDeck(){
             int index = 0;
        //fill in the deck with the 52 cards.
        for (int i = 1; i <= CardsPerHouse; i++)
        {
            for (int j = 0; j < Houses; j++)
            {
                //val, house, name of png, board section
                var name_png = i.ToString() + "_of_"+ (House)j;
                _Deck[index] = new Card(i, (House)j, name_png, (BoardSection)0, sprites[index]);
                index++;
            }
        }
    }

    public Card getCardAt(int index){return _Deck[index];}
}
