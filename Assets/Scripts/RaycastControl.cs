using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastControl : MonoBehaviour
{
    [SerializeField]
    private float _distance = 10f;

    [SerializeField]
    private Transform _targetSprite;

    [SerializeField]
    private LayerMask _layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * _distance, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(new Ray(transform.position, transform.forward), out hit, _distance, _layerMask))
        {
            //Debug.Log(hit.point);

            // this is normal ray.
            Debug.DrawRay(hit.point, hit.normal, Color.blue);

            Debug.Log(hit.normal);

            _targetSprite.position = hit.point;
            var projected = Vector3.ProjectOnPlane(transform.forward, hit.normal);

            // this is projected ray.
            Debug.DrawRay(hit.point, projected, Color.red);

            _targetSprite.forward = -hit.normal;

            var eulerRotation = _targetSprite.eulerAngles;
            eulerRotation.z = transform.rotation.eulerAngles.z;
            _targetSprite.eulerAngles = eulerRotation;
        }
    }
}
