using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftManager : MonoBehaviour
{
    public GameObject[] CraftCardSet = new GameObject[2];
    public GameObject ErrorUi;
    public GameObject CraftUI;

    bool HouseCraft = false;
    int CraftNum =0;

    void Update()
    {
        if(HouseCraft == true && CraftNum < 2)
        {
            CraftDelete(1);
            if(CraftNum == 1)
            {
                HouseCraft =false;
            }
            if(CraftNum == 0)
            {
                CraftDelete(2);
            }
            CraftNum += 1;
        }
    }

    public void CardCraft()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        if(clickObject.name == "HouseCraft")
        {
            if (DataController.instance.gameData.WoodCard >= 2 && 
                DataController.instance.gameData.StoneCard >= 1)
            {
                float randPosX = Random.Range(-5, 5);
                float randPosY = Random.Range(-4, 4);
                GameObject _Card = Instantiate(CraftCardSet[1], new Vector3(randPosX, randPosY, 0), Quaternion.identity);
                DataController.instance.gameData.CraftCardList.Add(_Card);

                HouseCraft = true;

                DataController.instance.gameData.WoodCard -= 2;
                DataController.instance.gameData.StoneCard -= 1;
                DataController.instance.gameData.HouseCard += 1;
                DataController.instance.gameData.CardLimit += 3;

                CraftUI.SetActive(false);
            }
            else ErrorUi.SetActive(true);
        }
    }

    public void ErrorClose()
    {
        ErrorUi.SetActive(false);
    }

    void CraftDelete(int CardNum)
    {
        switch(CardNum)
        {
            case 1:
                GameObject _delWoodCard1 = GameObject.Find("Wood(Clone)");
                Debug.Log("1");
                Destroy(_delWoodCard1);
                break;
            case 2:
                GameObject _delStoneCard = GameObject.Find("Stone(Clone)");
                Destroy(_delStoneCard);
                break;
                
        }
    }

}
