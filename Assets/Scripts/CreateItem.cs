using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    public GameObject item;
    public int cost = 100;
    private Vector3 screenPoint;
    private Vector3 offset;

    private void OnMouseDown()
    {
        if(Data.coin > cost)
        {
            Debug.Log("Create Item");
            GameObject itemInstance = Instantiate(item, transform.position,Quaternion.identity);

            foreach (Behaviour childComponent in itemInstance.GetComponentsInChildren<Behaviour>())
            {
                childComponent.enabled = false;
                screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, screenPoint.z));
                DragDrop dd = itemInstance.GetComponent<DragDrop>();
                dd.enabled = true;
                dd.screenPoint = screenPoint;
                dd.cost = cost;
                dd.offset = offset;
            }
        }
        else
        {
            Debug.Log("Koin tidak cukup");
        }
    }

}
