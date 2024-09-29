using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody rb;

    private SphereCollider src;
    private TrailRenderer tr;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        src = GetComponent<SphereCollider>();
        tr = GetComponent<TrailRenderer>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tr.enabled = true;
            src.enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            tr.enabled = false;
            src.enabled = false;
        }
        BladeTrailMouse();
    }


    private void BladeTrailMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 8;
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);

    }
        
    
}
