using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCellBehaviour : Pile
{
    [SerializeField] bool _Available = true;
    private Magnet magnet;

    private void Start()
    {
        magnet = this.gameObject.transform.GetChild(0).GetComponent<Magnet>();
        magnet._IsFreeCel = true;
    }
    public OpenCellBehaviour()
    {
    }

    void Update()
    {
        //Free Cell's can only hold a single card at a time.
        _Available = (_CardsInPile.Count ==0)? true: false;

    }

    public override bool CheckValidMovement()
    {
        //Free Cell's can only hold a single card at a time.
        return _Available;
      
    }

    public bool GetAvailability(){return _Available;}

}
