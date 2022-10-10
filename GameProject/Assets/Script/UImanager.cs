using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public GameObject craftUi;
    public GameObject craftUiBtn;
    public GameObject menuUi;
    public GameObject menuUiBtn;
    public GameObject buyBtn;
    public GameObject SellUi;
    public GameObject SellBtn;

    public TextMeshProUGUI WoodCardText;
    public TextMeshProUGUI StoneCardText;
    public TextMeshProUGUI IronCardText;

    private void Start()
    {
    }

    void Update()
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

    void LateUpdate()
    {
        WoodCardText.GetComponent<TextMeshProUGUI>().text = "Wood : " +DataController.instance.gameData.WoodCard;
        StoneCardText.GetComponent<TextMeshProUGUI>().text = "Stone : " + DataController.instance.gameData.StoneCard;
    }
}
