Shader "Hidden/Shader/CopycatVisionPostProcessing"
{
    //Properties
    //{
    //    _CurvatureIntensity ("Curvature Intensity", Range(0, 1)) = 0.5
    //    _VignetteIntensity ("Vignette Intensity", Range(0, 1)) = 9.0
    //    _BlurIntensity ("Blur Intensity", float) = 1.5
    //	_GhostingIntensity ("Ghost Intensity", Range(0, 1)) = 0.5
    //	_DistortionIntensity ("Distortion Intensity", Range(0, 1)) = 0.5
    //	_DistortionSpeed ("Distortion Speed", Range(0, 1)) = 0.1
    //    _ScanlinesIntensity ("Scanlines Intensity", Range(0, 1)) = 0.1
    //    _ScanlinesScrollSpeed ("Scalines Scroll Speed", Range(0, 1)) = 1    
    //}
    
    
    HLSLINCLUDE

    #pragma target 4.5
    #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal
    #define MOD(x, y) (x-y*floor(x/y))
    #define MAP(value, start1, stop1, start2, stop2) (start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1)))


    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/PostProcessing/Shaders/FXAA.hlsl"
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/PostProcessing/Shaders/RTUpscale.hlsl"

    // List of properties to control your post process effect
    TEXTURE2D_X( _MainTex);
    SamplerState sampler_MainTex;
    float _RedChannel = 1;
    float _GreenChannel = 0.2;
    float _BlueChannel = 0.2;
    static float _Gamma = 0.5;
    float _Intensity;
    float _CurvatureIntensity;
    float _VignetteIntensity;
    static float _BlurIntensity = 1;
    float _DistortionIntensity;
    float _DistortionSpeed;
    float _GhostingIntensity;
    static float _ScanlinesScrollSpeed = 1;
    static float _ScanlinesIntensity = 0.1;
    float _NoiseIntensity;

    struct Attributes
    {
        uint vertexID : SV_VertexID;
        UNITY_VERTEX_INPUT_INSTANCE_ID
    };

    struct Varyings
    {
        float4 positionCS : SV_POSITION;
        float2 texcoord   : TEXCOORD0;
        UNITY_VERTEX_OUTPUT_STEREO
    };
            
    float3 sample(Texture2DArray tex, float2 tc )
    {
    	float3 s = pow(LOAD_TEXTURE2D_X(tex, tc).rgb, 2.2);
    	return s;
    }

    float rand(float2 co)
    {
        return frac(sin(dot(co.xy ,float2(12.9898,78.233))) * 43758.5453);
    }
    
    float2 curve(float2 uv)
	{
		uv = (uv - 0.5) * 2.0;
		uv *= 1.1;	
		uv.x *= 1.0 + pow(abs(uv.y) / 5, 2);
		uv.y *= 1.0 + pow(abs(uv.x) / 4, 2);
		uv  = (uv / 2.0) + 0.5;
		uv =  uv * 0.92 + 0.04;
		return uv;
	}

    float3 blur(Texture2DArray tex, float2 tc, float2 screenPosition, float offs)
	{
		float4 xoffs = offs * _BlurIntensity * float4(-2.0, -1.0, 1.0, 2.0);
		float4 yoffs = offs * _BlurIntensity * float4(-2.0, -1.0, 1.0, 2.0);
		
		float3 color = float3(0.0, 0.0, 0.0);
    	color += sample(tex,tc + float2(xoffs.x, yoffs.x)) * 0.00366;
		color += sample(tex,tc + float2(xoffs.y, yoffs.x)) * 0.01465;
		color += sample(tex,tc + float2(    0.0, yoffs.x)) * 0.02564;
		color += sample(tex,tc + float2(xoffs.z, yoffs.x)) * 0.01465;
		color += sample(tex,tc + float2(xoffs.w, yoffs.x)) * 0.00366;
		
		color += sample(tex,tc + float2(xoffs.x, yoffs.y)) * 0.01465;
		color += sample(tex,tc + float2(xoffs.y, yoffs.y)) * 0.05861;
		color += sample(tex,tc + float2(    0.0, yoffs.y)) * 0.09524;
		color += sample(tex,tc + float2(xoffs.z, yoffs.y)) * 0.05861;
		color += sample(tex,tc + float2(xoffs.w, yoffs.y)) * 0.01465;
		
		color += sample(tex,tc + float2(xoffs.x, 0.0)) * 0.02564;
		color += sample(tex,tc + float2(xoffs.y, 0.0)) * 0.09524;
		color += sample(tex,tc + float2(    0.0, 0.0)) * 0.15018;
		color += sample(tex,tc + float2(xoffs.z, 0.0)) * 0.09524;
		color += sample(tex,tc + float2(xoffs.w, 0.0)) * 0.02564;
		
		color += sample(tex,tc + float2(xoffs.x, yoffs.z)) * 0.01465;
		color += sample(tex,tc + float2(xoffs.y, yoffs.z)) * 0.05861;
		color += sample(tex,tc + float2(    0.0, yoffs.z)) * 0.09524;
		color += sample(tex,tc + float2(xoffs.z, yoffs.z)) * 0.05861;
		color += sample(tex,tc + float2(xoffs.w, yoffs.z)) * 0.01465;
		
		color += sample(tex,tc + float2(xoffs.x, yoffs.w)) * 0.00366;
		color += sample(tex,tc + float2(xoffs.y, yoffs.w)) * 0.01465;
		color += sample(tex,tc + float2(    0.0, yoffs.w)) * 0.02564;
		color += sample(tex,tc + float2(xoffs.z, yoffs.w)) * 0.01465;
		color += sample(tex,tc + float2(xoffs.w, yoffs.w)) * 0.00366;
    	
    	return color;
	}

    Varyings Vert(Attributes input)
    {
        Varyings output;
        UNITY_SETUP_INSTANCE_ID(input);
        UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);
        output.positionCS = GetFullScreenTriangleVertexPosition(input.vertexID);
        output.texcoord = GetFullScreenTriangleTexCoord(input.vertexID);
        return output;
    }

    float4 CustomPostProcess(Varyings input) : SV_Target
    {
        UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input);
    	uint2 uv = input.positionCS;
    	float3 col;

    	col = LOAD_TEXTURE2D_X(_MainTex, uv).rgb;
    	
    	////CURVATURE
    	//uv = lerp( curve( uv ), uv, MAP(_CurvatureIntensity, 0, 1, 2, 0));
    	
    	//DISTORTION
		float x =  sin(0.1 * MAP(_DistortionSpeed, 0, 1, 0, 100) * _Time.y + input.texcoord.y * 21.0) * sin(0.23 * MAP(_DistortionSpeed, 0, 1, 0, 100) * _Time.y + input.texcoord.y * 29.0) * sin(0.3 + 0.11 * MAP(_DistortionSpeed, 0, 1, 0, 100) + _Time.y + input.texcoord.y * 31.0) * MAP(_DistortionIntensity, 0, 1, 0, 10);
		float o = 2.0 * MOD(input.texcoord.y, 2.0) / input.positionCS.x;
		x += o;
    	
        ////BLUR
		col.r = 1.0 * blur(_MainTex,float2(x + uv.x + 0.0009, uv.y + 0.0009), input.positionCS, 0).x + 0.005;
		col.g = 1.0 * blur(_MainTex,float2(x + uv.x + 0.000, uv.y - 0.0015), input.positionCS, 0).y + 0.005;
		col.b = 1.0 * blur(_MainTex,float2(x + uv.x - 0.0015, uv.y + 0.000), input.positionCS, 0).z + 0.005;
		col.r += 0.2 * blur(_MainTex,float2(x + uv.x + 0.0009, uv.y + 0.0009),input.positionCS,0).x - 0.005;
		col.g += 0.2 * blur(_MainTex,float2(x + uv.x + 0.000, uv.y - 0.0015), input.positionCS, 0).y - 0.005;
		col.b += 0.2 * blur(_MainTex,float2(x + uv.x - 0.0015, uv.y + 0.000), input.positionCS,0).z - 0.005;
    	
        //GHOSTING
    	float ghs = MAP(_GhostingIntensity, 0, 1, 0, 10);
		col.r += ghs * (1.0-0.299) * blur(_MainTex,0.75 * float2(x - 0.01, -0.027) + float2(uv.x + 0.001, uv.y + 0.001), input.positionCS, 7.0).x;
		col.g += ghs * (1.0-0.587) * blur(_MainTex,0.75 * float2(x +- 0.022, -0.02) + float2(uv.x + 0.000, uv.y - 0.002), input.positionCS,5.0).y;
		col.b += ghs * (1.0-0.114) * blur(_MainTex,0.75 * float2(x +- 0.02, -0.0) + float2(uv.x - 0.002, uv.y + 0.000), input.positionCS,3.0).z;
		col = clamp(col * 0.4 + 0.6 * col * col * 1.0, 0.0, 1.0);
    	
    	//VIGNETTE
    	float vig = (0.0 + 1.0 * 16.0 * input.texcoord.x * input.texcoord.y * (1.0 - input.texcoord.x) * (1.0 - input.texcoord.y));
		vig = pow(vig, MAP(_VignetteIntensity, 0, 1, 0, 5));
		col *= vig;
    	
    	//RGB INTENSITY
    	col *= float3(_RedChannel, _GreenChannel, _BlueChannel);
		col = lerp( col, col * col, 0.3) * 3.8;
    	
    	////SCANLINES
		//float scans = clamp( 0.35 + 0.15 * sin(3.5 * (_Time.y * _ScanlinesScrollSpeed) + uv.y * _ScreenParams.y * 1.5), 0.0, 1.0);
		//float s = pow(scans, MAP(_ScanlinesIntensity, 0, 1, 0, 5));
		//col = col * s;
    	
    	//Film Grain
    	col *= 1.0 + 0.0015 * sin(300.0 * _Time);
		col *= 1.0 - 0.15 * clamp((MOD(input.texcoord.x + o, 2.0) - 1.0) * 2.0, 0.0, 1.0);
		col *= 1.0 - MAP(_NoiseIntensity, 0, 1, 0, 3) * float3( rand( input.texcoord + 0.0001 * _Time.y),  rand( input.texcoord + 0.0001 * _Time.y + 0.3),  rand( input.texcoord + 0.0001 * _Time.y + 0.5));

    	//GAMMA CORRECTION
		col = pow(col, 0.4);

    	////FILL BLACK OUTSIDE CURVATURE
		//if (uv.x < 0.0 || uv.x > 1.0)
		//	col *= 0.0;
		//if (uv.y < 0.0 || uv.y > 1.0)
		//	col *= 0.0;
    	return float4(col , 1);
    }

    ENDHLSL

    SubShader
    {
        Pass
        {
            Name "CopycatVisionPostProcessing"

            ZWrite Off
            ZTest Always
            Blend Off
            Cull Off

            HLSLPROGRAM
                #pragma fragment CustomPostProcess
                #pragma vertex Vert
            ENDHLSL
        }
    }
    Fallback Off
}
