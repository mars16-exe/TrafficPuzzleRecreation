using UnityEngine;

public class sortObject : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 slotPos = GridManager.Instance.GetNearestPointOnGrid(transform.position);
        pos = slotPos;
    }

    private void Update()
    {
        transform.position = pos + offset;
    }


}
