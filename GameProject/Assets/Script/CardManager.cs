using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject[] BasicCardSet = new GameObject[2];
    //카드 구매버튼 눌렀을때 저장해둔 프리팹중에 랜덤으로 하나 생성 
    //구매 버튼 업그레이드 적용해서 1단계 나무 돌 2단계 철 금 등등 으로 세팅
    
    public void CardBuy()//카드 살때
    {
        if(DataController.instance.gameData.storeUpgrade == 0)//업그레이드 없음
        {
            int rand = Random.Range(0,2);
            float randPosX = Random.Range(-5, 5);
            float randPosY = Random.Range(-4, 4);
            GameObject _Card = Instantiate(BasicCardSet[rand], new Vector3(randPosX, randPosY, 0), Quaternion.identity);
            DataController.instance.gameData.BasicCardList.Add(_Card);
            if (rand == 0) DataController.instance.gameData.WoodCard += 1;
            if (rand == 1) DataController.instance.gameData.StoneCard += 1;
        }
    }

    public void ClearCard()
    {
        
    }
}
