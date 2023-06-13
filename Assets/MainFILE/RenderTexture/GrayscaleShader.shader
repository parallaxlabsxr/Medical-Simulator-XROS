Shader "Custom/GrayscaleShader" {
    Properties {
        _MainTex ("Main Texture", 2D) = "white" {}
        _GrayscaleIntensity ("Grayscale Intensity", Range(0, 1)) = 1
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200
        
        CGPROGRAM
        #pragma surface surf Lambert
        
        sampler2D _MainTex;
        float _GrayscaleIntensity;
        
        struct Input {
            float2 uv_MainTex;
        };
        
        void surf (Input IN, inout SurfaceOutput o) {
            half4 color = tex2D(_MainTex, IN.uv_MainTex);
            float grayscale = dot(color.rgb, float3(0.299, 0.587, 0.114));
            float3 grayscaleColor = lerp(color.rgb, grayscale, _GrayscaleIntensity);
            
            o.Albedo = grayscaleColor;
            o.Alpha = color.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}