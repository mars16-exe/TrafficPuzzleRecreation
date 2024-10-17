using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Vector3 carPos = new Vector3(0.99f,0f,0f);

    public void SpawnCar(GameObject car)
    {
        Instantiate(car, transform.position + carPos, transform.rotation);
    }
}
