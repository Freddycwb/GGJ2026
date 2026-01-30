using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSetter : MonoBehaviour
{
    [SerializeField] private GameObject objectToRotate;
    [SerializeField] private GameObject reference;
    [SerializeField] private Vector3 offSet;
    [System.Flags]
    public enum Axes
    {
        None = 0,
        x = 1,
        y = 2,
        z = 4,
    }
    [SerializeField] private Axes axesEnable = Axes.x | Axes.y | Axes.z;

    private void Awake()
    {
        if (objectToRotate == null) 
        {
            objectToRotate = gameObject;
        }
    }

    public void SetReference(GameObject value)
    {
        reference = value;
    }

    public void SetOffSetZ(GameObject value)
    {
        offSet.z = -value.transform.eulerAngles.z;
    }

    void Update()
    {
        if (reference != null)
        {
            SetRotationToReference(reference);
        }        
    }

    public void SetRotationToReference(GameObject value)
    {
        Vector3 rot = Vector3.zero;
        if ((axesEnable & Axes.x) != 0)
        {
            rot.x = (value.transform.eulerAngles + offSet).x;
        }
        if ((axesEnable & Axes.y) != 0)
        {
            rot.y = (value.transform.eulerAngles + offSet).y;
        }
        if ((axesEnable & Axes.z) != 0)
        {
            rot.z = (value.transform.eulerAngles + offSet).z;
        }

        objectToRotate.transform.eulerAngles = rot;
    }

    public void SetLocalRotationToReference(GameObject value)
    {
        objectToRotate.transform.localEulerAngles = value.transform.localEulerAngles + offSet;
    }

    public void SetToZero()
    {
        objectToRotate.transform.eulerAngles = Vector3.zero;
    }

    public void SetLocalToZero()
    {
        objectToRotate.transform.localEulerAngles = Vector3.zero;
    }

    public void SetLocalX(float value)
    {
        objectToRotate.transform.localEulerAngles = new Vector3(value, objectToRotate.transform.localEulerAngles.y, objectToRotate.transform.localEulerAngles.z);
    }

    public void SetLocalY(float value)
    {
        objectToRotate.transform.localEulerAngles = new Vector3(objectToRotate.transform.localEulerAngles.x, value, objectToRotate.transform.localEulerAngles.z);
    }

    public void SetLocalZ(float value)
    {
        objectToRotate.transform.localEulerAngles = new Vector3(objectToRotate.transform.localEulerAngles.x, objectToRotate.transform.localEulerAngles.y, value);
    }
}
