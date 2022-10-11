using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject[] BasicCardSet = new GameObject[2];
    public GameObject SellUI;
    //카드 구매버튼 눌렀을때 저장해둔 프리팹중에 랜덤으로 하나 생성 
    //구매 버튼 업그레이드 적용해서 1단계 나무 돌 2단계 철 금 등등 으로 세팅

    private void Update()
    {
        SellCard();
    }

    public void CardBuy()//카드 살때
    {
        Debug.Log("1");
        if(DataController.instance.gameData.storeUpgrade == 0 && DataController.instance.gameData.gold >= 3)//업그레이드 없음
        {
            int rand = Random.Range(0,2);
            float randPosX = Random.Range(-5, 5);
            float randPosY = Random.Range(-4, 4);
            GameObject _Card = Instantiate(BasicCardSet[rand], new Vector3(randPosX, randPosY, 0), Quaternion.identity);
            DataController.instance.gameData.BasicCardList.Add(_Card);
            if (rand == 0) DataController.instance.gameData.WoodCard += 1;
            if (rand == 1) DataController.instance.gameData.StoneCard += 1;
            if (rand == 2) DataController.instance.gameData.BananaTreeCard += 1;
            DataController.instance.gameData.gold -= 3;
        }

        /*if(DataController.instance.gameData.storeUpgrade == 1 && DataController.instance.gameData.gold >= 3)
        {
            int rand = Random.Range(0, 4);
            float randPosX = Random.Range(-5, 5);
            float randPosY = Random.Range(-4, 4);
            GameObject _Card = Instantiate(BasicCardSet[rand], new Vector3(randPosX, randPosY, 0), Quaternion.identity);
            DataController.instance.gameData.BasicCardList.Add(_Card);
            if (rand == 0) DataController.instance.gameData.WoodCard += 1;
            if (rand == 1) DataController.instance.gameData.StoneCard += 1;
            if (rand == 2) DataController.instance.gameData.BananaTreeCard += 1;
            if (rand == 3) DataController.instance.gameData.IronCard += 1;
        }*/
    }

    public void SellActive()
    {
        if (DataController.instance.gameData.Sell == false)
        {
            DataController.instance.gameData.Sell = true;
        }
        else if(DataController.instance.gameData.Sell == true)
        {
            DataController.instance.gameData.Sell = false;
        }
    }

    private void SellCard()
    {
        if (Input.GetMouseButton(0))
        {
            if (DataController.instance.gameData.Sell == true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject touch = hit.transform.gameObject;
                    Destroy(touch);
                    if (touch.name == "Wood(Clone)")
                    {
                        DataController.instance.gameData.gold += 2;
                    }
                    if (touch.name == "Stone(Clone)")
                    {
                        DataController.instance.gameData.gold += 2;
                    }
                    if (touch.name == "Housh(Clone)")
                    {
                        DataController.instance.gameData.gold += 3;
                    }
                }
            }
        }
    }

    public void CardSkill()
    {

    }
}
