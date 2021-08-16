using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private Vector3 vel;
    public float smooth_amount = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetpos = target.transform.childCount==0 ? target.position : target.transform.GetChild(target.transform.childCount/2).position;
        transform.position = Vector3.SmoothDamp(transform.position, targetpos + offset + (transform.position - targetpos).normalized*target.transform.childCount, ref vel, smooth_amount);
        //transform.position = targetpos + offset + (transform.position - targetpos).normalized*target.transform.childCount;
    }
}
