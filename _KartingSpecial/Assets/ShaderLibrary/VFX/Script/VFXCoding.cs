using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXCoding : MonoBehaviour
{
    [SerializeField]
    private VisualEffect m_vfx;

    [SerializeField]
    private float m_float;



    // Update is called once per frame
    void Update()
    {
        m_vfx.SetFloat("SpawnRate", m_float);
    }
}
