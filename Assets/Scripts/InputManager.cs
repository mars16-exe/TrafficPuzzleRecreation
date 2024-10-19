using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    [SerializeField] private GameObject[] carPrefab = new GameObject[3]; 

    [SerializeField] private LayerMask placementLayer;

    public int currentCar; //0 is blue, 1 is purple, 2 is yellow

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        RandomizeCarSelection();
    }

    private void Update()
    {
        GetSelectedPosition();
    }
    public void GetSelectedPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 200, placementLayer))
        {
            if (hit.collider != null)
            {
                SpawnManager spawner = hit.transform.GetComponent<SpawnManager>();

                if (spawner != null && Input.GetMouseButtonDown(0))
                {
                    spawner.SpawnCar(carPrefab[currentCar]);
                    RandomizeCarSelection();
                }
                else if (hit.collider == null)
                {
                    //do Nothing
                }
            }
        }

    }

    private void RandomizeCarSelection()
    {
        currentCar = Random.Range(0, carPrefab.Length);
    }
}
