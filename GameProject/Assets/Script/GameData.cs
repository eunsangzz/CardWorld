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
    public int HouseCard;


    public GameObject[] Card = new GameObject[2]; // 카드 프리팹 저장
    public int storeUpgrade; // 상점 단계에 따라 나오는 재료카드 많아짐
    public List<GameObject> BasicCardList = new List<GameObject>();
    public List<GameObject> CraftCardList = new List<GameObject>();
}
