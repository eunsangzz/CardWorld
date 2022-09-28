using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameObject craftUi;
    public GameObject menuUi;
 
    public void CraftUiBtn()
    {
        craftUi.SetActive(true);
    }

    public void MenuUibtn()
    {
        menuUi.SetActive(true);
    }
}
