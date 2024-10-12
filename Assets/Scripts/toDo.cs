using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toDo : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = inputManager.GetSelectedPosition();

        if(mousePos == transform.position)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("You Pressed it!");

            }
        }
    }
}
