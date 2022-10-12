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
    public GameObject TreeSkillBtn;
    public GameObject RockSkillBtn;
    public GameObject BananaTreeBtn;

    public TextMeshProUGUI WoodCountText;
    public TextMeshProUGUI StoneCountText;
    public TextMeshProUGUI IronCountText;

    public TextMeshProUGUI GoldText;

    public TextMeshProUGUI CardInfoText;
    public TextMeshProUGUI CardNameText;
    public TextMeshProUGUI CardCountText;


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

        if(DataController.instance.gameData.Skill == false)
        {
            CardSkillUi.SetActive(false);
        }

        CardInfo();
        CardSkillUI();
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
                    else if (touch.name == "Tree(Clone)")
                    {
                        CardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "Tree";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "treeinfo";
                    }
                    else if (touch.name == "Rock(Clone)")
                    {
                        CardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "Rock";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "rockinfo";
                    }
                    else if (touch.name == "House(Clone)")
                    {
                        CardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "House";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "houseinfo";
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
                        TreeSkillBtn.SetActive(true);
                        RockSkillBtn.SetActive(false);
                        BananaTreeBtn.SetActive(false);
                        DataController.instance.gameData.Skill = true;
                    }
                    else if (touch.name == "Rock(Clone)")
                    {
                        CardSkillUi.SetActive(true);
                        RockSkillBtn.SetActive(true);
                        TreeSkillBtn.SetActive(false);
                        BananaTreeBtn.SetActive(false);
                        DataController.instance.gameData.Skill = true;
                    }
                    else if (touch.name == "BananaTree(Clone)")
                    {
                        CardSkillUi.SetActive(true);
                        BananaTreeBtn.SetActive(true);
                        RockSkillBtn.SetActive(false);
                        TreeSkillBtn.SetActive(false);
                        DataController.instance.gameData.Skill = true;
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
        CardCountText.GetComponent<TextMeshProUGUI>().text = "CardCount : " + DataController.instance.gameData.CardLimit + "/" + DataController.instance.gameData.CardCount;
    }
}
