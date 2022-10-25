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
    public GameObject cardInfoUi;
    public GameObject cardSkillUi;
    public GameObject treeSkillBtn;
    public GameObject rockSkillBtn;
    public GameObject bananaTreeBtn;
    public GameObject nullplayer;

    public TextMeshProUGUI WoodCountText;
    public TextMeshProUGUI StoneCountText;
    public TextMeshProUGUI IronCountText;

    public TextMeshProUGUI GoldText;

    public TextMeshProUGUI CardInfoText;
    public TextMeshProUGUI CardNameText;
    public TextMeshProUGUI CardCountText;
    public TextMeshProUGUI CardOver;
    public TextMeshProUGUI DayText;

    public Slider slTimer;
    float fSliderBarTime;

    int feedplayer;
    bool feed = false;


    private void Start()
    {
        cardInfoUi.SetActive(false);
        slTimer.value = 120.0f;
    }

    private void Update()
    {
        if (slTimer.value > 0.0f && DataController.instance.gameData.endDay == false && feed == false) //�ð��� �带��
        {
            slTimer.value -= 40 * Time.deltaTime;
            feedplayer = 0;
            if (DataController.instance.gameData.Sell == true) SellUi.SetActive(true);
            else if (DataController.instance.gameData.Sell == false) SellUi.SetActive(false);

            if (craftUi.activeSelf == true)
            {
                SellBtn.SetActive(false);
                buyBtn.SetActive(false);
                craftUiBtn.SetActive(false);
            }
            else if (craftUi.activeSelf == false)
            {
                SellBtn.SetActive(true);
                buyBtn.SetActive(true);
                craftUiBtn.SetActive(true);
            }

            if (DataController.instance.gameData.Skill == false)
            {
                cardSkillUi.SetActive(false);
            }
            CardInfo();
            CardSkillUI();
        }
        else if (slTimer.value == 0.0f) // �ð��� ��������
        {
            DataController.instance.gameData.endDay = true;
            if (feedplayer != DataController.instance.gameData.PlayerCount)
            {
                feed = true;
            }
            if (DataController.instance.gameData.CardCount >= DataController.instance.gameData.CardLimit) //ī�尡 ������
            {
                DataController.instance.gameData.Sell = true;
                cardInfoUi.SetActive(false);
                SellBtn.SetActive(false);
                buyBtn.SetActive(false);
                craftUiBtn.SetActive(false);
                SellUi.SetActive(true);
                if (feedplayer != DataController.instance.gameData.PlayerCount && feed == true) //���� ������ �÷��̾� ī�尡 ������
                {
                    if (DataController.instance.gameData.FoodCount >= (DataController.instance.gameData.PlayerCount * 2))
                    {
                        DataController.instance.gameData.FoodCount -= (DataController.instance.gameData.PlayerCount * 2);
                        feed = false;
                    }
                    else
                    {
                        if (feedplayer != DataController.instance.gameData.PlayerCount)
                        {
                            if (DataController.instance.gameData.FoodCount > 1)
                            {
                                if(DataController.instance.gameData.PlayerCount != 0)
                                {
                                    DataController.instance.gameData.FoodCount -= 2;
                                    feedplayer++;
                                }
                                else nullplayer.SetActive(true);
                            }
                            else
                            {
                                if(DataController.instance.gameData.PlayerCount != 0)
                                {
                                    GameObject cantfeedplayer1 = GameObject.FindGameObjectWithTag("Player");
                                    Destroy(cantfeedplayer1);
                                    feedplayer++;
                                }
                                else nullplayer.SetActive(true);
                            }
                        }
                    }
                }

                if (feedplayer == DataController.instance.gameData.PlayerCount)
                {
                    Debug.Log("3");
                    feed = false;
                }
            }   
            else //ī�尡 ������
            {
                if (feedplayer != DataController.instance.gameData.PlayerCount && feed == true) //���� ������ �÷��̾� ī�尡 ������
                {
                    if (DataController.instance.gameData.FoodCount >= (DataController.instance.gameData.PlayerCount * 2))
                    {
                        DataController.instance.gameData.FoodCount -= (DataController.instance.gameData.PlayerCount * 2);
                        feed = false;
                    }
                    else
                    {
                        if (feedplayer != DataController.instance.gameData.PlayerCount)
                        {
                            if (DataController.instance.gameData.FoodCount > 1)
                            {
                                if (DataController.instance.gameData.PlayerCount != 0)
                                {
                                    DataController.instance.gameData.FoodCount -= 2;
                                    feedplayer++;
                                }
                                else nullplayer.SetActive(true);
                            }
                            else
                            {
                                if (DataController.instance.gameData.PlayerCount != 0)
                                {
                                    GameObject cantfeedplayer1 = GameObject.FindGameObjectWithTag("Player");
                                    Destroy(cantfeedplayer1);
                                    feedplayer++;
                                }
                                else nullplayer.SetActive(true);
                            }
                        }
                    }
                }
                if (feedplayer == DataController.instance.gameData.PlayerCount)
                {
                    Debug.Log("3");
                    feed = false;
                }
                if (feed == false)
                {
                    Debug.Log("next");
                    DataController.instance.gameData.endDay = false;
                    SellBtn.SetActive(true);
                    buyBtn.SetActive(true);
                    craftUiBtn.SetActive(true);
                    DataController.instance.gameData.Day += 1;
                    slTimer.value = 120.0f;
                }
            }
        }
    }


    public void CraftUiBtn()
    {
        craftUi.SetActive(true);
        craftUiBtn.SetActive(false);
        buyBtn.SetActive(false);
        craftUiBtn.SetActive(false);
        cardInfoUi.SetActive(false);
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
                cardInfoUi.SetActive(false);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject touch = hit.transform.gameObject;

                    if (touch.name == "Wood(Clone)")
                    {
                        cardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "Wood";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "woodinfo";
                    }
                    else if (touch.name == "Stone(Clone)")
                    {
                        cardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "Stone";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "stoneinfo";
                    }
                    else if (touch.name == "Tree(Clone)")
                    {
                        cardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "Tree";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "treeinfo";
                    }
                    else if (touch.name == "Rock(Clone)")
                    {
                        cardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "Rock";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "rockinfo";
                    }
                    else if (touch.name == "House(Clone)")
                    {
                        cardInfoUi.SetActive(true);
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

                    if (touch.name == "Tree(Clone)")
                    {
                        cardSkillUi.SetActive(true);
                        treeSkillBtn.SetActive(true);
                        rockSkillBtn.SetActive(false);
                        bananaTreeBtn.SetActive(false);
                        DataController.instance.gameData.Skill = true;
                    }
                    else if (touch.name == "Rock(Clone)")
                    {
                        cardSkillUi.SetActive(true);
                        rockSkillBtn.SetActive(true);
                        treeSkillBtn.SetActive(false);
                        bananaTreeBtn.SetActive(false);
                        DataController.instance.gameData.Skill = true;
                    }
                    else if (touch.name == "BananaTree(Clone)")
                    {
                        cardSkillUi.SetActive(true);
                        bananaTreeBtn.SetActive(true);
                        rockSkillBtn.SetActive(false);
                        treeSkillBtn.SetActive(false);
                        DataController.instance.gameData.Skill = true;
                    }
                }
            }
        }
    }

    public void StoreUpgrade()
    {
        if (DataController.instance.gameData.gold >= 100 && DataController.instance.gameData.storeUpgrade == 0)
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

    public void CloseBtn()
    {

    }

    private void LateUpdate()
    {
        WoodCountText.GetComponent<TextMeshProUGUI>().text = "Wood : " + DataController.instance.gameData.WoodCard;
        StoneCountText.GetComponent<TextMeshProUGUI>().text = "Stone : " + DataController.instance.gameData.StoneCard;
        GoldText.GetComponent<TextMeshProUGUI>().text = "Gold : " + DataController.instance.gameData.gold;
        CardCountText.GetComponent<TextMeshProUGUI>().text = "CardCount : " + DataController.instance.gameData.CardLimit + "/" + DataController.instance.gameData.CardCount;
        DayText.GetComponent<TextMeshProUGUI>().text = "Day : " + DataController.instance.gameData.Day;
    }
}
