using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile : MonoBehaviour
{
    [SerializeField] private List<GameObject> _CardsInPile = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCardToPilar(GameObject card){
        
        if (_CardsInPile.Count == 0)
        {
            card.transform.SetParent(this.transform);
            card.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z-0.03f);
        }else{
            Transform parentTransform = _CardsInPile[_CardsInPile.Count-1].transform;
            card.transform.SetParent(parentTransform);
            card.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y-0.5f, parentTransform.position.z-0.03f);
        }
        _CardsInPile.Add(card);
    }
}
