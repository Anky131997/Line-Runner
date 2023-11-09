using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour
{
    public float rotationDuration;
    public Vector3 targetRotation;
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RotateToTarget()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * rotationDuration;
            transform.rotation = Quaternion.Lerp(initialRotation, Quaternion.Euler(targetRotation), t);
            yield return null;
        }
    }

    public void ClickToRotate()
    {
        StartCoroutine("RotateToTarget");
    }
}
