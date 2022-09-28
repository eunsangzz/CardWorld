using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    //카드 구매버튼 눌렀을때 저장해둔 프리팹중에 랜덤으로 하나 생성 
    //구매 버튼 업그레이드 적용해서 1단계 나무 돌 2단계 철 금 등등 으로 세팅
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CardBuy()//카드 살때
    {
        if(DataController.instance.gameData.storeUpgrade == 0)//업그레이드 없음
        {
            int rand = Random.range(0,4);
            DataController.instance.gameData.card[rand].setActive(ture); //카드 랜덤생성
        }
        if(DataController.instance.gameData.storeUpgrade == 1)// 상점 업그레이드 1단계
        {
            int rand = Random.range(0,10);
            DataController.instance.gameData.card[rand].setActive(ture); //카드 랜덤생성
        }
    }

    public void CardCraft()//무엇을 조합합할지 알아야함 필요한 카드와 수량 조절필요
    {

    }
}
