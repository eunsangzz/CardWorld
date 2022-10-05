using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftManager : MonoBehaviour
{
    public GameObject[] CraftCardSet = new GameObject[2];
    public GameObject ErrorUi;

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
                //����ī�� list�� ����
                DataController.instance.gameData.CraftCardList.Add(_Card);
                for (int i = 0; i < 2; i++)
                {
                    GameObject _del1Card = DataController.instance.gameData.BasicCardList.Find(item => item.name == "Wood(Clone)");
                    DataController.instance.gameData.BasicCardList.Remove(_del1Card);
                }
                GameObject _del2Card = DataController.instance.gameData.BasicCardList.Find(item => item.name == "Stone(Clone)");
                DataController.instance.gameData.BasicCardList.Remove(_del2Card);

                DataController.instance.gameData.WoodCard -= 2;
                DataController.instance.gameData.StoneCard -= 1;
                DataController.instance.gameData.HouseCard += 1;
            }
            else ErrorUi.SetActive(true);
        }
    }

    public void ErrorClose()
    {
        ErrorUi.SetActive(false);
    }

}
