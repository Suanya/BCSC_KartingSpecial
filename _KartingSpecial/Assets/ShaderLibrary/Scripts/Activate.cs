

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    [SerializeField]
    private Material material;

    [SerializeField]
    private Color activateColor;

    // public AudioSource heartBeat;
    
    private void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
        activateColor = material.GetColor("_ActivateColor");
        material.SetColor("_ActivateChangeColor", activateColor);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CastClickRay();
        }
    }

    private void CastClickRay()
    {
        var camera = Camera.main;
        var mousePosition = Input.mousePosition;
        var ray = camera.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y,
            camera.nearClipPlane));

        if (Physics.Raycast(ray, out var hit) && hit.collider.gameObject == gameObject)
        {
            StartWobble(hit.point);
        }
    }

    private void StartWobble(Vector3 center)
    {
        material.SetFloat("_ActivateScale", 3);
        material.SetFloat("_ActivatePulseRate", 2);

        Color activateChangeColor = Color.HSVToRGB(Random.value, 1, 1);
        material.SetColor("_ActivateColor", activateColor);
        material.SetColor("_ActivateChangeColor", activateChangeColor);
        activateColor = activateChangeColor;
    }
}


