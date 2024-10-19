using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMatch : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private CarController carController;
    [SerializeField] private float rayDistance = 0.88f;
    [SerializeField] private string myTag;

    Ray[] rayH = new Ray[2];
    Ray[] rayV = new Ray[2];

    [SerializeField] private bool carChecked = false;

    // Start is called before the first frame update
    void Start()
    {
        myTag = transform.tag;
        carController = GetComponent<CarController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (carController.carState == CarController.CarState.ReadyforColor)
        {
            carChecked = false;
            MatchColorsH();  //first horizontal check            
            MatchColorsV();
        }
        else if(carChecked)
        {
            carController.CheckforCar();
        }
    }

    private void MatchColorsH()
    {
        //Left Raycast
        Vector3 left = transform.TransformDirection(Vector3.left);
        Debug.DrawRay(transform.position, left * rayDistance, Color.blue);


        rayH[0] = new Ray(transform.position, left * rayDistance);
        RaycastHit hitLeft;

        //Right Raycast
        Vector3 right = transform.TransformDirection(Vector3.right);
        Debug.DrawRay(transform.position, right * rayDistance, Color.blue);


        rayH[1] = new Ray(transform.position, right * rayDistance);
        RaycastHit hitRight;

        if (Physics.Raycast(rayH[1], out hitRight, rayDistance, layerMask) && Physics.Raycast(rayH[0], out hitLeft, rayDistance, layerMask))
        {
            if(hitRight.collider.CompareTag(myTag) && hitLeft.collider.CompareTag(myTag))
            {
                CarController rightCar = hitRight.collider.GetComponent<CarController>();
                CarController leftCar = hitLeft.collider.GetComponent<CarController>();

                if(rightCar.carState == CarController.CarState.ReadyforColor && leftCar.carState == CarController.CarState.ReadyforColor)
                {
                    Destroy(rightCar.gameObject);
                    Destroy(leftCar.gameObject);
                    Destroy(this.gameObject);
                }
            }
        }
        else
        {
            carChecked = true;
        }
    }

    private void MatchColorsV()
    {
        //Forward Raycast
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forward * rayDistance, Color.yellow);


        rayV[0] = new Ray(transform.position, forward * rayDistance);
        RaycastHit hitForward;

        //Back Raycast
        Vector3 back = transform.TransformDirection(Vector3.back);
        Debug.DrawRay(transform.position, back * rayDistance, Color.yellow);


        rayV[1] = new Ray(transform.position, back * rayDistance);
        RaycastHit hitBack;

        if (Physics.Raycast(rayV[1], out hitBack, rayDistance, layerMask) && Physics.Raycast(rayV[0], out hitForward, rayDistance, layerMask))
        {
            if (hitBack.collider.CompareTag(myTag) && hitForward.collider.CompareTag(myTag))
            {
                CarController backCar = hitBack.collider.GetComponent<CarController>();
                CarController forwardCar = hitForward.collider.GetComponent<CarController>();

                if (backCar.carState == CarController.CarState.ReadyforColor && forwardCar.carState == CarController.CarState.ReadyforColor)
                {
                    Destroy(backCar.gameObject);
                    Destroy(forwardCar.gameObject);
                    Destroy(this.gameObject);
                }
            }
        }
        else
        {
            carChecked = true;
        }
    }

}
