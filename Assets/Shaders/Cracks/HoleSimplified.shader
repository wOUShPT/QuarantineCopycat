Shader "HoleSimplified"
{
	Properties
	{
		_RenderQueueType("Render Queue Type", Float) = 1
		[ToggleUI]_SupportDecals("Boolean", Float) = 1
		[HideInInspector] _StencilRef("Stencil Ref", Int) = 0
		_StencilRefDepth("Stencil Ref Depth", Int) = 8
		_StencilReadMaskDepth("Stencil Read Mask Depth", Int) = 8
		_StencilWriteMaskDepth("Stencil Write Mask Depth", Int) = 8
		[HideInInspector] _StencilRefMV("Stencil Ref MV", Int) = 40
		[HideInInspector] _StencilWriteMaskMV("Stencil Write Mask MV", Int) = 40
		[HideInInspector] _StencilRefDistortionVec("Stencil Ref Distortion Vec", Int) = 4
		[HideInInspector] _StencilWriteMaskDistortionVec("Stencil Write Mask Distortion Vec", Int) = 4
		 _StencilWriteMaskGBuffer("Stencil Write Mask GBuffer", int) = 14
		 _StencilReadMaskGBuffer("Stencil Read Mask GBuffer", int) = 14
		 _StencilRefGBuffer("Stencil Ref GBuffer", Int) = 10
		 _ZTestGBuffer("ZTest GBuffer", Int) = 4
		[ToggleUI] _ZWrite("ZWrite", Float) = 1
		[HideInInspector] [Enum(Front, 1, Back, 2)] _TransparentCullMode("Transparent Cull Mode", Float) = 2
	}

	SubShader
	{

		Tags { "RenderPipeline"="HDRenderPipeline" "RenderType"="Opaque" "Queue"="Geometry-1000" }

		HLSLINCLUDE
		#pragma target 4.5
		#pragma only_renderers d3d11 metal vulkan xboxone xboxseries playstation switch 
		#pragma multi_compile_instancing
		#pragma instancing_options renderinglayer
		#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/ShaderPass/LitSharePass.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitData.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassGBuffer.hlsl"
	
		ENDHLSL
		
		ColorMask 0
		
		Pass
		{
			
			Name "GBuffer"
			Tags { "LightMode"="GBuffer" }

			Cull Back
			ZTest [_ZTestGBuffer]
			ZWrite [_ZWrite]

			Stencil
			{
				Ref [_StencilRefGBuffer]
				ReadMask [_StencilWriteMaskGBuffer]
				WriteMask [_StencilWriteMaskGBuffer]
				Comp Always
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			
		}
		
		Pass
		{
			
			Name "DepthOnly"
			Tags { "LightMode"="DepthOnly" }

			Cull [_CullMode]

			ZWrite on

			Stencil
			{
				Ref [_StencilRefGBuffer]
				ReadMask [_StencilWriteMaskGBuffer]
				WriteMask [_StencilWriteMaskGBuffer]
				Comp NotEqual
				Pass Replace
				Fail Keep
				ZFail Keep
			}

		}

	}
	
}