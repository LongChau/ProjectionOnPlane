using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Transform _targetSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                Debug.Log(hit.normal);

                // Do something with the object that was hit by the raycast.
                _targetSprite.position = hit.point + hit.normal * 0.005f;
                _targetSprite.forward = hit.normal;
                //_targetSprite.rotation = Quaternion.FromToRotation(transform.up, hit.normal);
            }
        }
    }
}
