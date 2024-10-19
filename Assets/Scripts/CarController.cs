using System.Collections;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private LayerMask layerDetection;

    [SerializeField] private float speed;
    public bool wasMoving = false;
    [SerializeField] Vector3 offsetPos;
    [SerializeField] float maxDistance;

    private void Start()
    {
        StartCoroutine("DecisionMaking");
        SlotCar(); //makes sure all cars are aligned with the grid
        carState = CarState.Moving;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("trafficCone"))
        {
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("blue") && !carDecided)
        {
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("purple") && !carDecided)
        {
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("yellow") && !carDecided)
        {
            Destroy(this.gameObject);
        }
    }

    private void LateUpdate()
    {
        if (carState == CarState.Moving)
        {
            MoveCar();
            CheckforCar();
        }
        else if (carState == CarState.Slotted)
        {
            SlotCar();
        }
    }

    private void MoveCar()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void CheckforCar()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd * maxDistance, Color.red);

        Ray ray = new Ray(transform.position, fwd * maxDistance);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, layerDetection) && carState != CarState.Slotted)
        {
            wasMoving = true;
            carState = CarState.Slotted;
        }
        else if (!Physics.Raycast(ray, out hit, maxDistance, layerDetection))
        {
            wasMoving = false;
            carState = CarState.Moving;
        }
    }

    private void SlotCar()
    {
        Vector3 setPosition = GridManager.Instance.GetNearestPointOnGrid(transform.position);
        transform.position = setPosition + offsetPos;
        carState = CarState.ReadyforColor;
    }

    public CarState carState;
    public enum CarState
    {
        Moving,
        Slotted,
        ReadyforColor
    }

    private void UpdateState()  //configure Later! 
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.ColorMatch);
    }

    public bool carDecided = false;
    IEnumerator DecisionMaking()
    {
        yield return new WaitForSeconds(0.5f);
        carDecided = true;
    }

}
