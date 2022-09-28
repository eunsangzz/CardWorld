using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] CardSet;
    // Start is called before the first frame update
    void Start()
    {
        CardSet = (GameObject[])DataController.instance.gameData.Card.Clone();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
