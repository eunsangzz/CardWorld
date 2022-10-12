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
        DataController.instance.gameData.BananaCard = 0;
        DataController.instance.gameData.BananaTreeCard = 0;
        DataController.instance.gameData.TreeCard = 0;
        DataController.instance.gameData.RockCard = 0;
        DataController.instance.gameData.gold = 100;
        DataController.instance.gameData.CardLimit =15;
        DataController.instance.gameData.CardCount = 0;

        DataController.instance.gameData.Sell = false;
        DataController.instance.gameData.Skill = false;
    }

    // Update is called once per frame
    void Update()
    {
        DataController.instance.gameData.CardCount = (DataController.instance.gameData.WoodCard + DataController.instance.gameData.StoneCard +
        DataController.instance.gameData.TreeCard + DataController.instance.gameData.RockCard + DataController.instance.gameData. BananaTreeCard + DataController.instance.gameData.IronCard +
        DataController.instance.gameData.GoldCard + DataController.instance.gameData.HouseCard);
    }
}
