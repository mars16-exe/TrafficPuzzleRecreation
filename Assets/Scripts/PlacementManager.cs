using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{

    [SerializeField] private InputManager inputManager;

    private void Update()
    {
        Vector3 mousePosition = inputManager.GetSelectedPosition();
        Vector3Int gridPos = grid.WorldToCell(mousePosition);

        placementIndicator.transform.position = grid.CellToWorld(gridPos);
    }

    //testing mechanics

    [SerializeField] Grid grid;
    [SerializeField] GameObject placementIndicator; 


}
