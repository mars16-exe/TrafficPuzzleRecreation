using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMatch : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private string tagName;

    Ray[] rayH = new Ray[1];
    Ray[] rayV = new Ray[1];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MatchColorsH()
    {
        //Left Raycast
        Vector3 left = transform.TransformDirection(Vector3.left);

        rayH[0] = new Ray(transform.position, left * 0.7f);
        RaycastHit hitLeft;

        //Right Raycast
        Vector3 right = transform.TransformDirection(Vector3.right);

        rayH[1] = new Ray(transform.position, right * 0.7f);
        RaycastHit hitRight;

        if (Physics.Raycast(rayH[0], out hitRight, 0.7f, layerMask) && Physics.Raycast(rayV[1], out hitLeft, 0.7f, layerMask))
        {
            if(hitRight.collider.tag == "yellow" && hitLeft.collider.tag == "yellow")
            {
                Destroy(hitRight.collider.gameObject);
                Destroy(hitLeft.collider.gameObject);
                Destroy(this.gameObject);
            }
            else if(hitRight.collider.tag == "blue" && hitLeft.collider.tag == "blue")
            {
                Destroy(hitRight.collider.gameObject);
                Destroy(hitLeft.collider.gameObject);
                Destroy(this.gameObject);
            }
            else if(hitRight.collider.tag == "purple" && hitLeft.collider.tag == "purple")
            {
                Destroy(hitRight.collider.gameObject);
                Destroy(hitLeft.collider.gameObject);
                Destroy(this.gameObject);
            }
            else
            {
                //doNothing
            }
        }
    }

    private void MatchColorsV()
    {
        //Forward Raycast
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        rayV[0] = new Ray(transform.position, forward * 0.7f);
        RaycastHit hitForward;

        //Back Raycast
        Vector3 back = transform.TransformDirection(Vector3.back);

        rayV[1] = new Ray(transform.position, back * 0.7f);
        RaycastHit hitBack;

        if (Physics.Raycast(rayV[0], out hitBack, 0.7f, layerMask) && Physics.Raycast(rayV[1], out hitForward, 0.7f, layerMask))
        {
            if (hitBack.collider.tag == "yellow" && hitForward.collider.tag == "yellow")
            {
                Destroy(hitBack.collider.gameObject);
                Destroy(hitForward.collider.gameObject);
                Destroy(this.gameObject);
            }
            else if (hitBack.collider.tag == "blue" && hitForward.collider.tag == "blue")
            {
                Destroy(hitBack.collider.gameObject);
                Destroy(hitForward.collider.gameObject);
                Destroy(this.gameObject);
            }
            else if (hitBack.collider.tag == "purple" && hitForward.collider.tag == "purple")
            {
                Destroy(hitBack.collider.gameObject);
                Destroy(hitForward.collider.gameObject);
                Destroy(this.gameObject);
            }
            else
            {
                //doNothing
            }
        }
    }

}
