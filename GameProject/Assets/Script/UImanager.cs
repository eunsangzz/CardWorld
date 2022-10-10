using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameObject craftUi;
    public GameObject craftUiBtn;
    public GameObject menuUi;
    public GameObject menuUiBtn;
    public GameObject buyBtn;
    public GameObject SellUi;

    private void Update()
    {
        if (DataController.instance.gameData.Sell == true) SellUi.SetActive(true);
        else if (DataController.instance.gameData.Sell == false) SellUi.SetActive(false);
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
}
