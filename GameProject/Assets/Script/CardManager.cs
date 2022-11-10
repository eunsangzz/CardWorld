using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour
{
    public GameObject PlayerCard;
    public GameObject[] BasicCardSet = new GameObject[6];
    public GameObject SellUI;

    public GameObject tutoSell;
    public GameObject tutoBuy;
    public GameObject tutoUi;

    bool tutobuy;
    bool tutosell;
    //카드 구매버튼 눌렀을때 저장해둔 프리팹중에 랜덤으로 하나 생성 
    //구매 버튼 업그레이드 적용해서 1단계 나무 돌 2단계 철 금 등등 으로 세팅

    private void Start()
    {
        tutobuy = false;
        tutosell = false;
        for (int i = 0; i < 2; i++)
        {
            GameObject _Card = Instantiate(PlayerCard, new Vector3(3, 3, 0), Quaternion.identity);
        }
    }

    private void Update()
    {
        SellCard();
    }

    public void CardBuy()//카드 살때
    {
        if(DataController.instance.gameData.tuto == true && tutobuy == false)
        {
            Time.timeScale =0;
            tutoUi.SetActive(true);
            tutoBuy.SetActive(true);
            tutobuy = true; 
        }
        if (DataController.instance.gameData.storeUpgrade == 0 && DataController.instance.gameData.gold >= 3)//업그레이드 없음
        {
            int rand = Random.Range(0, 5);
            float randPosX = Random.Range(-5.0f, 5.0f);
            float randPosY = Random.Range(-4.0f, 4.0f);
            GameObject _Card = Instantiate(BasicCardSet[rand], new Vector3(randPosX, randPosY, 0), Quaternion.identity);
            DataController.instance.gameData.BasicCardList.Add(_Card);
            if (rand == 0) DataController.instance.gameData.WoodCard += 1;
            if (rand == 1) DataController.instance.gameData.StoneCard += 1;
            if (rand == 2) DataController.instance.gameData.TreeCard += 1;
            if (rand == 3) DataController.instance.gameData.RockCard += 1;
            if (rand == 4) DataController.instance.gameData.BananaTreeCard += 1;
            if (rand == 5) DataController.instance.gameData.BananaCard += 1;
            DataController.instance.gameData.gold -= 3;
        }
        if (DataController.instance.gameData.storeUpgrade == 1 && DataController.instance.gameData.gold >= 3)//업그레이드 없음
        {
            int rand = Random.Range(0, 5);
            float randPosX = Random.Range(-5.0f, 5.0f);
            float randPosY = Random.Range(-4.0f, 4.0f);
            GameObject _Card = Instantiate(BasicCardSet[rand], new Vector3(randPosX, randPosY, 0), Quaternion.identity);
            DataController.instance.gameData.BasicCardList.Add(_Card);
            if (rand == 0) DataController.instance.gameData.WoodCard += 1;
            if (rand == 1) DataController.instance.gameData.StoneCard += 1;
            if (rand == 2) DataController.instance.gameData.TreeCard += 1;
            if (rand == 3) DataController.instance.gameData.RockCard += 1;
            if (rand == 4) DataController.instance.gameData.BananaTreeCard += 1;
            if (rand == 5) DataController.instance.gameData.BananaCard += 1;
            DataController.instance.gameData.gold -= 3;
        }
        if (DataController.instance.gameData.storeUpgrade == 2 && DataController.instance.gameData.gold >= 3)//업그레이드 없음
        {
            int rand = Random.Range(0, 5);
            float randPosX = Random.Range(-5.0f, 5.0f);
            float randPosY = Random.Range(-4.0f, 4.0f);
            GameObject _Card = Instantiate(BasicCardSet[rand], new Vector3(randPosX, randPosY, 0), Quaternion.identity);
            DataController.instance.gameData.BasicCardList.Add(_Card);
            if (rand == 0) DataController.instance.gameData.WoodCard += 1;
            if (rand == 1) DataController.instance.gameData.StoneCard += 1;
            if (rand == 2) DataController.instance.gameData.TreeCard += 1;
            if (rand == 3) DataController.instance.gameData.RockCard += 1;
            if (rand == 4) DataController.instance.gameData.BananaTreeCard += 1;
            if (rand == 5) DataController.instance.gameData.BananaCard += 1;
            DataController.instance.gameData.gold -= 3;
        }

    }

    public void SellActive()
    {
        if(DataController.instance.gameData.tuto == true && tutosell == false)
        {
            Time.timeScale =0;
            tutoUi.SetActive(true);
            tutoSell.SetActive(true);
            tutosell = true;
        }
        if (DataController.instance.gameData.Sell == false)
        {
            DataController.instance.gameData.Sell = true;
        }
        else if (DataController.instance.gameData.Sell == true)
        {
            DataController.instance.gameData.Sell = false;
        }
    }

    public void endDaySellCard()
    {
        if (DataController.instance.gameData.endDay == true)
        {
            DataController.instance.gameData.Sell = true;
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
                        DataController.instance.gameData.WoodCard -= 1;
                    }
                    if (touch.name == "Stone(Clone)")
                    {
                        DataController.instance.gameData.gold += 2;
                        DataController.instance.gameData.StoneCard -= 1;
                    }
                    if (touch.name == "Tree(Clone)")
                    {
                        DataController.instance.gameData.gold += 2;
                        DataController.instance.gameData.TreeCard -= 1;
                    }
                    if (touch.name == "Rock(Clone)")
                    {
                        DataController.instance.gameData.gold += 2;
                        DataController.instance.gameData.RockCard -= 1;
                    }
                    if (touch.name == "BananaTree(Clone)")
                    {
                        DataController.instance.gameData.gold += 2;
                        DataController.instance.gameData.BananaTreeCard -= 1;
                    }
                    if (touch.name == "Banana(Clone)")
                    {
                        DataController.instance.gameData.gold += 1;
                        DataController.instance.gameData.BananaCard -= 1;
                    }
                    if (touch.name == "House(Clone)")
                    {
                        DataController.instance.gameData.gold += 3;
                        DataController.instance.gameData.HouseCard -= 1;
                    }
                }
            }
        }
    }

    public void CardSkill()
    {
        string Btn = EventSystem.current.currentSelectedGameObject.name;

        if (Btn == "Tree")
        {
            for (int i = 0; i < 2; i++)
            {
                float randPosX = Random.Range(-5, 5);
                float randPosY = Random.Range(-4, 4);
                GameObject _Card1 = Instantiate(BasicCardSet[0], new Vector3(randPosX, randPosY, 0), Quaternion.identity);
            }

            GameObject _delTreeCard1 = GameObject.Find("Tree(Clone)");
            Destroy(_delTreeCard1);

            DataController.instance.gameData.WoodCard += 2;
            DataController.instance.gameData.TreeCard -= 1;
            DataController.instance.gameData.Skill = false;
        }

        if (Btn == "Rock")
        {
            for (int i = 0; i < 2; i++)
            {
                float randPosX = Random.Range(-5, 5);
                float randPosY = Random.Range(-4, 4);
                GameObject _Card1 = Instantiate(BasicCardSet[1], new Vector3(randPosX, randPosY, 0), Quaternion.identity);
            }

            GameObject _delRockCard1 = GameObject.Find("Rock(Clone)");
            Destroy(_delRockCard1);

            DataController.instance.gameData.StoneCard += 2;
            DataController.instance.gameData.RockCard -= 1;
            DataController.instance.gameData.Skill = false;
        }

        if (Btn == "BananaTree")
        {
            for (int i = 0; i < 3; i++)
            {
                float randPosX = Random.Range(-5, 5);
                float randPosY = Random.Range(-4, 4);
                GameObject _Card1 = Instantiate(BasicCardSet[5], new Vector3(randPosX, randPosY, 0), Quaternion.identity);
            }
            GameObject _delRockCard1 = GameObject.Find("BananaTree(Clone)");
            Destroy(_delRockCard1);

            DataController.instance.gameData.BananaCard += 3;
            DataController.instance.gameData.BananaTreeCard -= 1;
            DataController.instance.gameData.Skill = false;
        }
    }

    public void StoreUpgrade()
    {
        if (DataController.instance.gameData.storeUpgrade == 0 && DataController.instance.gameData.gold >= 30)
        {
            DataController.instance.gameData.storeUpgrade += 1;
        }
        if (DataController.instance.gameData.storeUpgrade == 1 && DataController.instance.gameData.gold >= 60)
        {
            DataController.instance.gameData.storeUpgrade += 1;
        }
    }
}
