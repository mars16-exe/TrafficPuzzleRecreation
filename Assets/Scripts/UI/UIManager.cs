using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image carImage;

    [SerializeField] private Sprite[] currentCar;
    // Start is called before the f.irst frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        carImage.sprite = currentCar[InputManager.Instance.currentCar];
    }
}
