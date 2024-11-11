using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;
using UnityEngine.InputSystem;

public class ExamineItems : MonoBehaviour, IDragHandler
{
    [SerializeField] FirstPersonControls firstPersonControls;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void OnDrag(PointerEventData eventData)
    {
        // Convert the delta from drag into rotation
        float rotationSpeed = 0.5f; // Adjust this value to control rotation speed
        Quaternion rotationX = Quaternion.AngleAxis(eventData.delta.x * rotationSpeed, Vector3.up);
        Quaternion rotationY = Quaternion.AngleAxis(eventData.delta.y * rotationSpeed, Vector3.right);

        // Apply the rotation to the item
        firstPersonControls.itemPrefab.rotation *= rotationX * rotationY;
    }
    /*
    public void OnDrag(PointerEventData eventData)
    {
       firstPersonControls.itemPrefab.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x);
    }*/
}