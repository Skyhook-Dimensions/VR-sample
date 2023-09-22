using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtPlayer : MonoBehaviour
{
    public Transform head;
    public GameObject menu;
    //public InputActionProperty showButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if ((showButton.action.WasPressedThisFrame()))
        {
            menu.SetActive(!menu.activeSelf);
        }*/

        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1;
    }
}
