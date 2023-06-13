Shader "Custom/transparent_col" {
     Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _TransparentColor ("Transparent Color", Color) = (1,1,1,1)
        _Threshold ("Threshold", Range(0, 1)) = 0.1
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200
        
        Pass {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            Lighting Off
        
            HLSLINCLUDE
            #include "UnityCG.hlsl"
        
            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
        
            struct v2f {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };
        
            sampler2D _MainTex;
            float4 _Color;
            float4 _TransparentColor;
            float _Threshold;
        
            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
        
            fixed4 frag (v2f i) : SV_Target {
                fixed4 c = tex2D(_MainTex, i.uv);
                fixed4 output_col = c * _Color;
        
                float3 transparent_diff = c.rgb - _TransparentColor.rgb;
                float transparent_diff_squared = dot(transparent_diff, transparent_diff);
        
                if (transparent_diff_squared < _Threshold * _Threshold)
                    discard;
        
                fixed4 final_col;
                final_col.rgb = output_col.rgb;
                final_col.a = output_col.a;
                return final_col;
            }
            ENDCG
        }
    }
    Fallback "Diffuse"
 }