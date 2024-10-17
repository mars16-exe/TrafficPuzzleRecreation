using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject carPrefab;

    [SerializeField] private LayerMask placementLayer;

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
                    spawner.SpawnCar(carPrefab);
                }
                else if (hit.collider == null)
                {
                    //do Nothing
                }


            }
        }

    }
}
