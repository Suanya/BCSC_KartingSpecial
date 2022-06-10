using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveRippleController : MonoBehaviour
{
    [SerializeField]
    private Material material;


    private void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            CastClickRay();
        }
    }

    private void CastClickRay()
    {
        var camera = Camera.main;
        var mousePosition = Input.mousePosition;

        // the xy coordinates are in screen space, while the z coordinate is in view space
        var ray = camera.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, camera.nearClipPlane));

        // if our ray hits a collider, and that collider is attached to his game object
        if(Physics.Raycast(ray, out var hit) && hit.collider.gameObject == gameObject)
        {
            StartRipple(hit.point);
        }
    }

    private void StartRipple(Vector3 center)
    {
        material.SetVector("_RippleCenter", center);

        // the Time.timeSinceLevelLoad value is the same as the Time node in shader graph
        material.SetFloat("_RippleStartTime", Time.time);
    }
}
