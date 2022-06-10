using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderAlterer : MonoBehaviour
{
    
    [SerializeField]
    private Renderer m_rend;


    [SerializeField]
    private float amt;
    

    public Material m_shader;
    public bool m_shaderMaterial = false;
    
    
    public void SetShader()
    {
        m_rend.material.SetFloat("_PusleRate", amt);
    }
    

    public void OnMouseDown()
    {
        

        GetComponent<Material>();
        Debug.Log("Click");
    }

}
