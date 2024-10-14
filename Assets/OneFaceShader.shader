Shader "Custom/OneFaceTexture" {
    Properties {
        _MainTex ("Main Texture", 2D) = "white" {}
        _FaceTex ("Face Texture", 2D) = "white" {}
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;   // Textura general (blanco)
            sampler2D _FaceTex;   // Textura de la cara específica

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                float3 normal : TEXCOORD1;
            };

            v2f vert (appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.normal = v.normal;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                // Asignar el color blanco a todas las caras por defecto
                fixed4 color = tex2D(_MainTex, i.uv);

                // Si la cara del cubo tiene la normal en el eje Z positivo, aplicamos la textura del mural
                if (i.normal.z > 0.9) {
                    color = tex2D(_FaceTex, i.uv);
                }

                return color;
            }
            ENDCG
        }
    }
}
