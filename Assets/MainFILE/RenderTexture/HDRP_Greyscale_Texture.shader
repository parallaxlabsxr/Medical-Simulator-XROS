Shader "Custom/HDRP_Greyscale_Texture" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1, 1, 1, 1)
    }

    SubShader {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        fixed4 _Color;

        struct Input {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o) {
            fixed4 texColor = tex2D(_MainTex, IN.uv_MainTex);
            fixed3 greyColor = dot(texColor.rgb, float3(0.299, 0.587, 0.114));

            o.Albedo = greyColor * _Color.rgb;
            o.Alpha = texColor.a * _Color.a;
        }
        ENDCG
    }

    FallBack "Diffuse"
}