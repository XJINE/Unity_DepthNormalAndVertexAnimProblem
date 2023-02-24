Shader "Hidden/DetphTexture"
{
    Properties
    {
        [HideInInspector] _MainTex("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Cull   Off
        ZWrite Off
        ZTest  Always

        Pass
        {
            CGPROGRAM

            #include "UnityCG.cginc"

            #pragma vertex   vert_img
            #pragma fragment frag

            sampler2D _MainTex;

            float4 frag(v2f_img input) : SV_Target
            {
                const float bias = 5;
                return tex2D(_MainTex, input.uv) * bias;
            }

            ENDCG
        }
    }
}