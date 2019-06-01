using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauBehaviour : Pile
{
   // [SerializeField] GameObject belly;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     //if there is no card on this pile enable the bellybutton so more cards can join this pile
     if (_CardsInPile.Count == 0)
     {
         EnableCollider(this.gameObject);
     }   
    }

    public override bool CheckValidMovement()
    {
        return true;
    }
}
