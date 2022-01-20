using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour   
{
    public float minvalue = 0.1f;
    private Vector3 lastMousePosition;
    private Vector3 mouseVelo;
    private Collider2D col;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        col.enabled = isMouseMoving();
        SetBladeToMouse();
    }
    private void SetBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;  // 10 units distance from main camera
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);



    }
    private bool isMouseMoving()
    {
        Vector3 curMousePos = transform.position;
        float traveled = (lastMousePosition - curMousePos).magnitude;
        lastMousePosition = curMousePos;
        if (traveled > minvalue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
