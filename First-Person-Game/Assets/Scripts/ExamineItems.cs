using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class ExamineItems : MonoBehaviour
{
    [SerializeField] FirstPersonControls firstPersonControls;

    public Transform prefab;


    // Start is called before the first frame update
    void Start()
    {
        firstPersonControls.ItemExamination();
        Debug.Log(firstPersonControls);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
