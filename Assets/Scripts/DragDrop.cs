using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [HideInInspector] public Vector3 screenPoint;
    [HideInInspector] public Vector3 offset;
    [HideInInspector] public int cost;
    public bool follow = true;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Following " + follow);
        if (follow) {
            Debug.Log("Following");
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
            if (Input.GetMouseButtonUp(0))
            {
                if (transform.position.x < 0 && transform.position.y > -10f)
                {
                    follow = false;
                    Data.coin -= cost;
                    foreach (Behaviour childComponent in GetComponentsInChildren<Behaviour>())
                    {
                        childComponent.enabled = true;
                    }
                }
                else
                {
                    Destroy(gameObject);
                    Debug.Log("Illegal Placement");
                }
            }
        }
    }
}
