using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int hp;
    int damage;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos;

        pos = this.gameObject.transform.position;

        if(this.gameObject.name == "WoodSword(Clone)")
        {
            hp = 3;
            damage = 2;
        }
        else if(this.gameObject.name == "StoneSword(Clone)")
        {
            hp = 5;
            damage = 4;
        }
        else if(this.gameObject.name == "IronSword(Clone)")
        {
            hp =7;
            damage = 6;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Boss1(Clone)" && DataController.instance.gameData.PlayerAttack == true)
        {

        }
        else if(other.name == "Boss2(Clone)" && DataController.instance.gameData.PlayerAttack == true)
        {

        }
        else if(other.name == "Enemy1(Clone)" && DataController.instance.gameData.PlayerAttack == true)
        {

        }
        else if(other.name == "Enemy2(Clone)" && DataController.instance.gameData.PlayerAttack == true)
        {

        }
        else if(other.name == "Enemy3(Clone)" && DataController.instance.gameData.PlayerAttack == true)
        {
            
        }
    }
}
