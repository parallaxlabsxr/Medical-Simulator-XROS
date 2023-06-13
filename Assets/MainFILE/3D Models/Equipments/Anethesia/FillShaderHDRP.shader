Shader "Custom/FillShaderHDRP" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _FillAmount ("Fill Amount", Range(0, 1)) = 1
        _Color ("Color", Color) = (1, 1, 1, 1)
    }
    
    SubShader {
        Tags { "RenderPipeline" = "HDRP" }
        HLSLPROGRAM
        
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/Common.hlsl"
        
        #pragma shader_feature _ _ALPHATEST_ON _ALPHABLEND_ON _ALPHAPREMULTIPLY_ON
        #pragma target 4.5
        
        struct appdata {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
        };
        
        struct v2f {
            float2 uv : TEXCOORD0;
            float4 vertex : SV_POSITION;
            UNITY_FOG_COORDS(1)
        };
        
        sampler2D _MainTex;
        float _FillAmount;
        float4 _Color;
        
        v2f vert (appdata v) {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
            o.uv = v.uv;
            UNITY_TRANSFER_FOG(o, o.vertex);
            return o;
        }
        
        fixed4 frag (v2f i) : SV_Target {
            fixed4 col = tex2D(_MainTex, i.uv);
            col.rgb *= _Color.rgb;
            col.a *= _Color.a * smoothstep(_FillAmount - 0.05, _FillAmount + 0.05, col.a);
            UNITY_APPLY_FOG(i.fogCoord, col);
            return col;
        }
        
        ENDHLSL
        
        Pass {
            Cull Off
            ZWrite Off
            ZTest Always
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            
            sampler2D _MainTex;
            float _FillAmount;
            fixed4 _Color;
            
            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb *= _Color.rgb;
                col.a *= _Color.a * smoothstep(_FillAmount - 0.05, _FillAmount + 0.05, col.a);
                return col;
            }
            
            ENDCG
        }
    }
    
    FallBack "Diffuse"
}