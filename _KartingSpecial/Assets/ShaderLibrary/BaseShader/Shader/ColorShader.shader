Shader "Unlit/ColorShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,0,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
       

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
           

            #include "UnityCG.cginc"

            float4 _Color;

            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;

                float2 uv1 : TEXCOORD1;
            };

            struct Interpolateros
            {
                float4 vertex : SV_POSITION;
            };

          

            Interpolateros vert (MeshData v)
            {
                Interpolateros o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                // o.vertex = v.vertey; -> stuckToCamera    
                
                return o;
            }

            fixed4 frag (Interpolateros i) : SV_Target
            {  
                return _Color;
            }  
            ENDCG 
        }
    }
}
