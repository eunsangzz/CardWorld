using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour //이름 변경생각
{
    float distance = 10.0f;
    public GameObject CardShadow;

    void Start()
    {
        CardCount();
    }

    public void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
    private void OnMouseDown()
    {
        CardShadow.SetActive(true);
    }
    private void OnMouseUp()
    {
        CardShadow.SetActive(false);
    }

    void CardCount() // 카드 생성시 카드 카운터 해줌 조합할떄 필요
    {
        if(this.gameObject.name == "Wood") DataController.instance.gameData.WoodCard += 1;
        if(this.gameObject.name == "Stone") DataController.instance.gameData.StoneCard += 1;
    }
}
