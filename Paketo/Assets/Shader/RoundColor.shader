Shader "Custom/PostProcess/RoundColor"
{
    Properties
    {
        _RoundForce("Round Force", Float) = 1.0
    }

    SubShader
    {
        Tags { "RenderPipeline" = "UniversalPipeline" }
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM
            #pragma vertex Vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareOpaqueTexture.hlsl"
            #include "Packages/com.unity.render-pipelines.core/Runtime/Utilities/Blit.hlsl"

            CBUFFER_START(UnityPerMaterial)
                float _RoundForce;
            CBUFFER_END

            float3 frag(Varyings IN) : SV_Target
            {
                float3 color = SampleSceneColor(IN.texcoord);
                float rf = max(_RoundForce, 0.0001);
                color.rgb = round(color.rgb * rf) / rf;
                return color;
            }
            ENDHLSL
        }
    }
}