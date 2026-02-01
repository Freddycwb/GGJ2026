using UnityEngine;

public class ScaleByDistance : MonoBehaviour
{
    [SerializeField] private GameObject objToScale;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObjectVariable targetVariable;
    [SerializeField] private float offset;

    private Vector3 _initialScale;

    private void Start()
    {
        _initialScale = transform.localScale;
        if (target == null && targetVariable.Value != null)
        {
            target = targetVariable.Value;
        }
    }

    private void Update()
    {
        objToScale.transform.localScale = new Vector3(_initialScale.x * Vector3.Distance(objToScale.transform.position, target.transform.position) * offset, _initialScale.y * Vector3.Distance(objToScale.transform.position, target.transform.position) * offset, _initialScale.z * Vector3.Distance(objToScale.transform.position, target.transform.position) * offset);
    }
}
