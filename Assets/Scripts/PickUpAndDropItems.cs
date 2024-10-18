using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDropItems : MonoBehaviour
{
    [SerializeField] private Transform[] pointsForHoldItem;
    private int pointIndex = 0;
    private GameObject currentItemInHand = null;


    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            if(currentItemInHand != null) {
                DropItems();
            }
            else {
                PickUpItems();
            }
        }
    }

    private void PickUpItems() {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f) 
            && hit.transform.CompareTag("Interactable")) {
                currentItemInHand = hit.transform.gameObject;
                currentItemInHand.SetActive(false);
        }
    }

    private void DropItems() {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f)
            && hit.transform.CompareTag("Pickup")){
                currentItemInHand.transform.position = pointsForHoldItem[pointIndex].position;
                pointIndex++;
                currentItemInHand.SetActive(true);
                currentItemInHand = null;
            }
    }
}
