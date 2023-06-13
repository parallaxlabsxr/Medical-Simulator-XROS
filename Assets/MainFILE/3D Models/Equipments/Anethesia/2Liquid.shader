Shader "BitshiftProgrammer/2Liquid"
{
    Properties {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _Percentage ("Percentage", Range(0, 1)) = 0
    }

    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        fixed4 _Color;
        float _Percentage;

        struct Input {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o) {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            c.rgb = lerp(c.rgb, _Color.rgb, _Percentage);
            o.Albedo = c.rgb;
            o.Alpha = (c.a == 0) ? 0 : 1;
        }
        ENDCG
    }
    FallBack "Diffuse"
}