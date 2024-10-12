using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private GridManager gridManager;
    [SerializeField] private LayerMask layerDetection;

    [SerializeField] private float speed;
    public bool wasMoving = false;
    [SerializeField] Vector3 offsetPos;
    [SerializeField] float maxDistance;

    private void Start()
    {
        gridManager = GameObject.FindGameObjectWithTag("GridManager").GetComponent<GridManager>();
        SlotCar();
        carState = CarState.Moving;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(carState == CarState.Moving && GameManager.gameManagerInstance.gameState == GameManager.GameState.Flowing)
        {
            MoveCar();
        }
        else if(carState == CarState.Slotted)
        {
            SlotCar();
        }
    }

    private void MoveCar()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd * maxDistance, Color.red);

        Ray ray = new Ray(transform.position, fwd * maxDistance);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, layerDetection))
        {
            wasMoving = true;
            carState = CarState.Slotted;
        }
    }

    private void SlotCar()
    {
        Vector3 setPosition = gridManager.GetNearestPointOnGrid(transform.position);
        transform.position = setPosition + offsetPos;
    }

    private CarState carState;
    private enum CarState
    { 
        Moving,
        Slotted
    }

    private void UpdateState()
    {
        GameManager.gameManagerInstance.UpdateGameState(GameManager.GameState.ColorMatch);
    }

}
