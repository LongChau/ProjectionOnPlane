using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SherecastControl : MonoBehaviour
{
    [SerializeField]
    private float _distance = 10f;

    [SerializeField]
    private Transform _targetSprite;

    [SerializeField]
    private LayerMask _layerMask;

    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * _distance, Color.green);

        if (Physics.SphereCast(new Ray(transform.position, transform.forward), 0.5f, out _hit, _distance, _layerMask))
        {
            // this is normal ray.
            Debug.DrawRay(_hit.point, _hit.normal * _distance, Color.blue);

            Debug.Log(_hit.normal);

            _targetSprite.position = _hit.point;
            var projected = Vector3.ProjectOnPlane(transform.forward, _hit.normal);

            // this is projected ray.
            Debug.DrawRay(_hit.point, projected * _distance, Color.red);

            _targetSprite.forward = -_hit.normal;

            var eulerRotation = _targetSprite.eulerAngles;
            eulerRotation.z = transform.rotation.eulerAngles.z;
            _targetSprite.eulerAngles = eulerRotation;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_hit.point, 0.5f);
    }
}
