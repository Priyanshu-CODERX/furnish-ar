using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaleAndRotate : MonoBehaviour
{
    public float rotateSpeed = 100f;
    float initialFingersDistance;

    Vector3 initialScale;


    void Update()
    {
        if (Input.touches.Length == 2)
        {
            Touch t1 = Input.touches[0];
            Touch t2 = Input.touches[1];

            if (t1.phase == TouchPhase.Began || t2.phase == TouchPhase.Began)
            {
                initialFingersDistance = Vector2.Distance(t1.position, t2.position);
                initialScale = gameObject.transform.localScale;
            }
            else if (t1.phase == TouchPhase.Moved || t2.phase == TouchPhase.Moved)
            {
                var currentFingersDistance = Vector2.Distance(t1.position, t2.position);
                var scaleFactor = currentFingersDistance / initialFingersDistance;
                gameObject.transform.localScale = initialScale * scaleFactor;
            }
        }
    }

    void OnMouseDrag()
    {
        float rot = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
        transform.Rotate(0, 0, rot);
    }
}
