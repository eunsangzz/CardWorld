using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject craftUi;
    public GameObject craftListUi;
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

    public GameObject tutoInfoUi;
    public GameObject tutoDayUi;
    public GameObject tutoBtnUi;
    public GameObject tutoBuy;
    public TextMeshProUGUI tutoBuyText;
    public GameObject tutoSell;
    public TextMeshProUGUI tutoSellText;
    public GameObject tutoCraft;
    public TextMeshProUGUI tutoCraftText;
    public GameObject tutoDay;
    public TextMeshProUGUI tutoDayText;
    public GameObject tutoStoreUp;
    public TextMeshProUGUI tutoStoreUpText;
    bool tutoday;
    bool tutocraft;
    bool StoreUp;

    public TextMeshProUGUI WoodCountText;
    public TextMeshProUGUI StoneCountText;
    public TextMeshProUGUI IronCountText;
    public TextMeshProUGUI PanelCountText;
    public TextMeshProUGUI BrickCountText;

    public TextMeshProUGUI GoldText;
    public TextMeshProUGUI FoodCount;

    public TextMeshProUGUI CardInfoText;
    public TextMeshProUGUI CardNameText;
    public TextMeshProUGUI CardCountText;
    public TextMeshProUGUI CardOver;
    public TextMeshProUGUI DayText;
    public TextMeshProUGUI StoreUpText;

    public TextMeshProUGUI GoalText;

    public Slider slTimer;
    float fSliderBarTime;

    int feedplayer;
    int notfeedplayer;
    bool feed = false;


    private void Start()
    {
        cardInfoUi.SetActive(false);
        slTimer.value = 120.0f;
        tutoday = false;
        tutocraft = false;
    }

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Tuto") DataController.instance.gameData.tuto = true;
        else DataController.instance.gameData.tuto = false;
        Debug.Log(DataController.instance.gameData.PlayerCount);

        if(DataController.instance.gameData.PlayerCount == 0) SceneManager.LoadScene("MainScene");

        if (slTimer.value > 0.0f && DataController.instance.gameData.endDay == false && feed == false) //?????????????? ????????????
        {
            slTimer.value -= 0.8f * Time.deltaTime;
            feedplayer = 0;
            DataController.instance.gameData.PlayerCount = DataController.instance.gameData.PlayerCount - notfeedplayer;
            notfeedplayer = 0;
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
            TutoInfoOff();
        }
        else if (slTimer.value == 0.0f) // ?????????????? ????????????????????????
        {
            if(DataController.instance.gameData.tuto == true && tutoday == false) 
            {
                tutoday = true;
                Time.timeScale = 0;
                tutoInfoUi.SetActive(true);
                tutoDayUi.SetActive(true);
                tutoDay.SetActive(true);
            }
            if (DataController.instance.gameData.PlayerCount != 0)
            {
                DataController.instance.gameData.endDay = true;
                if (feedplayer != DataController.instance.gameData.PlayerCount)
                {
                    feed = true;
                }
                if (DataController.instance.gameData.CardCount >= DataController.instance.gameData.CardLimit) //???????? ??????????????????
                {
                    DataController.instance.gameData.Sell = true;
                    cardInfoUi.SetActive(false);
                    SellBtn.SetActive(false);
                    buyBtn.SetActive(false);
                    craftUiBtn.SetActive(false);
                    SellUi.SetActive(true);
                    if (feedplayer != DataController.instance.gameData.PlayerCount && feed == true) //???????????? ?????????????????? ???????????????? ???????? ??????????????????
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
                                    else SceneManager.LoadScene("MainScene");
                                }
                                else
                                {
                                    if (DataController.instance.gameData.PlayerCount != 0)
                                    {
                                        GameObject cantfeedplayer1 = GameObject.FindGameObjectWithTag("Player");
                                        Destroy(cantfeedplayer1);
                                        DataController.instance.gameData.PlayerCount -=1;
                                        feedplayer++;
                                        notfeedplayer++;
                                    }
                                    else SceneManager.LoadScene("MainScene");
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
                else //???????? ??????????????????
                {
                    if (feedplayer != DataController.instance.gameData.PlayerCount && feed == true) //???????????? ?????????????????? ???????????????? ???????? ??????????????????
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
                                    else SceneManager.LoadScene("MainScene");
                                }
                                else
                                {
                                    if (DataController.instance.gameData.PlayerCount != 0)
                                    {
                                        GameObject cantfeedplayer1 = GameObject.FindGameObjectWithTag("Player");
                                        Destroy(cantfeedplayer1);
                                        feedplayer++;
                                        notfeedplayer++;
                                    }
                                    else SceneManager.LoadScene("MainScene");
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
                        slTimer.value = 120.0f;
                    }
                }
            }

        }
    }


    public void CraftUiBtn()
    {
        if(DataController.instance.gameData.tuto == true && tutocraft == false)
        {
            tutoInfoUi.SetActive(true);
            tutoBtnUi.SetActive(true);
            tutoCraft.SetActive(true);
            Time.timeScale =0;
            tutocraft = true;
        }
        craftUi.SetActive(true);
        craftListUi.SetActive(true);
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
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "??????";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "?????? ???????????? ????????? ????????? ?????????. ???????????? ???????????? ????????? ??????????????????.";
                    }
                    else if (touch.name == "Stone(Clone)")
                    {
                        cardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "??????";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "?????? ???????????? ????????? ????????? ?????????. ???????????? ???????????? ????????? ??????????????????. ";
                    }
                    else if (touch.name == "Tree(Clone)")
                    {
                        cardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "??????";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "???????????? ????????? ?????? ??? ??????. ????????? ???????????? ?????????";
                    }
                    else if (touch.name == "Rock(Clone)")
                    {
                        cardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "??????";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "???????????? ????????? ?????? ??? ??????. ????????? ?????? ?????????";
                    }
                    else if (touch.name == "House(Clone)")
                    {
                        cardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "???";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "????????? ????????? ????????????. ??????????????? ?????? ???????????????.";
                    }
                    else if (touch.name == "Banana(Clone)")
                    {
                        cardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "?????????";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "???????????? ????????? ?????? ??? ????????? ???????????? ????????? ?????? ????????????.";
                    }
                    else if (touch.name == "BananaTree(Clone)")
                    {
                        cardInfoUi.SetActive(true);
                        CardNameText.GetComponent<TextMeshProUGUI>().text = "???????????????";
                        CardInfoText.GetComponent<TextMeshProUGUI>().text = "????????? ?????? ???????????? ????????? ???????????????.";
                    }
                }
            }
        }
    }

    private void TutoInfoOff()
    {
        if(tutoInfoUi.activeSelf == true)
        {
            if(Input.GetMouseButton(0))
            {
                tutoInfoUi.SetActive(false);
                tutoBuy.SetActive(false);
                tutoCraft.SetActive(false);
                tutoSell.SetActive(false);
                tutoDay.SetActive(false);
                tutoDayUi.SetActive(false);
                tutoBtnUi.SetActive(false);
                Time.timeScale =1;
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
        if(DataController.instance.gameData.tuto == true && StoreUp == false)
        {
            tutoInfoUi.SetActive(true);
            tutoBtnUi.SetActive(true);
            tutoStoreUp.SetActive(true);
            Time.timeScale =0;
            StoreUp = true;
        }
        if (DataController.instance.gameData.gold >= 100 && DataController.instance.gameData.storeUpgrade == 0)
        {
            DataController.instance.gameData.storeUpgrade += 1;
            DataController.instance.gameData.gold -= 100;
        }
    }

    private void LateUpdate()
    {
        WoodCountText.GetComponent<TextMeshProUGUI>().text = "?????? : " + DataController.instance.gameData.WoodCard;
        StoneCountText.GetComponent<TextMeshProUGUI>().text = "?????? : " + DataController.instance.gameData.StoneCard;
        GoldText.GetComponent<TextMeshProUGUI>().text = "?????? : " + DataController.instance.gameData.gold;
        CardCountText.GetComponent<TextMeshProUGUI>().text = "???????????? : " + DataController.instance.gameData.CardLimit + "/" + DataController.instance.gameData.CardCount;
        DayText.GetComponent<TextMeshProUGUI>().text = "????????? : " + DataController.instance.gameData.Day;
        FoodCount.GetComponent<TextMeshProUGUI>().text = "?????? : " + DataController.instance.gameData.FoodCount + "/" + (DataController.instance.gameData.PlayerCount * 3);
        StoreUpText.GetComponent<TextMeshProUGUI>().text = "?????? ?????? : " + DataController.instance.gameData.storeUpgrade;
        GoalText.GetComponent<TextMeshProUGUI>().text = "?????? : ?????? 10 / " + DataController.instance.gameData.GoldIngotCard; 

        tutoBuyText.GetComponent<TextMeshProUGUI>().text = "3????????? ????????? ??????????????????.";
        tutoCraftText.GetComponent<TextMeshProUGUI>().text = "????????? ?????? ????????? ??? ??????.";
        tutoDayText.GetComponent<TextMeshProUGUI>().text = "?????? ???????????????. ????????? ???????????? ????????? ????????? ????????? ????????? ??????????????????. /n ?????? ????????? ??????????????? ???????????? ????????? ???????????????./n ????????? ???????????? ????????? ?????? ????????????.";
        tutoSellText.GetComponent<TextMeshProUGUI>().text = "????????? ??? ??? ????????????. ?????? ?????? ????????? ????????? ??????????????? ????????????????????????. ??????????????? ????????? ????????? ???????????????.";
        tutoStoreUpText.GetComponent<TextMeshProUGUI>().text = "100????????? ????????? ??????????????? ??????????????????. ????????? ????????? ?????????!";
    }

    public void MainSecne()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void TutoBtn()
    {
        SceneManager.LoadScene("Tuto");
    }

}
