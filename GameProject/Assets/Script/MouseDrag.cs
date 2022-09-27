using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    float distance = 10.0f;
    public GameObject CardShadow;
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
}
