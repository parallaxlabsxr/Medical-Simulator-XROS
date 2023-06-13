Shader "Custom/LiquidFillShader"
{
    Properties {
        _FillAmount("Fill Amount", Range(0, 1)) = 0
        _MainTex("Main Texture", 2D) = "white" {}
    }
    
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200
        
        CGPROGRAM
        #pragma surface surf Lambert
        
        sampler2D _MainTex;
        fixed _FillAmount;
        
        struct Input {
            float2 uv_MainTex;
        };
        
        void surf(Input IN, inout SurfaceOutput o) {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            c.rgb *= _FillAmount;
            o.Albedo = c.rgb;
        }
        ENDCG
    }
    
    FallBack "Diffuse"
}