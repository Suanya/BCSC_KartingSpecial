Shader "Unlit/BaseShader"
{
    Properties // ownDefined inputData
    {
        
        _Value ("Value", Float) = 1.0     
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

            
           float _Value;  

            // automatically filled out by unity
            struct MeshData  // perVertex meshData  
            {
                float4 vertex : POSITION; // vertexPosition
                float3 normals : NORMAL; // normalDirection of a vertex   
                float4 tangent : TANGENT; // tangentDirection, 4th component contents important information  
                float4 color : COLOR;
                float2 uv0 : TEXCOORD0; // uv0 coordinates -> diffuse/normal map textures 
                float2 uv1 : TEXCOORD1; // uv1 coordinates might be lightmap coordinatesb -> many uvseseses possible  
            };

            struct Interpolaters // v2f
            { 
                // float2 uv : TEXCOORD0; 
                float4 vertex : SV_POSITION; // clipSpacePosition of the vertex                      
            };  

                                  

            Interpolaters vert (MeshData v)                                                          
            {
                Interpolaters o;
                o.vertex = UnityObjectToClipPos(v.vertex);    // multiplying by modelViewProjectionMatrix (mwpMatrix) -> localSpace to clipSpace 
                // o.vertex = v.vertex; -> stuckToCamera
                return o;
            }

            // bool 0 1
            // int (in many cases uneseceserry)
            // frag enGeneral exists in
            // float (32 bit flaot)
            // half (16 bit float) (lowerEnd platforms -> lowerPresicion stuff)
            // fixed (lower precision only useful in Range [-1,1])
            // float4 -> half4 -> fixed4
            // float4x4 -> half4x4 ...
            // use float[...] everywhere until you must optimize 

            // actual fragmentShader
            float4 frag (Interpolaters i) : SV_Target
            {          
                return 0;
            }
            ENDCG 
        }
    }
}
