using UnityEngine;

public class ScaleSetter : MonoBehaviour
{
    [SerializeField] private GameObject objToScale;

    public void SetScaleX(float value)
    {
        objToScale.transform.localScale = new Vector3(value, objToScale.transform.localScale.y, objToScale.transform.localScale.z);
    }
}
