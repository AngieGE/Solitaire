using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCondition : MonoBehaviour
{
    [SerializeField] private GameObject[] _FoundationPiles = new GameObject[4];

    // Update is called once per frame
    void Update()
    {

        if (_FoundationPiles[0].GetComponent<Pile>().GetLastValueCard() == 13 &&
            _FoundationPiles[1].GetComponent<Pile>().GetLastValueCard() == 13 &&
            _FoundationPiles[2].GetComponent<Pile>().GetLastValueCard() == 13 &&
            _FoundationPiles[3].GetComponent<Pile>().GetLastValueCard() == 13)
        {
            Debug.Log("YOU WIN");
        }
    }
}
