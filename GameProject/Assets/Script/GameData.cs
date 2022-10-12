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
    public int BananaCard;
    public int HouseCard;
    public int gold;
    public int RockCard;

    public int CardCount;

    public int CardLimit;

    public bool Sell;
    public bool Skill;

    public GameObject[] Card = new GameObject[2]; // 카드 프리팹 저장
    public int storeUpgrade; // 상점 단계에 따라 나오는 재료카드 많아짐
    public List<GameObject> BasicCardList;
    public List<GameObject> CraftCardList;
}
