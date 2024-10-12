using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject carPrefab;
    private Vector3 lastPosition;

    [SerializeField] private LayerMask placementLayer;
    public GridManager gridManager;

    public Vector3 GetSelectedPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 200, placementLayer))
            {
                lastPosition = hit.point;

                if(Input.GetMouseButtonDown(0))
                {
                    PlaceObjectNear(lastPosition);
                }
            }
        
        return lastPosition;
    }

    private void PlaceObjectNear(Vector3 clickPoint)
    {
        Vector3 finalPosition = gridManager.GetNearestPointOnGrid(clickPoint);
        Instantiate(carPrefab, finalPosition, Quaternion.identity);
    }

}
