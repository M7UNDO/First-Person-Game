using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Title: OPENING a DOOR with a KEY! (Unity Beginner Tutorial)
//Author: SpeedTutor
//Date: 14 August 2024
//Availability: https://www.youtube.com/watch?v=SlEgvvNYXQU&t=175s

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool redDoor = false;
        [SerializeField] private bool redKey = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            if (redDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjectInteraction()
        {
            if (redDoor)
            {
                doorObject.PlayAnimation();
            }

            else if (redKey)
            {
                _keyInventory.hasRedKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}
