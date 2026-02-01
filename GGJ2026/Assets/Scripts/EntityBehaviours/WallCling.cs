using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallCling : MonoBehaviour
{
    [SerializeField] private GameObject origin;
    [SerializeField] private GameObject target;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask layer;

    [SerializeField] private Gravity gravity;

    private bool _wasClinged = false;
    public Vector3 lastNormal;

    [SerializeField] private UnityEvent grabbed;
    [SerializeField] private UnityEvent released;

    private void Start() {
    }

    private void Update()
    {
        RaycastHit hit;
        bool clinged = Physics.Raycast(origin.transform.position, (target.transform.position - origin.transform.position).normalized, out hit, rayDistance, layer);

        if (_wasClinged && !clinged) {
            released?.Invoke();
            gravity.onTakeOff?.Invoke();
        }

        if (!_wasClinged && clinged) {
            grabbed?.Invoke();
            gravity.onLand?.Invoke();
        }

        _wasClinged = clinged;
        if (!clinged) {
            lastNormal = Vector3.zero;
            return;
        }

        lastNormal = hit.normal;
        gravity.SetIsGrounded(true);
        gravity.onLand?.Invoke();
    }

    public void ResetClingedState() {
        lastNormal = Vector3.zero;
        _wasClinged = false;
    }
}

