Shader "Unlit/PicShot"
{
    Properties
    {   
        _ColorA ("ColorA", Color) = (1,1,1,1)
        _ColorB ("ColorB", Color) = (1,1,1,1)
        _ColorStart ("ColorStart", Range(0,1)) = 0
        _ColorEnd ("ColorEnd", Range(0,1)) = 1
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
 
           float4 _ColorA;
           float4 _ColorB;

           float _ColorStart;
           float _ColorEnd;

            struct MeshData  
            {  
                float4 vertex : POSITION;       
                float3 normals : NORMAL;   
                float4 uv0 : TEXCOORD0;        
            };

            struct Interpolaters   
            {                
                float4 vertex : SV_POSITION;  
                float3 normal : TEXCOORD0;      
                float2 uv : TEXCOORD1; 
            };   
                             
            Interpolaters vert (MeshData v)                                                          
            {
                Interpolaters o;
                o.vertex = UnityObjectToClipPos(v.vertex);   
                o.normal = UnityObjectToWorldNormal(v.normals);                  
                o.uv = v.uv0;
                return o;  
            }

            float InverseLerp(float a, float b, float v)
            {
                return(v-a)/(b-a);
            }

            float4 frag (Interpolaters i) : SV_Target
            {
                float t = InverseLerp(_ColorStart, _ColorEnd, i.uv.x);
                float4 outColor = lerp(_ColorA, _ColorB, t);
                return outColor;
            }
            ENDCG 
        }
    }
}
