using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;

[Serializable]

public class GameData
{
    public int WoodCard;
    public int StoneCard;
    public int IronCard;
    public int GoldCard;
    public int TreeCard;
    public int BananaTreeCard;
    public GameObject[] Card; // 카드 프리팹 저장
    public int storeUpgrade; // 상점 단계에 따라 나오는 재료카드 많아짐
}
