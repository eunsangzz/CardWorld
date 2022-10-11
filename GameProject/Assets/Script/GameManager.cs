using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
        DataController.instance.gameData.BasicCardList = new List<GameObject>();
        DataController.instance.gameData.CraftCardList = new List<GameObject>();
        //게임실행시 그 전 데이터 초기화 출시시 삭제
        DataController.instance.gameData.storeUpgrade = 0; //나중에 삭제
        DataController.instance.gameData.WoodCard = 0;
        DataController.instance.gameData.StoneCard = 0;
        DataController.instance.gameData.HouseCard = 0;
        DataController.instance.gameData.gold = 10;

        DataController.instance.gameData.Sell = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
