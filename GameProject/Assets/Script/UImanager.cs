using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UImanager : MonoBehaviour
{
    public GameObject craftUi;
    public GameObject craftUiBtn;
    public GameObject menuUi;
    public GameObject menuUiBtn;
    public GameObject buyBtn;
    public GameObject SellUi;
    public GameObject SellBtn;
    public GameObject CardInfoUi;
    public GameObject CardSkillUi;

    public TextMeshProUGUI WoodCountText;
    public TextMeshProUGUI StoneCountText;
    public TextMeshProUGUI IronCountText;

    public TextMeshProUGUI GoldText;

    public TextMeshProUGUI CardInfoText;
    public TextMeshProUGUI CardNameText;


    private void Start()
    {
    }

    private void Update()
    {
        if (DataController.instance.gameData.Sell == true) SellUi.SetActive(true);
        else if (DataController.instance.gameData.Sell == false) SellUi.SetActive(false);

        if(craftUi.activeSelf == true)
        {
            SellBtn.SetActive(false);
            buyBtn.SetActive(false);
            craftUiBtn.SetActive(false);
        }
        else if(craftUi.activeSelf == false)
        {
            SellBtn.SetActive(true);
            buyBtn.SetActive(true);
            craftUiBtn.SetActive(true);
        }

        CardInfo();
    }

    public void CraftUiBtn()
    {
        craftUi.SetActive(true);
        craftUiBtn.SetActive(false);
        buyBtn.SetActive(false);
    }
    public void CraftUiCloseBtn()
    {
        craftUi.SetActive(false);
        craftUiBtn.SetActive(true);
        buyBtn.SetActive(true);
    }
    public void MenuUiBtn()
    {
        menuUi.SetActive(true);
        menuUiBtn.SetActive(false);
    }
    public void MenuUiCloseBtn()
    {
        menuUi.SetActive(false);
        menuUiBtn.SetActive(true);
    }
    private void CardInfo()
    {
        if (Input.GetMouseButton(0))
        {
            if (DataController.instance.gameData.Sell == false)
            {
                CardInfoUi.SetActive(false);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject touch = hit.transform.gameObject;

                    if (touch.name == "Wood(Clone)")
                    {
                        CardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "Wood";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "woodinfo";
                    }
                    else if (touch.name == "Stone(Clone)")
                    {
                        CardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "Stone";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "stoneinfo";
                    }
                }
            }
        }
    }

    private void CardSkillUI()
    {
        if (Input.GetMouseButton(0))
        {
            if (DataController.instance.gameData.Sell == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject touch = hit.transform.gameObject;

                    if(touch.name == "Tree(Clone)")
                    {
                        CardSkillUi.SetActive(true);
                    }
                }
            }
        }
    }

    public void StoreUpgrade()
    {
        if(DataController.instance.gameData.gold >= 100 && DataController.instance.gameData.storeUpgrade ==0)
        {
            DataController.instance.gameData.storeUpgrade += 1;
        }
        if (DataController.instance.gameData.gold >= 300 && DataController.instance.gameData.storeUpgrade == 1)
        {
            DataController.instance.gameData.storeUpgrade += 1;
        }
        if (DataController.instance.gameData.gold >= 500 && DataController.instance.gameData.storeUpgrade == 2)
        {
            DataController.instance.gameData.storeUpgrade += 1;
        }

    }

    private void LateUpdate()
    {
        WoodCountText.GetComponent<TextMeshProUGUI>().text = "Wood : " +DataController.instance.gameData.WoodCard;
        StoneCountText.GetComponent<TextMeshProUGUI>().text = "Stone : " + DataController.instance.gameData.StoneCard;
        GoldText.GetComponent<TextMeshProUGUI>().text = "Gold : " + DataController.instance.gameData.gold;
    }
}
