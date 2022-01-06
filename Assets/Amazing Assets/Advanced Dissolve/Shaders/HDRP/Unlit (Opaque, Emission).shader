Shader "Amazing Assets/Advanced Dissolve/Shader Graph/Unlit (Opaque, Emission)"
{
    Properties
    {
//Advanced Dissolve Properties Start////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Cutout
[HideInInspector]                                                   _AdvancedDissolveCutoutStandardClip("", Range(0,1)) = 0.5

[HideInInspector]											        _AdvancedDissolveCutoutStandardMap1("", 2D) = "white" { }
[HideInInspector]											        _AdvancedDissolveCutoutStandardMap1Tiling("", Vector) = (1, 1, 1, 0)
[HideInInspector]											        _AdvancedDissolveCutoutStandardMap1Offset("", Vector) = (0, 0, 0, 0)
[HideInInspector]					                                _AdvancedDissolveCutoutStandardMap1Scroll("", Vector) = (0, 0, 0, 0)
[HideInInspector]											        _AdvancedDissolveCutoutStandardMap1Intensity("", Range(0, 1)) = 1
[HideInInspector][Enum(Red, 0, Green, 1, Blue, 2, Alpha, 3)]        _AdvancedDissolveCutoutStandardMap1Channel("", INT) = 3
[HideInInspector][AdvancedDissolveToggleFloat]				        _AdvancedDissolveCutoutStandardMap1Invert("", INT) = 0
[HideInInspector]											        _AdvancedDissolveCutoutStandardMap2("", 2D) = "white" { }
[HideInInspector]											        _AdvancedDissolveCutoutStandardMap2Tiling("", Vector) = (1, 1, 1, 0)
[HideInInspector]											        _AdvancedDissolveCutoutStandardMap2Offset("", Vector) = (0, 0, 0, 0)
[HideInInspector]					                                _AdvancedDissolveCutoutStandardMap2Scroll("", Vector) = (0, 0, 0, 0)
[HideInInspector]											        _AdvancedDissolveCutoutStandardMap2Intensity("", Range(0, 1)) = 1
[HideInInspector][Enum(Red, 0, Green, 1, Blue, 2, Alpha, 3)]        _AdvancedDissolveCutoutStandardMap2Channel("", INT) = 3
[HideInInspector][AdvancedDissolveToggleFloat]				        _AdvancedDissolveCutoutStandardMap2Invert("", INT) = 0
[HideInInspector]											        _AdvancedDissolveCutoutStandardMap3("", 2D) = "white" { }
[HideInInspector]											        _AdvancedDissolveCutoutStandardMap3Tiling("", Vector) = (1, 1, 1, 0)
[HideInInspector]											        _AdvancedDissolveCutoutStandardMap3Offset("", Vector) = (0, 0, 0, 0)
[HideInInspector]					                                _AdvancedDissolveCutoutStandardMap3Scroll("", Vector) = (0, 0, 0, 0)
[HideInInspector]											        _AdvancedDissolveCutoutStandardMap3Intensity("", Range(0, 1)) = 1
[HideInInspector][Enum(Red, 0, Green, 1, Blue, 2, Alpha, 3)]        _AdvancedDissolveCutoutStandardMap3Channel("", INT) = 3
[HideInInspector][AdvancedDissolveToggleFloat]				        _AdvancedDissolveCutoutStandardMap3Invert("", INT) = 0

[HideInInspector][Enum(Multiply, 0, Add, 1)]				        _AdvancedDissolveCutoutStandardMapsBlendType("", Float) = 0
[HideInInspector][Enum(World, 0, Local, 1)]					        _AdvancedDissolveCutoutStandardMapsTriplanarMappingSpace("", Float) = 0	
[HideInInspector][Enum(Constant, 0, Camera Relative, 1)]            _AdvancedDissolveCutoutStandardMapsScreenSpaceUVScale("", Float) = 0
[HideInInspector][AdvancedDissolveToggleFloat]				        _AdvancedDissolveCutoutStandardBaseInvert("", INT) = 0

//Geometric
[HideInInspector][AdvancedDissolveToggleFloat]			    	    _AdvancedDissolveCutoutGeometricInvert("", Float) = 0
[HideInInspector]										    	    _AdvancedDissolveCutoutGeometricNoise("", Float) = 0.1	

[HideInInspector][Enum(X, 0, Y, 1, Z, 2)]                           _AdvancedDissolveCutoutGeometricXYZAxis("", Float) = 0
[HideInInspector][Enum(Linear, 0, Symmetrical, 1)]                  _AdvancedDissolveCutoutGeometricXYZStyle("", Float) = 0 
[HideInInspector][Enum(World, 0, Local, 1)]                         _AdvancedDissolveCutoutGeometricXYZSpace("", Float) = 0	 
[HideInInspector]											        _AdvancedDissolveCutoutGeometricXYZRollout("", Float) = 0
[HideInInspector]											        _AdvancedDissolveCutoutGeometricXYZPosition("", Vector) = (0, 0, 0, 0)

[HideInInspector]										    	    _AdvancedDissolveCutoutGeometric1Position("", Vector) = (0,0,0,0)
[HideInInspector]										    	    _AdvancedDissolveCutoutGeometric1Normal("", Vector) = (1,0,0,0)
[HideInInspector]										    	    _AdvancedDissolveCutoutGeometric1Radius("", Float) = 1
[HideInInspector]										    	    _AdvancedDissolveCutoutGeometric1Height("", Float) = 1

[HideInInspector]										    	    _AdvancedDissolveCutoutGeometric2Position("", Vector) = (0,0,0,0)
[HideInInspector]									    		    _AdvancedDissolveCutoutGeometric2Normal("", Vector) = (1,0,0,0)
[HideInInspector]									    		    _AdvancedDissolveCutoutGeometric2Radius("", Float) = 1
[HideInInspector]									    		    _AdvancedDissolveCutoutGeometric2Height("", Float) = 1
 
[HideInInspector]									    		    _AdvancedDissolveCutoutGeometric3Position("", Vector) = (0,0,0,0)
[HideInInspector]									    		    _AdvancedDissolveCutoutGeometric3Normal("", Vector) = (1,0,0,0)
[HideInInspector]									    		    _AdvancedDissolveCutoutGeometric3Radius("", Float) = 1
[HideInInspector]										    	    _AdvancedDissolveCutoutGeometric3Height("", Float) = 1

[HideInInspector]										    	    _AdvancedDissolveCutoutGeometric4Position("", Vector) = (0,0,0,0)
[HideInInspector]											        _AdvancedDissolveCutoutGeometric4Normal("", Vector) = (1,0,0,0)
[HideInInspector]											        _AdvancedDissolveCutoutGeometric4Radius("", Float) = 1
[HideInInspector]											        _AdvancedDissolveCutoutGeometric4Height("", Float) = 1

//Edge
[HideInInspector]										    	    _AdvancedDissolveEdgeBaseWidthStandard("", Range(0,1)) = 0.1 
[HideInInspector]										    	    _AdvancedDissolveEdgeBaseWidthGeometric("", Range(0,1)) = 0.1 
[HideInInspector][Enum(Solid, 0, Smooth, 1, Smoother, 2)]           _AdvancedDissolveEdgeBaseShape("", INT) = 0
[HideInInspector][AdvancedDissolveColorRGB]  				        _AdvancedDissolveEdgeBaseColor("", Color) = (0,1,0,1)
[HideInInspector]											        _AdvancedDissolveEdgeBaseColorTransparency("", Range(0, 1)) = 1
[HideInInspector][AdvancedDissolveExponental]                       _AdvancedDissolveEdgeBaseColorIntensity("", Vector) = (0, 0, 0, 0)		

[HideInInspector][AdvancedDissolveColorRGB]					        _AdvancedDissolveEdgeAdditionalColor("", color) = (1, 0, 0, 1)
[HideInInspector]											        _AdvancedDissolveEdgeAdditionalColorTransparency("", Range(0, 1)) = 1
[HideInInspector][AdvancedDissolveExponental]			            _AdvancedDissolveEdgeAdditionalColorIntensity("", Vector) = (0, 0, 0, 0)
[HideInInspector]								                    _AdvancedDissolveEdgeAdditionalColorMap("", 2D) = "white" { }
[HideInInspector]					                                _AdvancedDissolveEdgeAdditionalColorMapTiling("", Vector) = (1, 1, 1, 0)
[HideInInspector]					                                _AdvancedDissolveEdgeAdditionalColorMapOffset("", Vector) = (0, 0, 0, 0)
[HideInInspector]					                                _AdvancedDissolveEdgeAdditionalColorMapScroll("", Vector) = (0, 0, 0, 0)
[HideInInspector][AdvancedDissolveToggleFloat]				        _AdvancedDissolveEdgeAdditionalColorMapReverse("", FLOAT) = 0
[HideInInspector]											        _AdvancedDissolveEdgeAdditionalColorMapMipmap("", Range(0, 10)) = 1	
[HideInInspector]											        _AdvancedDissolveEdgeAdditionalColorPhaseOffset("", FLOAT) = 0
[HideInInspector]											        _AdvancedDissolveEdgeAdditionalColorAlphaOffset("", Range(-1, 1)) = 0	
[HideInInspector][AdvancedDissolveToggleFloat]				        _AdvancedDissolveEdgeAdditionalColorClipInterpolation("", Float) = 0


[HideInInspector]								                    _AdvancedDissolveEdgeUVDistortionMap("", 2D) = "black" { }
[HideInInspector]					                                _AdvancedDissolveEdgeUVDistortionMapTiling("", Vector) = (1, 1, 1, 0)
[HideInInspector]					                                _AdvancedDissolveEdgeUVDistortionMapOffset("", Vector) = (0, 0, 0, 0)
[HideInInspector]					                                _AdvancedDissolveEdgeUVDistortionMapScroll("", Vector) = (0, 0, 0, 0)
[HideInInspector]				                                    _AdvancedDissolveEdgeUVDistortionStrength("", Float) = 0

[HideInInspector][AdvancedDissolvePositiveFloat]			        _AdvancedDissolveEdgeGIMetaPassMultiplier("", Float) = 1

//Keywords
[HideInInspector][AdvancedDissolveKeywordState]                     _AdvancedDissolveKeywordState("", INT) = 0
[HideInInspector][AdvancedDissolveKeywordCutoutStandardSource]      _AdvancedDissolveKeywordCutoutStandardSource("", INT) = 0
[HideInInspector][AdvancedDissolveKeywordCutoutStandardMappingType] _AdvancedDissolveKeywordCutoutStandardSourceMapsMappingType("", INT) = 0
[HideInInspector][AdvancedDissolveKeywordCutoutGeometricType]       _AdvancedDissolveKeywordCutoutGeometricType("", INT) = 0
[HideInInspector][AdvancedDissolveKeywordCutoutGeometricCount]      _AdvancedDissolveKeywordCutoutGeometricCount("", INT) = 0
[HideInInspector][AdvancedDissolveKeywordEdgeBaseSource]            _AdvancedDissolveKeywordEdgeBaseSource("", INT) = 0
[HideInInspector][AdvancedDissolveKeywordEdgeAdditionalColorSource] _AdvancedDissolveKeywordEdgeAdditionalColorSource("", INT) = 0
[HideInInspector][AdvancedDissolveKeywordEdgeUVDistortionSource]    _AdvancedDissolveKeywordEdgeUVDistortionSource("", INT) = 0
[HideInInspector][AdvancedDissolveKeywordGlobalControlID]           _AdvancedDissolveKeywordGlobalControlID("", INT) = 0

//BakedKeywords
[HideInInspector]                                                   _AdvancedDissolveBakedKeywords("", Vector) = (0,0,0,0)	

//Advanced Dissolve Properties End////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        _BaseColor("Base Color", Color) = (1, 1, 1, 1)
        [NoScaleOffset]_BaseColorMap("Base Map", 2D) = "white" {}
        _EmissiveColor("Emission Color", Color) = (0, 0, 0, 0)
        _EmissiveIntensity("Emission Intensity", Float) = 0
        _EmissiveExposureWeight("Emission Exposure Weight", Range(0, 1)) = 1
        [NoScaleOffset]_EmissiveColorMap("Emission Map", 2D) = "black" {}
    }
    SubShader
    {
        Tags
    {
        "RenderPipeline"="HDRenderPipeline"
        "RenderType"="HDUnlitShader"
        "Queue" = "AlphaTest+0"
    }

        Pass
    {
        // based on UnlitPass.template
        Name "ShadowCaster"
        Tags { "LightMode" = "ShadowCaster" }

        //-------------------------------------------------------------------------------------
        // Render Modes (Blend, Cull, ZTest, Stencil, etc)
        //-------------------------------------------------------------------------------------
        
        Cull Off

        
        ZWrite On

        
        ColorMask 0

        //-------------------------------------------------------------------------------------
        // End Render Modes
        //-------------------------------------------------------------------------------------

        HLSLPROGRAM

        #pragma target 4.5
        #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
        //#pragma enable_d3d11_debug_symbols

        //enable GPU instancing support
        #pragma multi_compile_instancing

        //-------------------------------------------------------------------------------------
        // Variant Definitions (active field translations to HDRP defines)
        //-------------------------------------------------------------------------------------
        // #define _SURFACE_TYPE_TRANSPARENT 1
        // #define _BLENDMODE_ALPHA 1
        // #define _BLENDMODE_ADD 1
        // #define _BLENDMODE_PRE_MULTIPLY 1
        // #define _ADD_PRECOMPUTED_VELOCITY

        //-------------------------------------------------------------------------------------
        // End Variant Definitions
        //-------------------------------------------------------------------------------------

        #pragma vertex Vert
        #pragma fragment Frag

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"

        //-------------------------------------------------------------------------------------
        // Defines
        //-------------------------------------------------------------------------------------
                // Shared Graph Keywords
                #define SHADERPASS SHADERPASS_SHADOWS
                // ACTIVE FIELDS:
                //   AlphaTest
                //   SurfaceDescriptionInputs.ObjectSpaceNormal
                //   SurfaceDescriptionInputs.WorldSpaceNormal
                //   SurfaceDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescriptionInputs.WorldSpacePosition
                //   SurfaceDescriptionInputs.AbsoluteWorldSpacePosition
                //   SurfaceDescriptionInputs.uv0
                //   VertexDescriptionInputs.ObjectSpaceNormal
                //   VertexDescriptionInputs.ObjectSpaceTangent
                //   VertexDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescription.Alpha
                //   SurfaceDescription.AlphaClipThreshold
                //   FragInputs.tangentToWorld
                //   FragInputs.positionRWS
                //   FragInputs.texCoord0
                //   AttributesMesh.normalOS
                //   AttributesMesh.tangentOS
                //   AttributesMesh.positionOS
                //   VaryingsMeshToPS.tangentWS
                //   VaryingsMeshToPS.normalWS
                //   VaryingsMeshToPS.positionRWS
                //   VaryingsMeshToPS.texCoord0
                //   AttributesMesh.uv0

        // this translates the new dependency tracker into the old preprocessor definitions for the existing HDRP shader code
        #define ATTRIBUTES_NEED_NORMAL
        #define ATTRIBUTES_NEED_TANGENT
        #define ATTRIBUTES_NEED_TEXCOORD0
        // #define ATTRIBUTES_NEED_TEXCOORD1
        // #define ATTRIBUTES_NEED_TEXCOORD2
        // #define ATTRIBUTES_NEED_TEXCOORD3
        // #define ATTRIBUTES_NEED_COLOR
        #define VARYINGS_NEED_POSITION_WS
        #define VARYINGS_NEED_TANGENT_TO_WORLD
        #define VARYINGS_NEED_TEXCOORD0
        // #define VARYINGS_NEED_TEXCOORD1
        // #define VARYINGS_NEED_TEXCOORD2
        // #define VARYINGS_NEED_TEXCOORD3
        // #define VARYINGS_NEED_COLOR
        // #define VARYINGS_NEED_CULLFACE
        // #define HAVE_MESH_MODIFICATION

        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------
    	

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"

        // Used by SceneSelectionPass
        int _ObjectId;
        int _PassValue;

        //-------------------------------------------------------------------------------------
        // Interpolator Packing And Struct Declarations
        //-------------------------------------------------------------------------------------
        // Generated Type: AttributesMesh
            struct AttributesMesh
            {
                float3 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
                float4 uv0 : TEXCOORD0; // optional
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : INSTANCEID_SEMANTIC;
                #endif // UNITY_ANY_INSTANCING_ENABLED
            };
        // Generated Type: VaryingsMeshToPS
            struct VaryingsMeshToPS
            {
                float4 positionCS : SV_POSITION;
                float3 positionRWS; // optional
                float3 normalWS; // optional
                float4 tangentWS; // optional
                float4 texCoord0; // optional
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif // UNITY_ANY_INSTANCING_ENABLED
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                #endif // defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            };
            
            // Generated Type: PackedVaryingsMeshToPS
            struct PackedVaryingsMeshToPS
            {
                float4 positionCS : SV_POSITION; // unpacked
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID; // unpacked
                #endif // conditional
                float3 interp00 : TEXCOORD0; // auto-packed
                float3 interp01 : TEXCOORD1; // auto-packed
                float4 interp02 : TEXCOORD2; // auto-packed
                float4 interp03 : TEXCOORD3; // auto-packed
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC; // unpacked
                #endif // conditional
            };
            
            // Packed Type: VaryingsMeshToPS
            PackedVaryingsMeshToPS PackVaryingsMeshToPS(VaryingsMeshToPS input)
            {
                PackedVaryingsMeshToPS output = (PackedVaryingsMeshToPS)0;
                output.positionCS = input.positionCS;
                output.interp00.xyz = input.positionRWS;
                output.interp01.xyz = input.normalWS;
                output.interp02.xyzw = input.tangentWS;
                output.interp03.xyzw = input.texCoord0;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif // conditional
                return output;
            }
            
            // Unpacked Type: VaryingsMeshToPS
            VaryingsMeshToPS UnpackVaryingsMeshToPS(PackedVaryingsMeshToPS input)
            {
                VaryingsMeshToPS output = (VaryingsMeshToPS)0;
                output.positionCS = input.positionCS;
                output.positionRWS = input.interp00.xyz;
                output.normalWS = input.interp01.xyz;
                output.tangentWS = input.interp02.xyzw;
                output.texCoord0 = input.interp03.xyzw;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif // conditional
                return output;
            }
        // Generated Type: VaryingsMeshToDS
            struct VaryingsMeshToDS
            {
                float3 positionRWS;
                float3 normalWS;
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif // UNITY_ANY_INSTANCING_ENABLED
            };
            
            // Generated Type: PackedVaryingsMeshToDS
            struct PackedVaryingsMeshToDS
            {
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID; // unpacked
                #endif // conditional
                float3 interp00 : TEXCOORD0; // auto-packed
                float3 interp01 : TEXCOORD1; // auto-packed
            };
            
            // Packed Type: VaryingsMeshToDS
            PackedVaryingsMeshToDS PackVaryingsMeshToDS(VaryingsMeshToDS input)
            {
                PackedVaryingsMeshToDS output = (PackedVaryingsMeshToDS)0;
                output.interp00.xyz = input.positionRWS;
                output.interp01.xyz = input.normalWS;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                return output;
            }
            
            // Unpacked Type: VaryingsMeshToDS
            VaryingsMeshToDS UnpackVaryingsMeshToDS(PackedVaryingsMeshToDS input)
            {
                VaryingsMeshToDS output = (VaryingsMeshToDS)0;
                output.positionRWS = input.interp00.xyz;
                output.normalWS = input.interp01.xyz;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                return output;
            }
        //-------------------------------------------------------------------------------------
        // End Interpolator Packing And Struct Declarations
        //-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------
        // Graph generated code
        //-------------------------------------------------------------------------------------
                // Shared Graph Properties (uniform inputs)


//Advanced Dissolve Keywords Start///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#pragma shader_feature_local   _AD_STATE_ENABLED
#pragma shader_feature_local _ _AD_CUTOUT_STANDARD_SOURCE_BASE_ALPHA				  _AD_CUTOUT_STANDARD_SOURCE_CUSTOM_MAP                     _AD_CUTOUT_STANDARD_SOURCE_TWO_CUSTOM_MAPS _AD_CUTOUT_STANDARD_SOURCE_THREE_CUSTOM_MAPS _AD_CUTOUT_STANDARD_SOURCE_USER_DEFINED
#pragma shader_feature_local _ _AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_TRIPLANAR _AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_SCREEN_SPACE
#pragma shader_feature_local _ _AD_CUTOUT_GEOMETRIC_TYPE_XYZ						  _AD_CUTOUT_GEOMETRIC_TYPE_PLANE                           _AD_CUTOUT_GEOMETRIC_TYPE_SPHERE           _AD_CUTOUT_GEOMETRIC_TYPE_CUBE               _AD_CUTOUT_GEOMETRIC_TYPE_CAPSULE       _AD_CUTOUT_GEOMETRIC_TYPE_CONE_SMOOTH
#pragma shader_feature_local _ _AD_CUTOUT_GEOMETRIC_COUNT_TWO					      _AD_CUTOUT_GEOMETRIC_COUNT_THREE                          _AD_CUTOUT_GEOMETRIC_COUNT_FOUR
#pragma shader_feature_local _ _AD_EDGE_BASE_SOURCE_CUTOUT_STANDARD                   _AD_EDGE_BASE_SOURCE_CUTOUT_GEOMETRIC                     _AD_EDGE_BASE_SOURCE_ALL
#pragma shader_feature_local _ _AD_EDGE_ADDITIONAL_COLOR_BASE_COLOR                   _AD_EDGE_ADDITIONAL_COLOR_CUSTOM_MAP                      _AD_EDGE_ADDITIONAL_COLOR_GRADIENT_MAP     _AD_EDGE_ADDITIONAL_COLOR_GRADIENT_COLOR     _AD_EDGE_ADDITIONAL_COLOR_USER_DEFINED
#pragma shader_feature_local _ _AD_GLOBAL_CONTROL_ID_ONE                              _AD_GLOBAL_CONTROL_ID_TWO                                 _AD_GLOBAL_CONTROL_ID_THREE                _AD_GLOBAL_CONTROL_ID_FOUR
//Advanced Dissolve Keywords End/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


#define ADVANCED_DISSOLVE_SHADER_GRAPH
#define ADVANCED_DISSOLVE_HIGH_DEFINITION_RENDER_PIPELINE
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Defines.cginc"
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                    CBUFFER_START(UnityPerMaterial)
        float4 _BaseColor;
        float4 _EmissiveColor;
        float _EmissiveIntensity;
        float _EmissiveExposureWeight;
        CBUFFER_END
        TEXTURE2D(_BaseColorMap); SAMPLER(sampler_BaseColorMap); float4 _BaseColorMap_TexelSize;
        TEXTURE2D(_EmissiveColorMap); SAMPLER(sampler_EmissiveColorMap); float4 _EmissiveColorMap_TexelSize;
        SAMPLER(_SampleTexture2D_9AB23BAE_Sampler_3_Linear_Repeat);

                // Pixel Graph Inputs
                    struct SurfaceDescriptionInputs
                    {
                        float3 ObjectSpaceNormal; // optional
                        float3 WorldSpaceNormal; // optional
                        float3 ObjectSpacePosition; // optional
                        float3 WorldSpacePosition; // optional
                        float3 AbsoluteWorldSpacePosition; // optional
                        float4 uv0; // optional
                    };
                // Pixel Graph Outputs
                    struct SurfaceDescription
    {
        float Alpha;
        float AlphaClipThreshold;
    };

                // Shared Graph Node Functions
                
        void AdvancedDissolveShaderGraphFunction_float(float2 UV, float3 PositionOS, float3 PositionWS, float3 PositionWSAbsolute, float3 NormalOS, float3 NormalWS, float CustomCutout, float4 CustomColor, out float Value)
        {
            Value = 0;
        }

        struct Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab
        {
            float3 ObjectSpaceNormal;
            float3 WorldSpaceNormal;
            float3 ObjectSpacePosition;
            float3 WorldSpacePosition;
            float3 AbsoluteWorldSpacePosition;
            half4 uv0;
        };

        void SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(float Vector1_9E44E7D0, float4 Color_9C152E30, Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab IN, out float Out_3)
        {
            float4 _UV_B7DC59D1_Out_0 = IN.uv0;
            float _Property_AA10DA06_Out_0 = Vector1_9E44E7D0;
            float4 _Property_D5854A9E_Out_0 = Color_9C152E30;
            float _CustomFunction_7278F8D6_Value_7;
            AdvancedDissolveShaderGraphFunction_float((_UV_B7DC59D1_Out_0.xy), IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, _Property_AA10DA06_Out_0, _Property_D5854A9E_Out_0, _CustomFunction_7278F8D6_Value_7);
            Out_3 = _CustomFunction_7278F8D6_Value_7;
        }

                // Pixel Graph Evaluation


//Advanced Dissolve
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Core.cginc"


                    SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float4 _SampleTexture2D_9AB23BAE_RGBA_0 = SAMPLE_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, IN.uv0.xy);
        float _SampleTexture2D_9AB23BAE_R_4 = _SampleTexture2D_9AB23BAE_RGBA_0.r;
        float _SampleTexture2D_9AB23BAE_G_5 = _SampleTexture2D_9AB23BAE_RGBA_0.g;
        float _SampleTexture2D_9AB23BAE_B_6 = _SampleTexture2D_9AB23BAE_RGBA_0.b;
        float _SampleTexture2D_9AB23BAE_A_7 = _SampleTexture2D_9AB23BAE_RGBA_0.a;
        float _Split_609E0B65_R_1 = _SampleTexture2D_9AB23BAE_RGBA_0[0];
        float _Split_609E0B65_G_2 = _SampleTexture2D_9AB23BAE_RGBA_0[1];
        float _Split_609E0B65_B_3 = _SampleTexture2D_9AB23BAE_RGBA_0[2];
        float _Split_609E0B65_A_4 = _SampleTexture2D_9AB23BAE_RGBA_0[3];
        Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab _AdvancedDissolve_B8B8503F;
        _AdvancedDissolve_B8B8503F.ObjectSpaceNormal = IN.ObjectSpaceNormal;
        _AdvancedDissolve_B8B8503F.WorldSpaceNormal = IN.WorldSpaceNormal;
        _AdvancedDissolve_B8B8503F.ObjectSpacePosition = IN.ObjectSpacePosition;
        _AdvancedDissolve_B8B8503F.WorldSpacePosition = IN.WorldSpacePosition;
        _AdvancedDissolve_B8B8503F.AbsoluteWorldSpacePosition = IN.AbsoluteWorldSpacePosition;
        _AdvancedDissolve_B8B8503F.uv0 = IN.uv0;
        float _AdvancedDissolve_B8B8503F_Out_3;
        SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(0, float4 (0, 0, 0, 1), _AdvancedDissolve_B8B8503F, _AdvancedDissolve_B8B8503F_Out_3);
        surface.Alpha = _Split_609E0B65_A_4;
        surface.AlphaClipThreshold = _AdvancedDissolve_B8B8503F_Out_3;


//ShadowCaster
AdvancedDissolveShaderGraph(IN.uv0.xy, IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, 0, 1, surface.Alpha, surface.AlphaClipThreshold);


return surface;

    }

        //-------------------------------------------------------------------------------------
        // End graph generated code
        //-------------------------------------------------------------------------------------

    // $include("VertexAnimation.template.hlsl")

    //-------------------------------------------------------------------------------------
    // TEMPLATE INCLUDE : SharedCode.template.hlsl
    //-------------------------------------------------------------------------------------

    #if !defined(SHADER_STAGE_RAY_TRACING)
        FragInputs BuildFragInputs(VaryingsMeshToPS input)
        {
            FragInputs output;
            ZERO_INITIALIZE(FragInputs, output);

            // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
            // TODO: this is a really poor workaround, but the variable is used in a bunch of places
            // to compute normals which are then passed on elsewhere to compute other values...
            output.tangentToWorld = k_identity3x3;
            output.positionSS = input.positionCS;       // input.positionCS is SV_Position

            output.positionRWS = input.positionRWS;
            output.tangentToWorld = BuildTangentToWorld(input.tangentWS, input.normalWS);
            output.texCoord0 = input.texCoord0;
            // output.texCoord1 = input.texCoord1;
            // output.texCoord2 = input.texCoord2;
            // output.texCoord3 = input.texCoord3;
            // output.color = input.color;
            #if _DOUBLESIDED_ON && SHADER_STAGE_FRAGMENT
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #elif SHADER_STAGE_FRAGMENT
            // output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #endif // SHADER_STAGE_FRAGMENT

            return output;
        }
    #endif
        SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
        {
            SurfaceDescriptionInputs output;
            ZERO_INITIALIZE(SurfaceDescriptionInputs, output);

            output.WorldSpaceNormal =            input.tangentToWorld[2].xyz;	// normal was already normalized in BuildTangentToWorld()
            output.ObjectSpaceNormal =           normalize(mul(output.WorldSpaceNormal, (float3x3) UNITY_MATRIX_M));           // transposed multiplication by inverse matrix to handle normal scale
            // output.ViewSpaceNormal =             mul(output.WorldSpaceNormal, (float3x3) UNITY_MATRIX_I_V);         // transposed multiplication by inverse matrix to handle normal scale
            // output.TangentSpaceNormal =          float3(0.0f, 0.0f, 1.0f);
            // output.WorldSpaceTangent =           input.tangentToWorld[0].xyz;
            // output.ObjectSpaceTangent =          TransformWorldToObjectDir(output.WorldSpaceTangent);
            // output.ViewSpaceTangent =            TransformWorldToViewDir(output.WorldSpaceTangent);
            // output.TangentSpaceTangent =         float3(1.0f, 0.0f, 0.0f);
            // output.WorldSpaceBiTangent =         input.tangentToWorld[1].xyz;
            // output.ObjectSpaceBiTangent =        TransformWorldToObjectDir(output.WorldSpaceBiTangent);
            // output.ViewSpaceBiTangent =          TransformWorldToViewDir(output.WorldSpaceBiTangent);
            // output.TangentSpaceBiTangent =       float3(0.0f, 1.0f, 0.0f);
            // output.WorldSpaceViewDirection =     normalize(viewWS);
            // output.ObjectSpaceViewDirection =    TransformWorldToObjectDir(output.WorldSpaceViewDirection);
            // output.ViewSpaceViewDirection =      TransformWorldToViewDir(output.WorldSpaceViewDirection);
            // float3x3 tangentSpaceTransform =     float3x3(output.WorldSpaceTangent,output.WorldSpaceBiTangent,output.WorldSpaceNormal);
            // output.TangentSpaceViewDirection =   mul(tangentSpaceTransform, output.WorldSpaceViewDirection);
            output.WorldSpacePosition =          input.positionRWS;
            output.ObjectSpacePosition =         TransformWorldToObject(input.positionRWS);
            // output.ViewSpacePosition =           TransformWorldToView(input.positionRWS);
            // output.TangentSpacePosition =        float3(0.0f, 0.0f, 0.0f);
            output.AbsoluteWorldSpacePosition =  GetAbsolutePositionWS(input.positionRWS);
            // output.ScreenPosition =              ComputeScreenPos(TransformWorldToHClip(input.positionRWS), _ProjectionParams.x);
            output.uv0 =                         input.texCoord0;
            // output.uv1 =                         input.texCoord1;
            // output.uv2 =                         input.texCoord2;
            // output.uv3 =                         input.texCoord3;
            // output.VertexColor =                 input.color;
            // output.FaceSign =                    input.isFrontFace;
            // output.TimeParameters =              _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value

            return output;
        }

    #if !defined(SHADER_STAGE_RAY_TRACING)

        // existing HDRP code uses the combined function to go directly from packed to frag inputs
        FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
        {
            UNITY_SETUP_INSTANCE_ID(input);
            VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
            return BuildFragInputs(unpacked);
        }
    #endif

    //-------------------------------------------------------------------------------------
    // END TEMPLATE INCLUDE : SharedCode.template.hlsl
    //-------------------------------------------------------------------------------------


        void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
        {
            // setup defaults -- these are used if the graph doesn't output a value
            ZERO_INITIALIZE(SurfaceData, surfaceData);

            // copy across graph values, if defined
            // surfaceData.color = surfaceDescription.Color;

    #if defined(DEBUG_DISPLAY)
            if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
            {
                // TODO
            }
    #endif
        }

        void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData)
        {
            SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
            SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);

            // Perform alpha test very early to save performance (a killed pixel will not sample textures)
            // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
            DoAlphaTest(surfaceDescription.Alpha, surfaceDescription.AlphaClipThreshold);

            BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);

            // Builtin Data
            ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
            builtinData.opacity = surfaceDescription.Alpha;
        }

        //-------------------------------------------------------------------------------------
        // Pass Includes
        //-------------------------------------------------------------------------------------
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassDepthOnly.hlsl"
        //-------------------------------------------------------------------------------------
        // End Pass Includes
        //-------------------------------------------------------------------------------------

        ENDHLSL
    }

        Pass
    {
        // based on UnlitPass.template
        Name "META"
        Tags { "LightMode" = "META" }

        //-------------------------------------------------------------------------------------
        // Render Modes (Blend, Cull, ZTest, Stencil, etc)
        //-------------------------------------------------------------------------------------
        
        Cull Off

        
        
        
        
        //-------------------------------------------------------------------------------------
        // End Render Modes
        //-------------------------------------------------------------------------------------

        HLSLPROGRAM

        #pragma target 4.5
        #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
        //#pragma enable_d3d11_debug_symbols

        //enable GPU instancing support
        #pragma multi_compile_instancing

        //-------------------------------------------------------------------------------------
        // Variant Definitions (active field translations to HDRP defines)
        //-------------------------------------------------------------------------------------
        // #define _SURFACE_TYPE_TRANSPARENT 1
        // #define _BLENDMODE_ALPHA 1
        // #define _BLENDMODE_ADD 1
        // #define _BLENDMODE_PRE_MULTIPLY 1
        // #define _ADD_PRECOMPUTED_VELOCITY

        //-------------------------------------------------------------------------------------
        // End Variant Definitions
        //-------------------------------------------------------------------------------------

        #pragma vertex Vert
        #pragma fragment Frag

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"

        //-------------------------------------------------------------------------------------
        // Defines
        //-------------------------------------------------------------------------------------
                // Shared Graph Keywords
                #define SHADERPASS SHADERPASS_LIGHT_TRANSPORT
                // ACTIVE FIELDS:
                //   AlphaTest
                //   SurfaceDescriptionInputs.ObjectSpaceNormal
                //   SurfaceDescriptionInputs.WorldSpaceNormal
                //   SurfaceDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescriptionInputs.WorldSpacePosition
                //   SurfaceDescriptionInputs.AbsoluteWorldSpacePosition
                //   SurfaceDescriptionInputs.uv0
                //   VertexDescriptionInputs.ObjectSpaceNormal
                //   VertexDescriptionInputs.ObjectSpaceTangent
                //   VertexDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescription.Color
                //   SurfaceDescription.Alpha
                //   SurfaceDescription.AlphaClipThreshold
                //   AttributesMesh.normalOS
                //   AttributesMesh.tangentOS
                //   AttributesMesh.uv0
                //   AttributesMesh.uv1
                //   AttributesMesh.color
                //   AttributesMesh.uv2
                //   FragInputs.tangentToWorld
                //   FragInputs.positionRWS
                //   FragInputs.texCoord0
                //   AttributesMesh.positionOS
                //   VaryingsMeshToPS.tangentWS
                //   VaryingsMeshToPS.normalWS
                //   VaryingsMeshToPS.positionRWS
                //   VaryingsMeshToPS.texCoord0

        // this translates the new dependency tracker into the old preprocessor definitions for the existing HDRP shader code
        #define ATTRIBUTES_NEED_NORMAL
        #define ATTRIBUTES_NEED_TANGENT
        #define ATTRIBUTES_NEED_TEXCOORD0
        #define ATTRIBUTES_NEED_TEXCOORD1
        #define ATTRIBUTES_NEED_TEXCOORD2
        // #define ATTRIBUTES_NEED_TEXCOORD3
        #define ATTRIBUTES_NEED_COLOR
        #define VARYINGS_NEED_POSITION_WS
        #define VARYINGS_NEED_TANGENT_TO_WORLD
        #define VARYINGS_NEED_TEXCOORD0
        // #define VARYINGS_NEED_TEXCOORD1
        // #define VARYINGS_NEED_TEXCOORD2
        // #define VARYINGS_NEED_TEXCOORD3
        // #define VARYINGS_NEED_COLOR
        // #define VARYINGS_NEED_CULLFACE
        // #define HAVE_MESH_MODIFICATION

        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------
    	

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"

        // Used by SceneSelectionPass
        int _ObjectId;
        int _PassValue;

        //-------------------------------------------------------------------------------------
        // Interpolator Packing And Struct Declarations
        //-------------------------------------------------------------------------------------
        // Generated Type: AttributesMesh
            struct AttributesMesh
            {
                float3 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
                float4 uv0 : TEXCOORD0; // optional
                float4 uv1 : TEXCOORD1; // optional
                float4 uv2 : TEXCOORD2; // optional
                float4 color : COLOR; // optional
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : INSTANCEID_SEMANTIC;
                #endif // UNITY_ANY_INSTANCING_ENABLED
            };
        // Generated Type: VaryingsMeshToPS
            struct VaryingsMeshToPS
            {
                float4 positionCS : SV_POSITION;
                float3 positionRWS; // optional
                float3 normalWS; // optional
                float4 tangentWS; // optional
                float4 texCoord0; // optional
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif // UNITY_ANY_INSTANCING_ENABLED
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                #endif // defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            };
            
            // Generated Type: PackedVaryingsMeshToPS
            struct PackedVaryingsMeshToPS
            {
                float4 positionCS : SV_POSITION; // unpacked
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID; // unpacked
                #endif // conditional
                float3 interp00 : TEXCOORD0; // auto-packed
                float3 interp01 : TEXCOORD1; // auto-packed
                float4 interp02 : TEXCOORD2; // auto-packed
                float4 interp03 : TEXCOORD3; // auto-packed
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC; // unpacked
                #endif // conditional
            };
            
            // Packed Type: VaryingsMeshToPS
            PackedVaryingsMeshToPS PackVaryingsMeshToPS(VaryingsMeshToPS input)
            {
                PackedVaryingsMeshToPS output = (PackedVaryingsMeshToPS)0;
                output.positionCS = input.positionCS;
                output.interp00.xyz = input.positionRWS;
                output.interp01.xyz = input.normalWS;
                output.interp02.xyzw = input.tangentWS;
                output.interp03.xyzw = input.texCoord0;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif // conditional
                return output;
            }
            
            // Unpacked Type: VaryingsMeshToPS
            VaryingsMeshToPS UnpackVaryingsMeshToPS(PackedVaryingsMeshToPS input)
            {
                VaryingsMeshToPS output = (VaryingsMeshToPS)0;
                output.positionCS = input.positionCS;
                output.positionRWS = input.interp00.xyz;
                output.normalWS = input.interp01.xyz;
                output.tangentWS = input.interp02.xyzw;
                output.texCoord0 = input.interp03.xyzw;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif // conditional
                return output;
            }
        // Generated Type: VaryingsMeshToDS
            struct VaryingsMeshToDS
            {
                float3 positionRWS;
                float3 normalWS;
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif // UNITY_ANY_INSTANCING_ENABLED
            };
            
            // Generated Type: PackedVaryingsMeshToDS
            struct PackedVaryingsMeshToDS
            {
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID; // unpacked
                #endif // conditional
                float3 interp00 : TEXCOORD0; // auto-packed
                float3 interp01 : TEXCOORD1; // auto-packed
            };
            
            // Packed Type: VaryingsMeshToDS
            PackedVaryingsMeshToDS PackVaryingsMeshToDS(VaryingsMeshToDS input)
            {
                PackedVaryingsMeshToDS output = (PackedVaryingsMeshToDS)0;
                output.interp00.xyz = input.positionRWS;
                output.interp01.xyz = input.normalWS;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                return output;
            }
            
            // Unpacked Type: VaryingsMeshToDS
            VaryingsMeshToDS UnpackVaryingsMeshToDS(PackedVaryingsMeshToDS input)
            {
                VaryingsMeshToDS output = (VaryingsMeshToDS)0;
                output.positionRWS = input.interp00.xyz;
                output.normalWS = input.interp01.xyz;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                return output;
            }
        //-------------------------------------------------------------------------------------
        // End Interpolator Packing And Struct Declarations
        //-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------
        // Graph generated code
        //-------------------------------------------------------------------------------------
                // Shared Graph Properties (uniform inputs)


//Advanced Dissolve Keywords Start///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#pragma shader_feature_local   _AD_STATE_ENABLED
#pragma shader_feature_local _ _AD_CUTOUT_STANDARD_SOURCE_BASE_ALPHA				  _AD_CUTOUT_STANDARD_SOURCE_CUSTOM_MAP                     _AD_CUTOUT_STANDARD_SOURCE_TWO_CUSTOM_MAPS _AD_CUTOUT_STANDARD_SOURCE_THREE_CUSTOM_MAPS _AD_CUTOUT_STANDARD_SOURCE_USER_DEFINED
#pragma shader_feature_local _ _AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_TRIPLANAR _AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_SCREEN_SPACE
#pragma shader_feature_local _ _AD_CUTOUT_GEOMETRIC_TYPE_XYZ						  _AD_CUTOUT_GEOMETRIC_TYPE_PLANE                           _AD_CUTOUT_GEOMETRIC_TYPE_SPHERE           _AD_CUTOUT_GEOMETRIC_TYPE_CUBE               _AD_CUTOUT_GEOMETRIC_TYPE_CAPSULE       _AD_CUTOUT_GEOMETRIC_TYPE_CONE_SMOOTH
#pragma shader_feature_local _ _AD_CUTOUT_GEOMETRIC_COUNT_TWO					      _AD_CUTOUT_GEOMETRIC_COUNT_THREE                          _AD_CUTOUT_GEOMETRIC_COUNT_FOUR
#pragma shader_feature_local _ _AD_EDGE_BASE_SOURCE_CUTOUT_STANDARD                   _AD_EDGE_BASE_SOURCE_CUTOUT_GEOMETRIC                     _AD_EDGE_BASE_SOURCE_ALL
#pragma shader_feature_local _ _AD_EDGE_ADDITIONAL_COLOR_BASE_COLOR                   _AD_EDGE_ADDITIONAL_COLOR_CUSTOM_MAP                      _AD_EDGE_ADDITIONAL_COLOR_GRADIENT_MAP     _AD_EDGE_ADDITIONAL_COLOR_GRADIENT_COLOR     _AD_EDGE_ADDITIONAL_COLOR_USER_DEFINED
#pragma shader_feature_local _ _AD_GLOBAL_CONTROL_ID_ONE                              _AD_GLOBAL_CONTROL_ID_TWO                                 _AD_GLOBAL_CONTROL_ID_THREE                _AD_GLOBAL_CONTROL_ID_FOUR
//Advanced Dissolve Keywords End/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


#define ADVANCED_DISSOLVE_SHADER_GRAPH
#define ADVANCED_DISSOLVE_META_PASS
#define ADVANCED_DISSOLVE_HIGH_DEFINITION_RENDER_PIPELINE
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Defines.cginc"
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                    CBUFFER_START(UnityPerMaterial)
        float4 _BaseColor;
        float4 _EmissiveColor;
        float _EmissiveIntensity;
        float _EmissiveExposureWeight;
        CBUFFER_END
        TEXTURE2D(_BaseColorMap); SAMPLER(sampler_BaseColorMap); float4 _BaseColorMap_TexelSize;
        TEXTURE2D(_EmissiveColorMap); SAMPLER(sampler_EmissiveColorMap); float4 _EmissiveColorMap_TexelSize;
        SAMPLER(_SampleTexture2D_9AB23BAE_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_5557C033_Sampler_3_Linear_Repeat);

                // Pixel Graph Inputs
                    struct SurfaceDescriptionInputs
                    {
                        float3 ObjectSpaceNormal; // optional
                        float3 WorldSpaceNormal; // optional
                        float3 ObjectSpacePosition; // optional
                        float3 WorldSpacePosition; // optional
                        float3 AbsoluteWorldSpacePosition; // optional
                        float4 uv0; // optional
                    };
                // Pixel Graph Outputs
                    struct SurfaceDescription
    {
        float3 Color;
        float Alpha;
        float AlphaClipThreshold;
    };

                // Shared Graph Node Functions
                
        void Unity_Multiply_float(float4 A, float4 B, out float4 Out)
        {
            Out = A * B;
        }

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/CommonLighting.hlsl"
        float3 Unity_HDRP_GetEmissionHDRColor_float(float3 ldrColor, float luminanceIntensity, float exposureWeight, float inverseCurrentExposureMultiplier)
        {
            float3 hdrColor = ldrColor * luminanceIntensity;

            // Inverse pre-expose using _EmissiveExposureWeight weight
            hdrColor = lerp(hdrColor * inverseCurrentExposureMultiplier, hdrColor, exposureWeight);
            return hdrColor;
        }

        void Unity_Add_float3(float3 A, float3 B, out float3 Out)
        {
            Out = A + B;
        }

        void AdvancedDissolveShaderGraphFunction_float(float2 UV, float3 PositionOS, float3 PositionWS, float3 PositionWSAbsolute, float3 NormalOS, float3 NormalWS, float CustomCutout, float4 CustomColor, out float Value)
        {
            Value = 0;
        }

        struct Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab
        {
            float3 ObjectSpaceNormal;
            float3 WorldSpaceNormal;
            float3 ObjectSpacePosition;
            float3 WorldSpacePosition;
            float3 AbsoluteWorldSpacePosition;
            half4 uv0;
        };

        void SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(float Vector1_9E44E7D0, float4 Color_9C152E30, Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab IN, out float Out_3)
        {
            float4 _UV_B7DC59D1_Out_0 = IN.uv0;
            float _Property_AA10DA06_Out_0 = Vector1_9E44E7D0;
            float4 _Property_D5854A9E_Out_0 = Color_9C152E30;
            float _CustomFunction_7278F8D6_Value_7;
            AdvancedDissolveShaderGraphFunction_float((_UV_B7DC59D1_Out_0.xy), IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, _Property_AA10DA06_Out_0, _Property_D5854A9E_Out_0, _CustomFunction_7278F8D6_Value_7);
            Out_3 = _CustomFunction_7278F8D6_Value_7;
        }

                // Pixel Graph Evaluation


//Advanced Dissolve
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Core.cginc"


                    SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float4 _Property_F9A284E6_Out_0 = _BaseColor;
        float4 _SampleTexture2D_9AB23BAE_RGBA_0 = SAMPLE_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, IN.uv0.xy);
        float _SampleTexture2D_9AB23BAE_R_4 = _SampleTexture2D_9AB23BAE_RGBA_0.r;
        float _SampleTexture2D_9AB23BAE_G_5 = _SampleTexture2D_9AB23BAE_RGBA_0.g;
        float _SampleTexture2D_9AB23BAE_B_6 = _SampleTexture2D_9AB23BAE_RGBA_0.b;
        float _SampleTexture2D_9AB23BAE_A_7 = _SampleTexture2D_9AB23BAE_RGBA_0.a;
        float4 _Multiply_84D535AA_Out_2;
        Unity_Multiply_float(_Property_F9A284E6_Out_0, _SampleTexture2D_9AB23BAE_RGBA_0, _Multiply_84D535AA_Out_2);
        float4 _Property_B1BF0B23_Out_0 = _EmissiveColor;
        float4 _SampleTexture2D_5557C033_RGBA_0 = SAMPLE_TEXTURE2D(_EmissiveColorMap, sampler_EmissiveColorMap, IN.uv0.xy);
        float _SampleTexture2D_5557C033_R_4 = _SampleTexture2D_5557C033_RGBA_0.r;
        float _SampleTexture2D_5557C033_G_5 = _SampleTexture2D_5557C033_RGBA_0.g;
        float _SampleTexture2D_5557C033_B_6 = _SampleTexture2D_5557C033_RGBA_0.b;
        float _SampleTexture2D_5557C033_A_7 = _SampleTexture2D_5557C033_RGBA_0.a;
        float4 _Multiply_B1DF16FF_Out_2;
        Unity_Multiply_float(_Property_B1BF0B23_Out_0, _SampleTexture2D_5557C033_RGBA_0, _Multiply_B1DF16FF_Out_2);
        float _Property_61BFA42D_Out_0 = _EmissiveIntensity;
        float _Property_8A7F8B80_Out_0 = _EmissiveExposureWeight;
        #ifdef SHADERGRAPH_PREVIEW
        float inverseExposureMultiplier = 1.0;
        #else
        float inverseExposureMultiplier = GetInverseCurrentExposureMultiplier();
        #endif
        float3 _EmissionNode_FAEA9631_Output_0 = Unity_HDRP_GetEmissionHDRColor_float((_Multiply_B1DF16FF_Out_2.xyz).xyz, ConvertEvToLuminance(_Property_61BFA42D_Out_0), _Property_8A7F8B80_Out_0, inverseExposureMultiplier);
        float3 _Add_B5FD95AE_Out_2;
        Unity_Add_float3((_Multiply_84D535AA_Out_2.xyz), _EmissionNode_FAEA9631_Output_0, _Add_B5FD95AE_Out_2);
        float _Split_609E0B65_R_1 = _SampleTexture2D_9AB23BAE_RGBA_0[0];
        float _Split_609E0B65_G_2 = _SampleTexture2D_9AB23BAE_RGBA_0[1];
        float _Split_609E0B65_B_3 = _SampleTexture2D_9AB23BAE_RGBA_0[2];
        float _Split_609E0B65_A_4 = _SampleTexture2D_9AB23BAE_RGBA_0[3];
        Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab _AdvancedDissolve_B8B8503F;
        _AdvancedDissolve_B8B8503F.ObjectSpaceNormal = IN.ObjectSpaceNormal;
        _AdvancedDissolve_B8B8503F.WorldSpaceNormal = IN.WorldSpaceNormal;
        _AdvancedDissolve_B8B8503F.ObjectSpacePosition = IN.ObjectSpacePosition;
        _AdvancedDissolve_B8B8503F.WorldSpacePosition = IN.WorldSpacePosition;
        _AdvancedDissolve_B8B8503F.AbsoluteWorldSpacePosition = IN.AbsoluteWorldSpacePosition;
        _AdvancedDissolve_B8B8503F.uv0 = IN.uv0;
        float _AdvancedDissolve_B8B8503F_Out_3;
        SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(0, float4 (0, 0, 0, 1), _AdvancedDissolve_B8B8503F, _AdvancedDissolve_B8B8503F_Out_3);
        surface.Color = _Add_B5FD95AE_Out_2;
        surface.Alpha = _Split_609E0B65_A_4;
        surface.AlphaClipThreshold = _AdvancedDissolve_B8B8503F_Out_3;


//Unknown
AdvancedDissolveShaderGraph(IN.uv0.xy, IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, 0, 1, surface.Color, surface.Alpha, surface.AlphaClipThreshold);


return surface;

    }

        //-------------------------------------------------------------------------------------
        // End graph generated code
        //-------------------------------------------------------------------------------------

    // $include("VertexAnimation.template.hlsl")

    //-------------------------------------------------------------------------------------
    // TEMPLATE INCLUDE : SharedCode.template.hlsl
    //-------------------------------------------------------------------------------------

    #if !defined(SHADER_STAGE_RAY_TRACING)
        FragInputs BuildFragInputs(VaryingsMeshToPS input)
        {
            FragInputs output;
            ZERO_INITIALIZE(FragInputs, output);

            // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
            // TODO: this is a really poor workaround, but the variable is used in a bunch of places
            // to compute normals which are then passed on elsewhere to compute other values...
            output.tangentToWorld = k_identity3x3;
            output.positionSS = input.positionCS;       // input.positionCS is SV_Position

            output.positionRWS = input.positionRWS;
            output.tangentToWorld = BuildTangentToWorld(input.tangentWS, input.normalWS);
            output.texCoord0 = input.texCoord0;
            // output.texCoord1 = input.texCoord1;
            // output.texCoord2 = input.texCoord2;
            // output.texCoord3 = input.texCoord3;
            // output.color = input.color;
            #if _DOUBLESIDED_ON && SHADER_STAGE_FRAGMENT
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #elif SHADER_STAGE_FRAGMENT
            // output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #endif // SHADER_STAGE_FRAGMENT

            return output;
        }
    #endif
        SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
        {
            SurfaceDescriptionInputs output;
            ZERO_INITIALIZE(SurfaceDescriptionInputs, output);

            output.WorldSpaceNormal =            input.tangentToWorld[2].xyz;	// normal was already normalized in BuildTangentToWorld()
            output.ObjectSpaceNormal =           normalize(mul(output.WorldSpaceNormal, (float3x3) UNITY_MATRIX_M));           // transposed multiplication by inverse matrix to handle normal scale
            // output.ViewSpaceNormal =             mul(output.WorldSpaceNormal, (float3x3) UNITY_MATRIX_I_V);         // transposed multiplication by inverse matrix to handle normal scale
            // output.TangentSpaceNormal =          float3(0.0f, 0.0f, 1.0f);
            // output.WorldSpaceTangent =           input.tangentToWorld[0].xyz;
            // output.ObjectSpaceTangent =          TransformWorldToObjectDir(output.WorldSpaceTangent);
            // output.ViewSpaceTangent =            TransformWorldToViewDir(output.WorldSpaceTangent);
            // output.TangentSpaceTangent =         float3(1.0f, 0.0f, 0.0f);
            // output.WorldSpaceBiTangent =         input.tangentToWorld[1].xyz;
            // output.ObjectSpaceBiTangent =        TransformWorldToObjectDir(output.WorldSpaceBiTangent);
            // output.ViewSpaceBiTangent =          TransformWorldToViewDir(output.WorldSpaceBiTangent);
            // output.TangentSpaceBiTangent =       float3(0.0f, 1.0f, 0.0f);
            // output.WorldSpaceViewDirection =     normalize(viewWS);
            // output.ObjectSpaceViewDirection =    TransformWorldToObjectDir(output.WorldSpaceViewDirection);
            // output.ViewSpaceViewDirection =      TransformWorldToViewDir(output.WorldSpaceViewDirection);
            // float3x3 tangentSpaceTransform =     float3x3(output.WorldSpaceTangent,output.WorldSpaceBiTangent,output.WorldSpaceNormal);
            // output.TangentSpaceViewDirection =   mul(tangentSpaceTransform, output.WorldSpaceViewDirection);
            output.WorldSpacePosition =          input.positionRWS;
            output.ObjectSpacePosition =         TransformWorldToObject(input.positionRWS);
            // output.ViewSpacePosition =           TransformWorldToView(input.positionRWS);
            // output.TangentSpacePosition =        float3(0.0f, 0.0f, 0.0f);
            output.AbsoluteWorldSpacePosition =  GetAbsolutePositionWS(input.positionRWS);
            // output.ScreenPosition =              ComputeScreenPos(TransformWorldToHClip(input.positionRWS), _ProjectionParams.x);
            output.uv0 =                         input.texCoord0;
            // output.uv1 =                         input.texCoord1;
            // output.uv2 =                         input.texCoord2;
            // output.uv3 =                         input.texCoord3;
            // output.VertexColor =                 input.color;
            // output.FaceSign =                    input.isFrontFace;
            // output.TimeParameters =              _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value

            return output;
        }

    #if !defined(SHADER_STAGE_RAY_TRACING)

        // existing HDRP code uses the combined function to go directly from packed to frag inputs
        FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
        {
            UNITY_SETUP_INSTANCE_ID(input);
            VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
            return BuildFragInputs(unpacked);
        }
    #endif

    //-------------------------------------------------------------------------------------
    // END TEMPLATE INCLUDE : SharedCode.template.hlsl
    //-------------------------------------------------------------------------------------


        void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
        {
            // setup defaults -- these are used if the graph doesn't output a value
            ZERO_INITIALIZE(SurfaceData, surfaceData);

            // copy across graph values, if defined
            surfaceData.color = surfaceDescription.Color;

    #if defined(DEBUG_DISPLAY)
            if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
            {
                // TODO
            }
    #endif
        }

        void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData)
        {
            SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
            SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);

            // Perform alpha test very early to save performance (a killed pixel will not sample textures)
            // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
            DoAlphaTest(surfaceDescription.Alpha, surfaceDescription.AlphaClipThreshold);

            BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);

            // Builtin Data
            ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
            builtinData.opacity = surfaceDescription.Alpha;
        }

        //-------------------------------------------------------------------------------------
        // Pass Includes
        //-------------------------------------------------------------------------------------
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassLightTransport.hlsl"
        //-------------------------------------------------------------------------------------
        // End Pass Includes
        //-------------------------------------------------------------------------------------

        ENDHLSL
    }

        Pass
    {
        // based on UnlitPass.template
        Name "SceneSelectionPass"
        Tags { "LightMode" = "SceneSelectionPass" }

        //-------------------------------------------------------------------------------------
        // Render Modes (Blend, Cull, ZTest, Stencil, etc)
        //-------------------------------------------------------------------------------------
        
        Cull Off

        
        ZWrite On

        
        ColorMask 0

        //-------------------------------------------------------------------------------------
        // End Render Modes
        //-------------------------------------------------------------------------------------

        HLSLPROGRAM

        #pragma target 4.5
        #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
        //#pragma enable_d3d11_debug_symbols

        //enable GPU instancing support
        #pragma multi_compile_instancing

        //-------------------------------------------------------------------------------------
        // Variant Definitions (active field translations to HDRP defines)
        //-------------------------------------------------------------------------------------
        // #define _SURFACE_TYPE_TRANSPARENT 1
        // #define _BLENDMODE_ALPHA 1
        // #define _BLENDMODE_ADD 1
        // #define _BLENDMODE_PRE_MULTIPLY 1
        // #define _ADD_PRECOMPUTED_VELOCITY

        //-------------------------------------------------------------------------------------
        // End Variant Definitions
        //-------------------------------------------------------------------------------------

        #pragma vertex Vert
        #pragma fragment Frag

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"

        //-------------------------------------------------------------------------------------
        // Defines
        //-------------------------------------------------------------------------------------
                // Shared Graph Keywords
                #define SHADERPASS SHADERPASS_DEPTH_ONLY
                #define SCENESELECTIONPASS
                #pragma editor_sync_compilation
                // ACTIVE FIELDS:
                //   AlphaTest
                //   SurfaceDescriptionInputs.ObjectSpaceNormal
                //   SurfaceDescriptionInputs.WorldSpaceNormal
                //   SurfaceDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescriptionInputs.WorldSpacePosition
                //   SurfaceDescriptionInputs.AbsoluteWorldSpacePosition
                //   SurfaceDescriptionInputs.uv0
                //   VertexDescriptionInputs.ObjectSpaceNormal
                //   VertexDescriptionInputs.ObjectSpaceTangent
                //   VertexDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescription.Alpha
                //   SurfaceDescription.AlphaClipThreshold
                //   FragInputs.tangentToWorld
                //   FragInputs.positionRWS
                //   FragInputs.texCoord0
                //   AttributesMesh.normalOS
                //   AttributesMesh.tangentOS
                //   AttributesMesh.positionOS
                //   VaryingsMeshToPS.tangentWS
                //   VaryingsMeshToPS.normalWS
                //   VaryingsMeshToPS.positionRWS
                //   VaryingsMeshToPS.texCoord0
                //   AttributesMesh.uv0

        // this translates the new dependency tracker into the old preprocessor definitions for the existing HDRP shader code
        #define ATTRIBUTES_NEED_NORMAL
        #define ATTRIBUTES_NEED_TANGENT
        #define ATTRIBUTES_NEED_TEXCOORD0
        // #define ATTRIBUTES_NEED_TEXCOORD1
        // #define ATTRIBUTES_NEED_TEXCOORD2
        // #define ATTRIBUTES_NEED_TEXCOORD3
        // #define ATTRIBUTES_NEED_COLOR
        #define VARYINGS_NEED_POSITION_WS
        #define VARYINGS_NEED_TANGENT_TO_WORLD
        #define VARYINGS_NEED_TEXCOORD0
        // #define VARYINGS_NEED_TEXCOORD1
        // #define VARYINGS_NEED_TEXCOORD2
        // #define VARYINGS_NEED_TEXCOORD3
        // #define VARYINGS_NEED_COLOR
        // #define VARYINGS_NEED_CULLFACE
        // #define HAVE_MESH_MODIFICATION

        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------
    	

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"

        // Used by SceneSelectionPass
        int _ObjectId;
        int _PassValue;

        //-------------------------------------------------------------------------------------
        // Interpolator Packing And Struct Declarations
        //-------------------------------------------------------------------------------------
        // Generated Type: AttributesMesh
            struct AttributesMesh
            {
                float3 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
                float4 uv0 : TEXCOORD0; // optional
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : INSTANCEID_SEMANTIC;
                #endif // UNITY_ANY_INSTANCING_ENABLED
            };
        // Generated Type: VaryingsMeshToPS
            struct VaryingsMeshToPS
            {
                float4 positionCS : SV_POSITION;
                float3 positionRWS; // optional
                float3 normalWS; // optional
                float4 tangentWS; // optional
                float4 texCoord0; // optional
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif // UNITY_ANY_INSTANCING_ENABLED
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                #endif // defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            };
            
            // Generated Type: PackedVaryingsMeshToPS
            struct PackedVaryingsMeshToPS
            {
                float4 positionCS : SV_POSITION; // unpacked
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID; // unpacked
                #endif // conditional
                float3 interp00 : TEXCOORD0; // auto-packed
                float3 interp01 : TEXCOORD1; // auto-packed
                float4 interp02 : TEXCOORD2; // auto-packed
                float4 interp03 : TEXCOORD3; // auto-packed
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC; // unpacked
                #endif // conditional
            };
            
            // Packed Type: VaryingsMeshToPS
            PackedVaryingsMeshToPS PackVaryingsMeshToPS(VaryingsMeshToPS input)
            {
                PackedVaryingsMeshToPS output = (PackedVaryingsMeshToPS)0;
                output.positionCS = input.positionCS;
                output.interp00.xyz = input.positionRWS;
                output.interp01.xyz = input.normalWS;
                output.interp02.xyzw = input.tangentWS;
                output.interp03.xyzw = input.texCoord0;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif // conditional
                return output;
            }
            
            // Unpacked Type: VaryingsMeshToPS
            VaryingsMeshToPS UnpackVaryingsMeshToPS(PackedVaryingsMeshToPS input)
            {
                VaryingsMeshToPS output = (VaryingsMeshToPS)0;
                output.positionCS = input.positionCS;
                output.positionRWS = input.interp00.xyz;
                output.normalWS = input.interp01.xyz;
                output.tangentWS = input.interp02.xyzw;
                output.texCoord0 = input.interp03.xyzw;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif // conditional
                return output;
            }
        // Generated Type: VaryingsMeshToDS
            struct VaryingsMeshToDS
            {
                float3 positionRWS;
                float3 normalWS;
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif // UNITY_ANY_INSTANCING_ENABLED
            };
            
            // Generated Type: PackedVaryingsMeshToDS
            struct PackedVaryingsMeshToDS
            {
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID; // unpacked
                #endif // conditional
                float3 interp00 : TEXCOORD0; // auto-packed
                float3 interp01 : TEXCOORD1; // auto-packed
            };
            
            // Packed Type: VaryingsMeshToDS
            PackedVaryingsMeshToDS PackVaryingsMeshToDS(VaryingsMeshToDS input)
            {
                PackedVaryingsMeshToDS output = (PackedVaryingsMeshToDS)0;
                output.interp00.xyz = input.positionRWS;
                output.interp01.xyz = input.normalWS;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                return output;
            }
            
            // Unpacked Type: VaryingsMeshToDS
            VaryingsMeshToDS UnpackVaryingsMeshToDS(PackedVaryingsMeshToDS input)
            {
                VaryingsMeshToDS output = (VaryingsMeshToDS)0;
                output.positionRWS = input.interp00.xyz;
                output.normalWS = input.interp01.xyz;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                return output;
            }
        //-------------------------------------------------------------------------------------
        // End Interpolator Packing And Struct Declarations
        //-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------
        // Graph generated code
        //-------------------------------------------------------------------------------------
                // Shared Graph Properties (uniform inputs)


//Advanced Dissolve Keywords Start///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#pragma shader_feature_local   _AD_STATE_ENABLED
#pragma shader_feature_local _ _AD_CUTOUT_STANDARD_SOURCE_BASE_ALPHA				  _AD_CUTOUT_STANDARD_SOURCE_CUSTOM_MAP                     _AD_CUTOUT_STANDARD_SOURCE_TWO_CUSTOM_MAPS _AD_CUTOUT_STANDARD_SOURCE_THREE_CUSTOM_MAPS _AD_CUTOUT_STANDARD_SOURCE_USER_DEFINED
#pragma shader_feature_local _ _AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_TRIPLANAR _AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_SCREEN_SPACE
#pragma shader_feature_local _ _AD_CUTOUT_GEOMETRIC_TYPE_XYZ						  _AD_CUTOUT_GEOMETRIC_TYPE_PLANE                           _AD_CUTOUT_GEOMETRIC_TYPE_SPHERE           _AD_CUTOUT_GEOMETRIC_TYPE_CUBE               _AD_CUTOUT_GEOMETRIC_TYPE_CAPSULE       _AD_CUTOUT_GEOMETRIC_TYPE_CONE_SMOOTH
#pragma shader_feature_local _ _AD_CUTOUT_GEOMETRIC_COUNT_TWO					      _AD_CUTOUT_GEOMETRIC_COUNT_THREE                          _AD_CUTOUT_GEOMETRIC_COUNT_FOUR
#pragma shader_feature_local _ _AD_EDGE_BASE_SOURCE_CUTOUT_STANDARD                   _AD_EDGE_BASE_SOURCE_CUTOUT_GEOMETRIC                     _AD_EDGE_BASE_SOURCE_ALL
#pragma shader_feature_local _ _AD_EDGE_ADDITIONAL_COLOR_BASE_COLOR                   _AD_EDGE_ADDITIONAL_COLOR_CUSTOM_MAP                      _AD_EDGE_ADDITIONAL_COLOR_GRADIENT_MAP     _AD_EDGE_ADDITIONAL_COLOR_GRADIENT_COLOR     _AD_EDGE_ADDITIONAL_COLOR_USER_DEFINED
#pragma shader_feature_local _ _AD_GLOBAL_CONTROL_ID_ONE                              _AD_GLOBAL_CONTROL_ID_TWO                                 _AD_GLOBAL_CONTROL_ID_THREE                _AD_GLOBAL_CONTROL_ID_FOUR
//Advanced Dissolve Keywords End/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


#define ADVANCED_DISSOLVE_SHADER_GRAPH
#define ADVANCED_DISSOLVE_HIGH_DEFINITION_RENDER_PIPELINE
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Defines.cginc"
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                    CBUFFER_START(UnityPerMaterial)
        float4 _BaseColor;
        float4 _EmissiveColor;
        float _EmissiveIntensity;
        float _EmissiveExposureWeight;
        CBUFFER_END
        TEXTURE2D(_BaseColorMap); SAMPLER(sampler_BaseColorMap); float4 _BaseColorMap_TexelSize;
        TEXTURE2D(_EmissiveColorMap); SAMPLER(sampler_EmissiveColorMap); float4 _EmissiveColorMap_TexelSize;
        SAMPLER(_SampleTexture2D_9AB23BAE_Sampler_3_Linear_Repeat);

                // Pixel Graph Inputs
                    struct SurfaceDescriptionInputs
                    {
                        float3 ObjectSpaceNormal; // optional
                        float3 WorldSpaceNormal; // optional
                        float3 ObjectSpacePosition; // optional
                        float3 WorldSpacePosition; // optional
                        float3 AbsoluteWorldSpacePosition; // optional
                        float4 uv0; // optional
                    };
                // Pixel Graph Outputs
                    struct SurfaceDescription
    {
        float Alpha;
        float AlphaClipThreshold;
    };

                // Shared Graph Node Functions
                
        void AdvancedDissolveShaderGraphFunction_float(float2 UV, float3 PositionOS, float3 PositionWS, float3 PositionWSAbsolute, float3 NormalOS, float3 NormalWS, float CustomCutout, float4 CustomColor, out float Value)
        {
            Value = 0;
        }

        struct Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab
        {
            float3 ObjectSpaceNormal;
            float3 WorldSpaceNormal;
            float3 ObjectSpacePosition;
            float3 WorldSpacePosition;
            float3 AbsoluteWorldSpacePosition;
            half4 uv0;
        };

        void SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(float Vector1_9E44E7D0, float4 Color_9C152E30, Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab IN, out float Out_3)
        {
            float4 _UV_B7DC59D1_Out_0 = IN.uv0;
            float _Property_AA10DA06_Out_0 = Vector1_9E44E7D0;
            float4 _Property_D5854A9E_Out_0 = Color_9C152E30;
            float _CustomFunction_7278F8D6_Value_7;
            AdvancedDissolveShaderGraphFunction_float((_UV_B7DC59D1_Out_0.xy), IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, _Property_AA10DA06_Out_0, _Property_D5854A9E_Out_0, _CustomFunction_7278F8D6_Value_7);
            Out_3 = _CustomFunction_7278F8D6_Value_7;
        }

                // Pixel Graph Evaluation


//Advanced Dissolve
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Core.cginc"


                    SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float4 _SampleTexture2D_9AB23BAE_RGBA_0 = SAMPLE_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, IN.uv0.xy);
        float _SampleTexture2D_9AB23BAE_R_4 = _SampleTexture2D_9AB23BAE_RGBA_0.r;
        float _SampleTexture2D_9AB23BAE_G_5 = _SampleTexture2D_9AB23BAE_RGBA_0.g;
        float _SampleTexture2D_9AB23BAE_B_6 = _SampleTexture2D_9AB23BAE_RGBA_0.b;
        float _SampleTexture2D_9AB23BAE_A_7 = _SampleTexture2D_9AB23BAE_RGBA_0.a;
        float _Split_609E0B65_R_1 = _SampleTexture2D_9AB23BAE_RGBA_0[0];
        float _Split_609E0B65_G_2 = _SampleTexture2D_9AB23BAE_RGBA_0[1];
        float _Split_609E0B65_B_3 = _SampleTexture2D_9AB23BAE_RGBA_0[2];
        float _Split_609E0B65_A_4 = _SampleTexture2D_9AB23BAE_RGBA_0[3];
        Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab _AdvancedDissolve_B8B8503F;
        _AdvancedDissolve_B8B8503F.ObjectSpaceNormal = IN.ObjectSpaceNormal;
        _AdvancedDissolve_B8B8503F.WorldSpaceNormal = IN.WorldSpaceNormal;
        _AdvancedDissolve_B8B8503F.ObjectSpacePosition = IN.ObjectSpacePosition;
        _AdvancedDissolve_B8B8503F.WorldSpacePosition = IN.WorldSpacePosition;
        _AdvancedDissolve_B8B8503F.AbsoluteWorldSpacePosition = IN.AbsoluteWorldSpacePosition;
        _AdvancedDissolve_B8B8503F.uv0 = IN.uv0;
        float _AdvancedDissolve_B8B8503F_Out_3;
        SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(0, float4 (0, 0, 0, 1), _AdvancedDissolve_B8B8503F, _AdvancedDissolve_B8B8503F_Out_3);
        surface.Alpha = _Split_609E0B65_A_4;
        surface.AlphaClipThreshold = _AdvancedDissolve_B8B8503F_Out_3;


//SceneSelectionPass
AdvancedDissolveShaderGraph(IN.uv0.xy, IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, 0, 1, surface.Alpha, surface.AlphaClipThreshold);


return surface;

    }

        //-------------------------------------------------------------------------------------
        // End graph generated code
        //-------------------------------------------------------------------------------------

    // $include("VertexAnimation.template.hlsl")

    //-------------------------------------------------------------------------------------
    // TEMPLATE INCLUDE : SharedCode.template.hlsl
    //-------------------------------------------------------------------------------------

    #if !defined(SHADER_STAGE_RAY_TRACING)
        FragInputs BuildFragInputs(VaryingsMeshToPS input)
        {
            FragInputs output;
            ZERO_INITIALIZE(FragInputs, output);

            // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
            // TODO: this is a really poor workaround, but the variable is used in a bunch of places
            // to compute normals which are then passed on elsewhere to compute other values...
            output.tangentToWorld = k_identity3x3;
            output.positionSS = input.positionCS;       // input.positionCS is SV_Position

            output.positionRWS = input.positionRWS;
            output.tangentToWorld = BuildTangentToWorld(input.tangentWS, input.normalWS);
            output.texCoord0 = input.texCoord0;
            // output.texCoord1 = input.texCoord1;
            // output.texCoord2 = input.texCoord2;
            // output.texCoord3 = input.texCoord3;
            // output.color = input.color;
            #if _DOUBLESIDED_ON && SHADER_STAGE_FRAGMENT
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #elif SHADER_STAGE_FRAGMENT
            // output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #endif // SHADER_STAGE_FRAGMENT

            return output;
        }
    #endif
        SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
        {
            SurfaceDescriptionInputs output;
            ZERO_INITIALIZE(SurfaceDescriptionInputs, output);

            output.WorldSpaceNormal =            input.tangentToWorld[2].xyz;	// normal was already normalized in BuildTangentToWorld()
            output.ObjectSpaceNormal =           normalize(mul(output.WorldSpaceNormal, (float3x3) UNITY_MATRIX_M));           // transposed multiplication by inverse matrix to handle normal scale
            // output.ViewSpaceNormal =             mul(output.WorldSpaceNormal, (float3x3) UNITY_MATRIX_I_V);         // transposed multiplication by inverse matrix to handle normal scale
            // output.TangentSpaceNormal =          float3(0.0f, 0.0f, 1.0f);
            // output.WorldSpaceTangent =           input.tangentToWorld[0].xyz;
            // output.ObjectSpaceTangent =          TransformWorldToObjectDir(output.WorldSpaceTangent);
            // output.ViewSpaceTangent =            TransformWorldToViewDir(output.WorldSpaceTangent);
            // output.TangentSpaceTangent =         float3(1.0f, 0.0f, 0.0f);
            // output.WorldSpaceBiTangent =         input.tangentToWorld[1].xyz;
            // output.ObjectSpaceBiTangent =        TransformWorldToObjectDir(output.WorldSpaceBiTangent);
            // output.ViewSpaceBiTangent =          TransformWorldToViewDir(output.WorldSpaceBiTangent);
            // output.TangentSpaceBiTangent =       float3(0.0f, 1.0f, 0.0f);
            // output.WorldSpaceViewDirection =     normalize(viewWS);
            // output.ObjectSpaceViewDirection =    TransformWorldToObjectDir(output.WorldSpaceViewDirection);
            // output.ViewSpaceViewDirection =      TransformWorldToViewDir(output.WorldSpaceViewDirection);
            // float3x3 tangentSpaceTransform =     float3x3(output.WorldSpaceTangent,output.WorldSpaceBiTangent,output.WorldSpaceNormal);
            // output.TangentSpaceViewDirection =   mul(tangentSpaceTransform, output.WorldSpaceViewDirection);
            output.WorldSpacePosition =          input.positionRWS;
            output.ObjectSpacePosition =         TransformWorldToObject(input.positionRWS);
            // output.ViewSpacePosition =           TransformWorldToView(input.positionRWS);
            // output.TangentSpacePosition =        float3(0.0f, 0.0f, 0.0f);
            output.AbsoluteWorldSpacePosition =  GetAbsolutePositionWS(input.positionRWS);
            // output.ScreenPosition =              ComputeScreenPos(TransformWorldToHClip(input.positionRWS), _ProjectionParams.x);
            output.uv0 =                         input.texCoord0;
            // output.uv1 =                         input.texCoord1;
            // output.uv2 =                         input.texCoord2;
            // output.uv3 =                         input.texCoord3;
            // output.VertexColor =                 input.color;
            // output.FaceSign =                    input.isFrontFace;
            // output.TimeParameters =              _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value

            return output;
        }

    #if !defined(SHADER_STAGE_RAY_TRACING)

        // existing HDRP code uses the combined function to go directly from packed to frag inputs
        FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
        {
            UNITY_SETUP_INSTANCE_ID(input);
            VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
            return BuildFragInputs(unpacked);
        }
    #endif

    //-------------------------------------------------------------------------------------
    // END TEMPLATE INCLUDE : SharedCode.template.hlsl
    //-------------------------------------------------------------------------------------


        void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
        {
            // setup defaults -- these are used if the graph doesn't output a value
            ZERO_INITIALIZE(SurfaceData, surfaceData);

            // copy across graph values, if defined
            // surfaceData.color = surfaceDescription.Color;

    #if defined(DEBUG_DISPLAY)
            if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
            {
                // TODO
            }
    #endif
        }

        void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData)
        {
            SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
            SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);

            // Perform alpha test very early to save performance (a killed pixel will not sample textures)
            // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
            DoAlphaTest(surfaceDescription.Alpha, surfaceDescription.AlphaClipThreshold);

            BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);

            // Builtin Data
            ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
            builtinData.opacity = surfaceDescription.Alpha;
        }

        //-------------------------------------------------------------------------------------
        // Pass Includes
        //-------------------------------------------------------------------------------------
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassDepthOnly.hlsl"
        //-------------------------------------------------------------------------------------
        // End Pass Includes
        //-------------------------------------------------------------------------------------

        ENDHLSL
    }

        Pass
    {
        // based on UnlitPass.template
        Name "DepthForwardOnly"
        Tags { "LightMode" = "DepthForwardOnly" }

        //-------------------------------------------------------------------------------------
        // Render Modes (Blend, Cull, ZTest, Stencil, etc)
        //-------------------------------------------------------------------------------------
        
        Cull Off

        
        ZWrite On

        
        ColorMask 0 0

        //-------------------------------------------------------------------------------------
        // End Render Modes
        //-------------------------------------------------------------------------------------

        HLSLPROGRAM

        #pragma target 4.5
        #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
        //#pragma enable_d3d11_debug_symbols

        //enable GPU instancing support
        #pragma multi_compile_instancing

        //-------------------------------------------------------------------------------------
        // Variant Definitions (active field translations to HDRP defines)
        //-------------------------------------------------------------------------------------
        // #define _SURFACE_TYPE_TRANSPARENT 1
        // #define _BLENDMODE_ALPHA 1
        // #define _BLENDMODE_ADD 1
        // #define _BLENDMODE_PRE_MULTIPLY 1
        // #define _ADD_PRECOMPUTED_VELOCITY

        //-------------------------------------------------------------------------------------
        // End Variant Definitions
        //-------------------------------------------------------------------------------------

        #pragma vertex Vert
        #pragma fragment Frag

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"

        //-------------------------------------------------------------------------------------
        // Defines
        //-------------------------------------------------------------------------------------
                // Shared Graph Keywords
                #define SHADERPASS SHADERPASS_DEPTH_ONLY
                #pragma multi_compile _ WRITE_MSAA_DEPTH
                // ACTIVE FIELDS:
                //   AlphaTest
                //   SurfaceDescriptionInputs.ObjectSpaceNormal
                //   SurfaceDescriptionInputs.WorldSpaceNormal
                //   SurfaceDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescriptionInputs.WorldSpacePosition
                //   SurfaceDescriptionInputs.AbsoluteWorldSpacePosition
                //   SurfaceDescriptionInputs.uv0
                //   VertexDescriptionInputs.ObjectSpaceNormal
                //   VertexDescriptionInputs.ObjectSpaceTangent
                //   VertexDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescription.Alpha
                //   SurfaceDescription.AlphaClipThreshold
                //   FragInputs.tangentToWorld
                //   FragInputs.positionRWS
                //   FragInputs.texCoord0
                //   AttributesMesh.normalOS
                //   AttributesMesh.tangentOS
                //   AttributesMesh.positionOS
                //   VaryingsMeshToPS.tangentWS
                //   VaryingsMeshToPS.normalWS
                //   VaryingsMeshToPS.positionRWS
                //   VaryingsMeshToPS.texCoord0
                //   AttributesMesh.uv0

        // this translates the new dependency tracker into the old preprocessor definitions for the existing HDRP shader code
        #define ATTRIBUTES_NEED_NORMAL
        #define ATTRIBUTES_NEED_TANGENT
        #define ATTRIBUTES_NEED_TEXCOORD0
        // #define ATTRIBUTES_NEED_TEXCOORD1
        // #define ATTRIBUTES_NEED_TEXCOORD2
        // #define ATTRIBUTES_NEED_TEXCOORD3
        // #define ATTRIBUTES_NEED_COLOR
        #define VARYINGS_NEED_POSITION_WS
        #define VARYINGS_NEED_TANGENT_TO_WORLD
        #define VARYINGS_NEED_TEXCOORD0
        // #define VARYINGS_NEED_TEXCOORD1
        // #define VARYINGS_NEED_TEXCOORD2
        // #define VARYINGS_NEED_TEXCOORD3
        // #define VARYINGS_NEED_COLOR
        // #define VARYINGS_NEED_CULLFACE
        // #define HAVE_MESH_MODIFICATION

        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------
    	

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"

        // Used by SceneSelectionPass
        int _ObjectId;
        int _PassValue;

        //-------------------------------------------------------------------------------------
        // Interpolator Packing And Struct Declarations
        //-------------------------------------------------------------------------------------
        // Generated Type: AttributesMesh
            struct AttributesMesh
            {
                float3 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
                float4 uv0 : TEXCOORD0; // optional
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : INSTANCEID_SEMANTIC;
                #endif // UNITY_ANY_INSTANCING_ENABLED
            };
        // Generated Type: VaryingsMeshToPS
            struct VaryingsMeshToPS
            {
                float4 positionCS : SV_POSITION;
                float3 positionRWS; // optional
                float3 normalWS; // optional
                float4 tangentWS; // optional
                float4 texCoord0; // optional
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif // UNITY_ANY_INSTANCING_ENABLED
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                #endif // defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            };
            
            // Generated Type: PackedVaryingsMeshToPS
            struct PackedVaryingsMeshToPS
            {
                float4 positionCS : SV_POSITION; // unpacked
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID; // unpacked
                #endif // conditional
                float3 interp00 : TEXCOORD0; // auto-packed
                float3 interp01 : TEXCOORD1; // auto-packed
                float4 interp02 : TEXCOORD2; // auto-packed
                float4 interp03 : TEXCOORD3; // auto-packed
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC; // unpacked
                #endif // conditional
            };
            
            // Packed Type: VaryingsMeshToPS
            PackedVaryingsMeshToPS PackVaryingsMeshToPS(VaryingsMeshToPS input)
            {
                PackedVaryingsMeshToPS output = (PackedVaryingsMeshToPS)0;
                output.positionCS = input.positionCS;
                output.interp00.xyz = input.positionRWS;
                output.interp01.xyz = input.normalWS;
                output.interp02.xyzw = input.tangentWS;
                output.interp03.xyzw = input.texCoord0;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif // conditional
                return output;
            }
            
            // Unpacked Type: VaryingsMeshToPS
            VaryingsMeshToPS UnpackVaryingsMeshToPS(PackedVaryingsMeshToPS input)
            {
                VaryingsMeshToPS output = (VaryingsMeshToPS)0;
                output.positionCS = input.positionCS;
                output.positionRWS = input.interp00.xyz;
                output.normalWS = input.interp01.xyz;
                output.tangentWS = input.interp02.xyzw;
                output.texCoord0 = input.interp03.xyzw;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif // conditional
                return output;
            }
        // Generated Type: VaryingsMeshToDS
            struct VaryingsMeshToDS
            {
                float3 positionRWS;
                float3 normalWS;
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif // UNITY_ANY_INSTANCING_ENABLED
            };
            
            // Generated Type: PackedVaryingsMeshToDS
            struct PackedVaryingsMeshToDS
            {
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID; // unpacked
                #endif // conditional
                float3 interp00 : TEXCOORD0; // auto-packed
                float3 interp01 : TEXCOORD1; // auto-packed
            };
            
            // Packed Type: VaryingsMeshToDS
            PackedVaryingsMeshToDS PackVaryingsMeshToDS(VaryingsMeshToDS input)
            {
                PackedVaryingsMeshToDS output = (PackedVaryingsMeshToDS)0;
                output.interp00.xyz = input.positionRWS;
                output.interp01.xyz = input.normalWS;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                return output;
            }
            
            // Unpacked Type: VaryingsMeshToDS
            VaryingsMeshToDS UnpackVaryingsMeshToDS(PackedVaryingsMeshToDS input)
            {
                VaryingsMeshToDS output = (VaryingsMeshToDS)0;
                output.positionRWS = input.interp00.xyz;
                output.normalWS = input.interp01.xyz;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                return output;
            }
        //-------------------------------------------------------------------------------------
        // End Interpolator Packing And Struct Declarations
        //-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------
        // Graph generated code
        //-------------------------------------------------------------------------------------
                // Shared Graph Properties (uniform inputs)


//Advanced Dissolve Keywords Start///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#pragma shader_feature_local   _AD_STATE_ENABLED
#pragma shader_feature_local _ _AD_CUTOUT_STANDARD_SOURCE_BASE_ALPHA				  _AD_CUTOUT_STANDARD_SOURCE_CUSTOM_MAP                     _AD_CUTOUT_STANDARD_SOURCE_TWO_CUSTOM_MAPS _AD_CUTOUT_STANDARD_SOURCE_THREE_CUSTOM_MAPS _AD_CUTOUT_STANDARD_SOURCE_USER_DEFINED
#pragma shader_feature_local _ _AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_TRIPLANAR _AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_SCREEN_SPACE
#pragma shader_feature_local _ _AD_CUTOUT_GEOMETRIC_TYPE_XYZ						  _AD_CUTOUT_GEOMETRIC_TYPE_PLANE                           _AD_CUTOUT_GEOMETRIC_TYPE_SPHERE           _AD_CUTOUT_GEOMETRIC_TYPE_CUBE               _AD_CUTOUT_GEOMETRIC_TYPE_CAPSULE       _AD_CUTOUT_GEOMETRIC_TYPE_CONE_SMOOTH
#pragma shader_feature_local _ _AD_CUTOUT_GEOMETRIC_COUNT_TWO					      _AD_CUTOUT_GEOMETRIC_COUNT_THREE                          _AD_CUTOUT_GEOMETRIC_COUNT_FOUR
#pragma shader_feature_local _ _AD_EDGE_BASE_SOURCE_CUTOUT_STANDARD                   _AD_EDGE_BASE_SOURCE_CUTOUT_GEOMETRIC                     _AD_EDGE_BASE_SOURCE_ALL
#pragma shader_feature_local _ _AD_EDGE_ADDITIONAL_COLOR_BASE_COLOR                   _AD_EDGE_ADDITIONAL_COLOR_CUSTOM_MAP                      _AD_EDGE_ADDITIONAL_COLOR_GRADIENT_MAP     _AD_EDGE_ADDITIONAL_COLOR_GRADIENT_COLOR     _AD_EDGE_ADDITIONAL_COLOR_USER_DEFINED
#pragma shader_feature_local _ _AD_GLOBAL_CONTROL_ID_ONE                              _AD_GLOBAL_CONTROL_ID_TWO                                 _AD_GLOBAL_CONTROL_ID_THREE                _AD_GLOBAL_CONTROL_ID_FOUR
//Advanced Dissolve Keywords End/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


#define ADVANCED_DISSOLVE_SHADER_GRAPH
#define ADVANCED_DISSOLVE_HIGH_DEFINITION_RENDER_PIPELINE
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Defines.cginc"
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                    CBUFFER_START(UnityPerMaterial)
        float4 _BaseColor;
        float4 _EmissiveColor;
        float _EmissiveIntensity;
        float _EmissiveExposureWeight;
        CBUFFER_END
        TEXTURE2D(_BaseColorMap); SAMPLER(sampler_BaseColorMap); float4 _BaseColorMap_TexelSize;
        TEXTURE2D(_EmissiveColorMap); SAMPLER(sampler_EmissiveColorMap); float4 _EmissiveColorMap_TexelSize;
        SAMPLER(_SampleTexture2D_9AB23BAE_Sampler_3_Linear_Repeat);

                // Pixel Graph Inputs
                    struct SurfaceDescriptionInputs
                    {
                        float3 ObjectSpaceNormal; // optional
                        float3 WorldSpaceNormal; // optional
                        float3 ObjectSpacePosition; // optional
                        float3 WorldSpacePosition; // optional
                        float3 AbsoluteWorldSpacePosition; // optional
                        float4 uv0; // optional
                    };
                // Pixel Graph Outputs
                    struct SurfaceDescription
    {
        float Alpha;
        float AlphaClipThreshold;
    };

                // Shared Graph Node Functions
                
        void AdvancedDissolveShaderGraphFunction_float(float2 UV, float3 PositionOS, float3 PositionWS, float3 PositionWSAbsolute, float3 NormalOS, float3 NormalWS, float CustomCutout, float4 CustomColor, out float Value)
        {
            Value = 0;
        }

        struct Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab
        {
            float3 ObjectSpaceNormal;
            float3 WorldSpaceNormal;
            float3 ObjectSpacePosition;
            float3 WorldSpacePosition;
            float3 AbsoluteWorldSpacePosition;
            half4 uv0;
        };

        void SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(float Vector1_9E44E7D0, float4 Color_9C152E30, Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab IN, out float Out_3)
        {
            float4 _UV_B7DC59D1_Out_0 = IN.uv0;
            float _Property_AA10DA06_Out_0 = Vector1_9E44E7D0;
            float4 _Property_D5854A9E_Out_0 = Color_9C152E30;
            float _CustomFunction_7278F8D6_Value_7;
            AdvancedDissolveShaderGraphFunction_float((_UV_B7DC59D1_Out_0.xy), IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, _Property_AA10DA06_Out_0, _Property_D5854A9E_Out_0, _CustomFunction_7278F8D6_Value_7);
            Out_3 = _CustomFunction_7278F8D6_Value_7;
        }

                // Pixel Graph Evaluation


//Advanced Dissolve
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Core.cginc"


                    SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float4 _SampleTexture2D_9AB23BAE_RGBA_0 = SAMPLE_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, IN.uv0.xy);
        float _SampleTexture2D_9AB23BAE_R_4 = _SampleTexture2D_9AB23BAE_RGBA_0.r;
        float _SampleTexture2D_9AB23BAE_G_5 = _SampleTexture2D_9AB23BAE_RGBA_0.g;
        float _SampleTexture2D_9AB23BAE_B_6 = _SampleTexture2D_9AB23BAE_RGBA_0.b;
        float _SampleTexture2D_9AB23BAE_A_7 = _SampleTexture2D_9AB23BAE_RGBA_0.a;
        float _Split_609E0B65_R_1 = _SampleTexture2D_9AB23BAE_RGBA_0[0];
        float _Split_609E0B65_G_2 = _SampleTexture2D_9AB23BAE_RGBA_0[1];
        float _Split_609E0B65_B_3 = _SampleTexture2D_9AB23BAE_RGBA_0[2];
        float _Split_609E0B65_A_4 = _SampleTexture2D_9AB23BAE_RGBA_0[3];
        Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab _AdvancedDissolve_B8B8503F;
        _AdvancedDissolve_B8B8503F.ObjectSpaceNormal = IN.ObjectSpaceNormal;
        _AdvancedDissolve_B8B8503F.WorldSpaceNormal = IN.WorldSpaceNormal;
        _AdvancedDissolve_B8B8503F.ObjectSpacePosition = IN.ObjectSpacePosition;
        _AdvancedDissolve_B8B8503F.WorldSpacePosition = IN.WorldSpacePosition;
        _AdvancedDissolve_B8B8503F.AbsoluteWorldSpacePosition = IN.AbsoluteWorldSpacePosition;
        _AdvancedDissolve_B8B8503F.uv0 = IN.uv0;
        float _AdvancedDissolve_B8B8503F_Out_3;
        SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(0, float4 (0, 0, 0, 1), _AdvancedDissolve_B8B8503F, _AdvancedDissolve_B8B8503F_Out_3);
        surface.Alpha = _Split_609E0B65_A_4;
        surface.AlphaClipThreshold = _AdvancedDissolve_B8B8503F_Out_3;


//DepthForwardOnly
AdvancedDissolveShaderGraph(IN.uv0.xy, IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, 0, 1, surface.Alpha, surface.AlphaClipThreshold);


return surface;

    }

        //-------------------------------------------------------------------------------------
        // End graph generated code
        //-------------------------------------------------------------------------------------

    // $include("VertexAnimation.template.hlsl")

    //-------------------------------------------------------------------------------------
    // TEMPLATE INCLUDE : SharedCode.template.hlsl
    //-------------------------------------------------------------------------------------

    #if !defined(SHADER_STAGE_RAY_TRACING)
        FragInputs BuildFragInputs(VaryingsMeshToPS input)
        {
            FragInputs output;
            ZERO_INITIALIZE(FragInputs, output);

            // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
            // TODO: this is a really poor workaround, but the variable is used in a bunch of places
            // to compute normals which are then passed on elsewhere to compute other values...
            output.tangentToWorld = k_identity3x3;
            output.positionSS = input.positionCS;       // input.positionCS is SV_Position

            output.positionRWS = input.positionRWS;
            output.tangentToWorld = BuildTangentToWorld(input.tangentWS, input.normalWS);
            output.texCoord0 = input.texCoord0;
            // output.texCoord1 = input.texCoord1;
            // output.texCoord2 = input.texCoord2;
            // output.texCoord3 = input.texCoord3;
            // output.color = input.color;
            #if _DOUBLESIDED_ON && SHADER_STAGE_FRAGMENT
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #elif SHADER_STAGE_FRAGMENT
            // output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #endif // SHADER_STAGE_FRAGMENT

            return output;
        }
    #endif
        SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
        {
            SurfaceDescriptionInputs output;
            ZERO_INITIALIZE(SurfaceDescriptionInputs, output);

            output.WorldSpaceNormal =            input.tangentToWorld[2].xyz;	// normal was already normalized in BuildTangentToWorld()
            output.ObjectSpaceNormal =           normalize(mul(output.WorldSpaceNormal, (float3x3) UNITY_MATRIX_M));           // transposed multiplication by inverse matrix to handle normal scale
            // output.ViewSpaceNormal =             mul(output.WorldSpaceNormal, (float3x3) UNITY_MATRIX_I_V);         // transposed multiplication by inverse matrix to handle normal scale
            // output.TangentSpaceNormal =          float3(0.0f, 0.0f, 1.0f);
            // output.WorldSpaceTangent =           input.tangentToWorld[0].xyz;
            // output.ObjectSpaceTangent =          TransformWorldToObjectDir(output.WorldSpaceTangent);
            // output.ViewSpaceTangent =            TransformWorldToViewDir(output.WorldSpaceTangent);
            // output.TangentSpaceTangent =         float3(1.0f, 0.0f, 0.0f);
            // output.WorldSpaceBiTangent =         input.tangentToWorld[1].xyz;
            // output.ObjectSpaceBiTangent =        TransformWorldToObjectDir(output.WorldSpaceBiTangent);
            // output.ViewSpaceBiTangent =          TransformWorldToViewDir(output.WorldSpaceBiTangent);
            // output.TangentSpaceBiTangent =       float3(0.0f, 1.0f, 0.0f);
            // output.WorldSpaceViewDirection =     normalize(viewWS);
            // output.ObjectSpaceViewDirection =    TransformWorldToObjectDir(output.WorldSpaceViewDirection);
            // output.ViewSpaceViewDirection =      TransformWorldToViewDir(output.WorldSpaceViewDirection);
            // float3x3 tangentSpaceTransform =     float3x3(output.WorldSpaceTangent,output.WorldSpaceBiTangent,output.WorldSpaceNormal);
            // output.TangentSpaceViewDirection =   mul(tangentSpaceTransform, output.WorldSpaceViewDirection);
            output.WorldSpacePosition =          input.positionRWS;
            output.ObjectSpacePosition =         TransformWorldToObject(input.positionRWS);
            // output.ViewSpacePosition =           TransformWorldToView(input.positionRWS);
            // output.TangentSpacePosition =        float3(0.0f, 0.0f, 0.0f);
            output.AbsoluteWorldSpacePosition =  GetAbsolutePositionWS(input.positionRWS);
            // output.ScreenPosition =              ComputeScreenPos(TransformWorldToHClip(input.positionRWS), _ProjectionParams.x);
            output.uv0 =                         input.texCoord0;
            // output.uv1 =                         input.texCoord1;
            // output.uv2 =                         input.texCoord2;
            // output.uv3 =                         input.texCoord3;
            // output.VertexColor =                 input.color;
            // output.FaceSign =                    input.isFrontFace;
            // output.TimeParameters =              _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value

            return output;
        }

    #if !defined(SHADER_STAGE_RAY_TRACING)

        // existing HDRP code uses the combined function to go directly from packed to frag inputs
        FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
        {
            UNITY_SETUP_INSTANCE_ID(input);
            VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
            return BuildFragInputs(unpacked);
        }
    #endif

    //-------------------------------------------------------------------------------------
    // END TEMPLATE INCLUDE : SharedCode.template.hlsl
    //-------------------------------------------------------------------------------------


        void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
        {
            // setup defaults -- these are used if the graph doesn't output a value
            ZERO_INITIALIZE(SurfaceData, surfaceData);

            // copy across graph values, if defined
            // surfaceData.color = surfaceDescription.Color;

    #if defined(DEBUG_DISPLAY)
            if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
            {
                // TODO
            }
    #endif
        }

        void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData)
        {
            SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
            SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);

            // Perform alpha test very early to save performance (a killed pixel will not sample textures)
            // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
            DoAlphaTest(surfaceDescription.Alpha, surfaceDescription.AlphaClipThreshold);

            BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);

            // Builtin Data
            ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
            builtinData.opacity = surfaceDescription.Alpha;
        }

        //-------------------------------------------------------------------------------------
        // Pass Includes
        //-------------------------------------------------------------------------------------
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassDepthOnly.hlsl"
        //-------------------------------------------------------------------------------------
        // End Pass Includes
        //-------------------------------------------------------------------------------------

        ENDHLSL
    }

        Pass
    {
        // based on UnlitPass.template
        Name "MotionVectors"
        Tags { "LightMode" = "MotionVectors" }

        //-------------------------------------------------------------------------------------
        // Render Modes (Blend, Cull, ZTest, Stencil, etc)
        //-------------------------------------------------------------------------------------
        
        Cull Off

        
        
        // Stencil setup
    Stencil
    {
       WriteMask 32
       Ref  32
       Comp Always
       Pass Replace
    }

        ColorMask 0 1

        //-------------------------------------------------------------------------------------
        // End Render Modes
        //-------------------------------------------------------------------------------------

        HLSLPROGRAM

        #pragma target 4.5
        #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
        //#pragma enable_d3d11_debug_symbols

        //enable GPU instancing support
        #pragma multi_compile_instancing

        //-------------------------------------------------------------------------------------
        // Variant Definitions (active field translations to HDRP defines)
        //-------------------------------------------------------------------------------------
        // #define _SURFACE_TYPE_TRANSPARENT 1
        // #define _BLENDMODE_ALPHA 1
        // #define _BLENDMODE_ADD 1
        // #define _BLENDMODE_PRE_MULTIPLY 1
        // #define _ADD_PRECOMPUTED_VELOCITY

        //-------------------------------------------------------------------------------------
        // End Variant Definitions
        //-------------------------------------------------------------------------------------

        #pragma vertex Vert
        #pragma fragment Frag

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"

        //-------------------------------------------------------------------------------------
        // Defines
        //-------------------------------------------------------------------------------------
                // Shared Graph Keywords
                #define SHADERPASS SHADERPASS_MOTION_VECTORS
                #pragma multi_compile _ WRITE_MSAA_DEPTH
                // ACTIVE FIELDS:
                //   AlphaTest
                //   SurfaceDescriptionInputs.ObjectSpaceNormal
                //   SurfaceDescriptionInputs.WorldSpaceNormal
                //   SurfaceDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescriptionInputs.WorldSpacePosition
                //   SurfaceDescriptionInputs.AbsoluteWorldSpacePosition
                //   SurfaceDescriptionInputs.uv0
                //   VertexDescriptionInputs.ObjectSpaceNormal
                //   VertexDescriptionInputs.ObjectSpaceTangent
                //   VertexDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescription.Alpha
                //   SurfaceDescription.AlphaClipThreshold
                //   FragInputs.positionRWS
                //   FragInputs.tangentToWorld
                //   FragInputs.texCoord0
                //   AttributesMesh.normalOS
                //   AttributesMesh.tangentOS
                //   AttributesMesh.positionOS
                //   VaryingsMeshToPS.positionRWS
                //   VaryingsMeshToPS.tangentWS
                //   VaryingsMeshToPS.normalWS
                //   VaryingsMeshToPS.texCoord0
                //   AttributesMesh.uv0

        // this translates the new dependency tracker into the old preprocessor definitions for the existing HDRP shader code
        #define ATTRIBUTES_NEED_NORMAL
        #define ATTRIBUTES_NEED_TANGENT
        #define ATTRIBUTES_NEED_TEXCOORD0
        // #define ATTRIBUTES_NEED_TEXCOORD1
        // #define ATTRIBUTES_NEED_TEXCOORD2
        // #define ATTRIBUTES_NEED_TEXCOORD3
        // #define ATTRIBUTES_NEED_COLOR
        #define VARYINGS_NEED_POSITION_WS
        #define VARYINGS_NEED_TANGENT_TO_WORLD
        #define VARYINGS_NEED_TEXCOORD0
        // #define VARYINGS_NEED_TEXCOORD1
        // #define VARYINGS_NEED_TEXCOORD2
        // #define VARYINGS_NEED_TEXCOORD3
        // #define VARYINGS_NEED_COLOR
        // #define VARYINGS_NEED_CULLFACE
        // #define HAVE_MESH_MODIFICATION

        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------
    	

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"

        // Used by SceneSelectionPass
        int _ObjectId;
        int _PassValue;

        //-------------------------------------------------------------------------------------
        // Interpolator Packing And Struct Declarations
        //-------------------------------------------------------------------------------------
        // Generated Type: AttributesMesh
            struct AttributesMesh
            {
                float3 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
                float4 uv0 : TEXCOORD0; // optional
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : INSTANCEID_SEMANTIC;
                #endif // UNITY_ANY_INSTANCING_ENABLED
            };
        // Generated Type: VaryingsMeshToPS
            struct VaryingsMeshToPS
            {
                float4 positionCS : SV_POSITION;
                float3 positionRWS; // optional
                float3 normalWS; // optional
                float4 tangentWS; // optional
                float4 texCoord0; // optional
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif // UNITY_ANY_INSTANCING_ENABLED
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                #endif // defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            };
            
            // Generated Type: PackedVaryingsMeshToPS
            struct PackedVaryingsMeshToPS
            {
                float4 positionCS : SV_POSITION; // unpacked
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID; // unpacked
                #endif // conditional
                float3 interp00 : TEXCOORD0; // auto-packed
                float3 interp01 : TEXCOORD1; // auto-packed
                float4 interp02 : TEXCOORD2; // auto-packed
                float4 interp03 : TEXCOORD3; // auto-packed
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC; // unpacked
                #endif // conditional
            };
            
            // Packed Type: VaryingsMeshToPS
            PackedVaryingsMeshToPS PackVaryingsMeshToPS(VaryingsMeshToPS input)
            {
                PackedVaryingsMeshToPS output = (PackedVaryingsMeshToPS)0;
                output.positionCS = input.positionCS;
                output.interp00.xyz = input.positionRWS;
                output.interp01.xyz = input.normalWS;
                output.interp02.xyzw = input.tangentWS;
                output.interp03.xyzw = input.texCoord0;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif // conditional
                return output;
            }
            
            // Unpacked Type: VaryingsMeshToPS
            VaryingsMeshToPS UnpackVaryingsMeshToPS(PackedVaryingsMeshToPS input)
            {
                VaryingsMeshToPS output = (VaryingsMeshToPS)0;
                output.positionCS = input.positionCS;
                output.positionRWS = input.interp00.xyz;
                output.normalWS = input.interp01.xyz;
                output.tangentWS = input.interp02.xyzw;
                output.texCoord0 = input.interp03.xyzw;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif // conditional
                return output;
            }
        // Generated Type: VaryingsMeshToDS
            struct VaryingsMeshToDS
            {
                float3 positionRWS;
                float3 normalWS;
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif // UNITY_ANY_INSTANCING_ENABLED
            };
            
            // Generated Type: PackedVaryingsMeshToDS
            struct PackedVaryingsMeshToDS
            {
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID; // unpacked
                #endif // conditional
                float3 interp00 : TEXCOORD0; // auto-packed
                float3 interp01 : TEXCOORD1; // auto-packed
            };
            
            // Packed Type: VaryingsMeshToDS
            PackedVaryingsMeshToDS PackVaryingsMeshToDS(VaryingsMeshToDS input)
            {
                PackedVaryingsMeshToDS output = (PackedVaryingsMeshToDS)0;
                output.interp00.xyz = input.positionRWS;
                output.interp01.xyz = input.normalWS;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                return output;
            }
            
            // Unpacked Type: VaryingsMeshToDS
            VaryingsMeshToDS UnpackVaryingsMeshToDS(PackedVaryingsMeshToDS input)
            {
                VaryingsMeshToDS output = (VaryingsMeshToDS)0;
                output.positionRWS = input.interp00.xyz;
                output.normalWS = input.interp01.xyz;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                return output;
            }
        //-------------------------------------------------------------------------------------
        // End Interpolator Packing And Struct Declarations
        //-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------
        // Graph generated code
        //-------------------------------------------------------------------------------------
                // Shared Graph Properties (uniform inputs)


//Advanced Dissolve Keywords Start///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#pragma shader_feature_local   _AD_STATE_ENABLED
#pragma shader_feature_local _ _AD_CUTOUT_STANDARD_SOURCE_BASE_ALPHA				  _AD_CUTOUT_STANDARD_SOURCE_CUSTOM_MAP                     _AD_CUTOUT_STANDARD_SOURCE_TWO_CUSTOM_MAPS _AD_CUTOUT_STANDARD_SOURCE_THREE_CUSTOM_MAPS _AD_CUTOUT_STANDARD_SOURCE_USER_DEFINED
#pragma shader_feature_local _ _AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_TRIPLANAR _AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_SCREEN_SPACE
#pragma shader_feature_local _ _AD_CUTOUT_GEOMETRIC_TYPE_XYZ						  _AD_CUTOUT_GEOMETRIC_TYPE_PLANE                           _AD_CUTOUT_GEOMETRIC_TYPE_SPHERE           _AD_CUTOUT_GEOMETRIC_TYPE_CUBE               _AD_CUTOUT_GEOMETRIC_TYPE_CAPSULE       _AD_CUTOUT_GEOMETRIC_TYPE_CONE_SMOOTH
#pragma shader_feature_local _ _AD_CUTOUT_GEOMETRIC_COUNT_TWO					      _AD_CUTOUT_GEOMETRIC_COUNT_THREE                          _AD_CUTOUT_GEOMETRIC_COUNT_FOUR
#pragma shader_feature_local _ _AD_EDGE_BASE_SOURCE_CUTOUT_STANDARD                   _AD_EDGE_BASE_SOURCE_CUTOUT_GEOMETRIC                     _AD_EDGE_BASE_SOURCE_ALL
#pragma shader_feature_local _ _AD_EDGE_ADDITIONAL_COLOR_BASE_COLOR                   _AD_EDGE_ADDITIONAL_COLOR_CUSTOM_MAP                      _AD_EDGE_ADDITIONAL_COLOR_GRADIENT_MAP     _AD_EDGE_ADDITIONAL_COLOR_GRADIENT_COLOR     _AD_EDGE_ADDITIONAL_COLOR_USER_DEFINED
#pragma shader_feature_local _ _AD_GLOBAL_CONTROL_ID_ONE                              _AD_GLOBAL_CONTROL_ID_TWO                                 _AD_GLOBAL_CONTROL_ID_THREE                _AD_GLOBAL_CONTROL_ID_FOUR
//Advanced Dissolve Keywords End/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


#define ADVANCED_DISSOLVE_SHADER_GRAPH
#define ADVANCED_DISSOLVE_HIGH_DEFINITION_RENDER_PIPELINE
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Defines.cginc"
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                    CBUFFER_START(UnityPerMaterial)
        float4 _BaseColor;
        float4 _EmissiveColor;
        float _EmissiveIntensity;
        float _EmissiveExposureWeight;
        CBUFFER_END
        TEXTURE2D(_BaseColorMap); SAMPLER(sampler_BaseColorMap); float4 _BaseColorMap_TexelSize;
        TEXTURE2D(_EmissiveColorMap); SAMPLER(sampler_EmissiveColorMap); float4 _EmissiveColorMap_TexelSize;
        SAMPLER(_SampleTexture2D_9AB23BAE_Sampler_3_Linear_Repeat);

                // Pixel Graph Inputs
                    struct SurfaceDescriptionInputs
                    {
                        float3 ObjectSpaceNormal; // optional
                        float3 WorldSpaceNormal; // optional
                        float3 ObjectSpacePosition; // optional
                        float3 WorldSpacePosition; // optional
                        float3 AbsoluteWorldSpacePosition; // optional
                        float4 uv0; // optional
                    };
                // Pixel Graph Outputs
                    struct SurfaceDescription
    {
        float Alpha;
        float AlphaClipThreshold;
    };

                // Shared Graph Node Functions
                
        void AdvancedDissolveShaderGraphFunction_float(float2 UV, float3 PositionOS, float3 PositionWS, float3 PositionWSAbsolute, float3 NormalOS, float3 NormalWS, float CustomCutout, float4 CustomColor, out float Value)
        {
            Value = 0;
        }

        struct Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab
        {
            float3 ObjectSpaceNormal;
            float3 WorldSpaceNormal;
            float3 ObjectSpacePosition;
            float3 WorldSpacePosition;
            float3 AbsoluteWorldSpacePosition;
            half4 uv0;
        };

        void SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(float Vector1_9E44E7D0, float4 Color_9C152E30, Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab IN, out float Out_3)
        {
            float4 _UV_B7DC59D1_Out_0 = IN.uv0;
            float _Property_AA10DA06_Out_0 = Vector1_9E44E7D0;
            float4 _Property_D5854A9E_Out_0 = Color_9C152E30;
            float _CustomFunction_7278F8D6_Value_7;
            AdvancedDissolveShaderGraphFunction_float((_UV_B7DC59D1_Out_0.xy), IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, _Property_AA10DA06_Out_0, _Property_D5854A9E_Out_0, _CustomFunction_7278F8D6_Value_7);
            Out_3 = _CustomFunction_7278F8D6_Value_7;
        }

                // Pixel Graph Evaluation


//Advanced Dissolve
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Core.cginc"


                    SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float4 _SampleTexture2D_9AB23BAE_RGBA_0 = SAMPLE_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, IN.uv0.xy);
        float _SampleTexture2D_9AB23BAE_R_4 = _SampleTexture2D_9AB23BAE_RGBA_0.r;
        float _SampleTexture2D_9AB23BAE_G_5 = _SampleTexture2D_9AB23BAE_RGBA_0.g;
        float _SampleTexture2D_9AB23BAE_B_6 = _SampleTexture2D_9AB23BAE_RGBA_0.b;
        float _SampleTexture2D_9AB23BAE_A_7 = _SampleTexture2D_9AB23BAE_RGBA_0.a;
        float _Split_609E0B65_R_1 = _SampleTexture2D_9AB23BAE_RGBA_0[0];
        float _Split_609E0B65_G_2 = _SampleTexture2D_9AB23BAE_RGBA_0[1];
        float _Split_609E0B65_B_3 = _SampleTexture2D_9AB23BAE_RGBA_0[2];
        float _Split_609E0B65_A_4 = _SampleTexture2D_9AB23BAE_RGBA_0[3];
        Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab _AdvancedDissolve_B8B8503F;
        _AdvancedDissolve_B8B8503F.ObjectSpaceNormal = IN.ObjectSpaceNormal;
        _AdvancedDissolve_B8B8503F.WorldSpaceNormal = IN.WorldSpaceNormal;
        _AdvancedDissolve_B8B8503F.ObjectSpacePosition = IN.ObjectSpacePosition;
        _AdvancedDissolve_B8B8503F.WorldSpacePosition = IN.WorldSpacePosition;
        _AdvancedDissolve_B8B8503F.AbsoluteWorldSpacePosition = IN.AbsoluteWorldSpacePosition;
        _AdvancedDissolve_B8B8503F.uv0 = IN.uv0;
        float _AdvancedDissolve_B8B8503F_Out_3;
        SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(0, float4 (0, 0, 0, 1), _AdvancedDissolve_B8B8503F, _AdvancedDissolve_B8B8503F_Out_3);
        surface.Alpha = _Split_609E0B65_A_4;
        surface.AlphaClipThreshold = _AdvancedDissolve_B8B8503F_Out_3;


//MotionVectors
AdvancedDissolveShaderGraph(IN.uv0.xy, IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, 0, 1, surface.Alpha, surface.AlphaClipThreshold);


return surface;

    }

        //-------------------------------------------------------------------------------------
        // End graph generated code
        //-------------------------------------------------------------------------------------

    // $include("VertexAnimation.template.hlsl")

    //-------------------------------------------------------------------------------------
    // TEMPLATE INCLUDE : SharedCode.template.hlsl
    //-------------------------------------------------------------------------------------

    #if !defined(SHADER_STAGE_RAY_TRACING)
        FragInputs BuildFragInputs(VaryingsMeshToPS input)
        {
            FragInputs output;
            ZERO_INITIALIZE(FragInputs, output);

            // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
            // TODO: this is a really poor workaround, but the variable is used in a bunch of places
            // to compute normals which are then passed on elsewhere to compute other values...
            output.tangentToWorld = k_identity3x3;
            output.positionSS = input.positionCS;       // input.positionCS is SV_Position

            output.positionRWS = input.positionRWS;
            output.tangentToWorld = BuildTangentToWorld(input.tangentWS, input.normalWS);
            output.texCoord0 = input.texCoord0;
            // output.texCoord1 = input.texCoord1;
            // output.texCoord2 = input.texCoord2;
            // output.texCoord3 = input.texCoord3;
            // output.color = input.color;
            #if _DOUBLESIDED_ON && SHADER_STAGE_FRAGMENT
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #elif SHADER_STAGE_FRAGMENT
            // output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #endif // SHADER_STAGE_FRAGMENT

            return output;
        }
    #endif
        SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
        {
            SurfaceDescriptionInputs output;
            ZERO_INITIALIZE(SurfaceDescriptionInputs, output);

            output.WorldSpaceNormal =            input.tangentToWorld[2].xyz;	// normal was already normalized in BuildTangentToWorld()
            output.ObjectSpaceNormal =           normalize(mul(output.WorldSpaceNormal, (float3x3) UNITY_MATRIX_M));           // transposed multiplication by inverse matrix to handle normal scale
            // output.ViewSpaceNormal =             mul(output.WorldSpaceNormal, (float3x3) UNITY_MATRIX_I_V);         // transposed multiplication by inverse matrix to handle normal scale
            // output.TangentSpaceNormal =          float3(0.0f, 0.0f, 1.0f);
            // output.WorldSpaceTangent =           input.tangentToWorld[0].xyz;
            // output.ObjectSpaceTangent =          TransformWorldToObjectDir(output.WorldSpaceTangent);
            // output.ViewSpaceTangent =            TransformWorldToViewDir(output.WorldSpaceTangent);
            // output.TangentSpaceTangent =         float3(1.0f, 0.0f, 0.0f);
            // output.WorldSpaceBiTangent =         input.tangentToWorld[1].xyz;
            // output.ObjectSpaceBiTangent =        TransformWorldToObjectDir(output.WorldSpaceBiTangent);
            // output.ViewSpaceBiTangent =          TransformWorldToViewDir(output.WorldSpaceBiTangent);
            // output.TangentSpaceBiTangent =       float3(0.0f, 1.0f, 0.0f);
            // output.WorldSpaceViewDirection =     normalize(viewWS);
            // output.ObjectSpaceViewDirection =    TransformWorldToObjectDir(output.WorldSpaceViewDirection);
            // output.ViewSpaceViewDirection =      TransformWorldToViewDir(output.WorldSpaceViewDirection);
            // float3x3 tangentSpaceTransform =     float3x3(output.WorldSpaceTangent,output.WorldSpaceBiTangent,output.WorldSpaceNormal);
            // output.TangentSpaceViewDirection =   mul(tangentSpaceTransform, output.WorldSpaceViewDirection);
            output.WorldSpacePosition =          input.positionRWS;
            output.ObjectSpacePosition =         TransformWorldToObject(input.positionRWS);
            // output.ViewSpacePosition =           TransformWorldToView(input.positionRWS);
            // output.TangentSpacePosition =        float3(0.0f, 0.0f, 0.0f);
            output.AbsoluteWorldSpacePosition =  GetAbsolutePositionWS(input.positionRWS);
            // output.ScreenPosition =              ComputeScreenPos(TransformWorldToHClip(input.positionRWS), _ProjectionParams.x);
            output.uv0 =                         input.texCoord0;
            // output.uv1 =                         input.texCoord1;
            // output.uv2 =                         input.texCoord2;
            // output.uv3 =                         input.texCoord3;
            // output.VertexColor =                 input.color;
            // output.FaceSign =                    input.isFrontFace;
            // output.TimeParameters =              _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value

            return output;
        }

    #if !defined(SHADER_STAGE_RAY_TRACING)

        // existing HDRP code uses the combined function to go directly from packed to frag inputs
        FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
        {
            UNITY_SETUP_INSTANCE_ID(input);
            VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
            return BuildFragInputs(unpacked);
        }
    #endif

    //-------------------------------------------------------------------------------------
    // END TEMPLATE INCLUDE : SharedCode.template.hlsl
    //-------------------------------------------------------------------------------------


        void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
        {
            // setup defaults -- these are used if the graph doesn't output a value
            ZERO_INITIALIZE(SurfaceData, surfaceData);

            // copy across graph values, if defined
            // surfaceData.color = surfaceDescription.Color;

    #if defined(DEBUG_DISPLAY)
            if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
            {
                // TODO
            }
    #endif
        }

        void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData)
        {
            SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
            SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);

            // Perform alpha test very early to save performance (a killed pixel will not sample textures)
            // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
            DoAlphaTest(surfaceDescription.Alpha, surfaceDescription.AlphaClipThreshold);

            BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);

            // Builtin Data
            ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
            builtinData.opacity = surfaceDescription.Alpha;
        }

        //-------------------------------------------------------------------------------------
        // Pass Includes
        //-------------------------------------------------------------------------------------
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassMotionVectors.hlsl"
        //-------------------------------------------------------------------------------------
        // End Pass Includes
        //-------------------------------------------------------------------------------------

        ENDHLSL
    }

        Pass
    {
        // based on UnlitPass.template
        Name "ForwardOnly"
        Tags { "LightMode" = "ForwardOnly" }

        //-------------------------------------------------------------------------------------
        // Render Modes (Blend, Cull, ZTest, Stencil, etc)
        //-------------------------------------------------------------------------------------
        Blend One Zero, One Zero

        Cull Off

        
        ZWrite On

        // Stencil setup
    Stencil
    {
       WriteMask 6
       Ref  0
       Comp Always
       Pass Replace
    }

        
        //-------------------------------------------------------------------------------------
        // End Render Modes
        //-------------------------------------------------------------------------------------

        HLSLPROGRAM

        #pragma target 4.5
        #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
        //#pragma enable_d3d11_debug_symbols

        //enable GPU instancing support
        #pragma multi_compile_instancing

        //-------------------------------------------------------------------------------------
        // Variant Definitions (active field translations to HDRP defines)
        //-------------------------------------------------------------------------------------
        // #define _SURFACE_TYPE_TRANSPARENT 1
        // #define _BLENDMODE_ALPHA 1
        // #define _BLENDMODE_ADD 1
        // #define _BLENDMODE_PRE_MULTIPLY 1
        // #define _ADD_PRECOMPUTED_VELOCITY

        //-------------------------------------------------------------------------------------
        // End Variant Definitions
        //-------------------------------------------------------------------------------------

        #pragma vertex Vert
        #pragma fragment Frag

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"

        //-------------------------------------------------------------------------------------
        // Defines
        //-------------------------------------------------------------------------------------
                // Shared Graph Keywords
                #define SHADERPASS SHADERPASS_FORWARD_UNLIT
                #pragma multi_compile _ DEBUG_DISPLAY
                // ACTIVE FIELDS:
                //   AlphaTest
                //   SurfaceDescriptionInputs.ObjectSpaceNormal
                //   SurfaceDescriptionInputs.WorldSpaceNormal
                //   SurfaceDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescriptionInputs.WorldSpacePosition
                //   SurfaceDescriptionInputs.AbsoluteWorldSpacePosition
                //   SurfaceDescriptionInputs.uv0
                //   VertexDescriptionInputs.ObjectSpaceNormal
                //   VertexDescriptionInputs.ObjectSpaceTangent
                //   VertexDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescription.Color
                //   SurfaceDescription.Alpha
                //   SurfaceDescription.AlphaClipThreshold
                //   FragInputs.tangentToWorld
                //   FragInputs.positionRWS
                //   FragInputs.texCoord0
                //   AttributesMesh.normalOS
                //   AttributesMesh.tangentOS
                //   AttributesMesh.positionOS
                //   VaryingsMeshToPS.tangentWS
                //   VaryingsMeshToPS.normalWS
                //   VaryingsMeshToPS.positionRWS
                //   VaryingsMeshToPS.texCoord0
                //   AttributesMesh.uv0

        // this translates the new dependency tracker into the old preprocessor definitions for the existing HDRP shader code
        #define ATTRIBUTES_NEED_NORMAL
        #define ATTRIBUTES_NEED_TANGENT
        #define ATTRIBUTES_NEED_TEXCOORD0
        // #define ATTRIBUTES_NEED_TEXCOORD1
        // #define ATTRIBUTES_NEED_TEXCOORD2
        // #define ATTRIBUTES_NEED_TEXCOORD3
        // #define ATTRIBUTES_NEED_COLOR
        #define VARYINGS_NEED_POSITION_WS
        #define VARYINGS_NEED_TANGENT_TO_WORLD
        #define VARYINGS_NEED_TEXCOORD0
        // #define VARYINGS_NEED_TEXCOORD1
        // #define VARYINGS_NEED_TEXCOORD2
        // #define VARYINGS_NEED_TEXCOORD3
        // #define VARYINGS_NEED_COLOR
        // #define VARYINGS_NEED_CULLFACE
        // #define HAVE_MESH_MODIFICATION

        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------
    	

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"

        // Used by SceneSelectionPass
        int _ObjectId;
        int _PassValue;

        //-------------------------------------------------------------------------------------
        // Interpolator Packing And Struct Declarations
        //-------------------------------------------------------------------------------------
        // Generated Type: AttributesMesh
            struct AttributesMesh
            {
                float3 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
                float4 uv0 : TEXCOORD0; // optional
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : INSTANCEID_SEMANTIC;
                #endif // UNITY_ANY_INSTANCING_ENABLED
            };
        // Generated Type: VaryingsMeshToPS
            struct VaryingsMeshToPS
            {
                float4 positionCS : SV_POSITION;
                float3 positionRWS; // optional
                float3 normalWS; // optional
                float4 tangentWS; // optional
                float4 texCoord0; // optional
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif // UNITY_ANY_INSTANCING_ENABLED
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                #endif // defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            };
            
            // Generated Type: PackedVaryingsMeshToPS
            struct PackedVaryingsMeshToPS
            {
                float4 positionCS : SV_POSITION; // unpacked
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID; // unpacked
                #endif // conditional
                float3 interp00 : TEXCOORD0; // auto-packed
                float3 interp01 : TEXCOORD1; // auto-packed
                float4 interp02 : TEXCOORD2; // auto-packed
                float4 interp03 : TEXCOORD3; // auto-packed
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC; // unpacked
                #endif // conditional
            };
            
            // Packed Type: VaryingsMeshToPS
            PackedVaryingsMeshToPS PackVaryingsMeshToPS(VaryingsMeshToPS input)
            {
                PackedVaryingsMeshToPS output = (PackedVaryingsMeshToPS)0;
                output.positionCS = input.positionCS;
                output.interp00.xyz = input.positionRWS;
                output.interp01.xyz = input.normalWS;
                output.interp02.xyzw = input.tangentWS;
                output.interp03.xyzw = input.texCoord0;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif // conditional
                return output;
            }
            
            // Unpacked Type: VaryingsMeshToPS
            VaryingsMeshToPS UnpackVaryingsMeshToPS(PackedVaryingsMeshToPS input)
            {
                VaryingsMeshToPS output = (VaryingsMeshToPS)0;
                output.positionCS = input.positionCS;
                output.positionRWS = input.interp00.xyz;
                output.normalWS = input.interp01.xyz;
                output.tangentWS = input.interp02.xyzw;
                output.texCoord0 = input.interp03.xyzw;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif // conditional
                return output;
            }
        // Generated Type: VaryingsMeshToDS
            struct VaryingsMeshToDS
            {
                float3 positionRWS;
                float3 normalWS;
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif // UNITY_ANY_INSTANCING_ENABLED
            };
            
            // Generated Type: PackedVaryingsMeshToDS
            struct PackedVaryingsMeshToDS
            {
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID; // unpacked
                #endif // conditional
                float3 interp00 : TEXCOORD0; // auto-packed
                float3 interp01 : TEXCOORD1; // auto-packed
            };
            
            // Packed Type: VaryingsMeshToDS
            PackedVaryingsMeshToDS PackVaryingsMeshToDS(VaryingsMeshToDS input)
            {
                PackedVaryingsMeshToDS output = (PackedVaryingsMeshToDS)0;
                output.interp00.xyz = input.positionRWS;
                output.interp01.xyz = input.normalWS;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                return output;
            }
            
            // Unpacked Type: VaryingsMeshToDS
            VaryingsMeshToDS UnpackVaryingsMeshToDS(PackedVaryingsMeshToDS input)
            {
                VaryingsMeshToDS output = (VaryingsMeshToDS)0;
                output.positionRWS = input.interp00.xyz;
                output.normalWS = input.interp01.xyz;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif // conditional
                return output;
            }
        //-------------------------------------------------------------------------------------
        // End Interpolator Packing And Struct Declarations
        //-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------
        // Graph generated code
        //-------------------------------------------------------------------------------------
                // Shared Graph Properties (uniform inputs)


//Advanced Dissolve Keywords Start///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#pragma shader_feature_local   _AD_STATE_ENABLED
#pragma shader_feature_local _ _AD_CUTOUT_STANDARD_SOURCE_BASE_ALPHA				  _AD_CUTOUT_STANDARD_SOURCE_CUSTOM_MAP                     _AD_CUTOUT_STANDARD_SOURCE_TWO_CUSTOM_MAPS _AD_CUTOUT_STANDARD_SOURCE_THREE_CUSTOM_MAPS _AD_CUTOUT_STANDARD_SOURCE_USER_DEFINED
#pragma shader_feature_local _ _AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_TRIPLANAR _AD_CUTOUT_STANDARD_SOURCE_MAPS_MAPPING_TYPE_SCREEN_SPACE
#pragma shader_feature_local _ _AD_CUTOUT_GEOMETRIC_TYPE_XYZ						  _AD_CUTOUT_GEOMETRIC_TYPE_PLANE                           _AD_CUTOUT_GEOMETRIC_TYPE_SPHERE           _AD_CUTOUT_GEOMETRIC_TYPE_CUBE               _AD_CUTOUT_GEOMETRIC_TYPE_CAPSULE       _AD_CUTOUT_GEOMETRIC_TYPE_CONE_SMOOTH
#pragma shader_feature_local _ _AD_CUTOUT_GEOMETRIC_COUNT_TWO					      _AD_CUTOUT_GEOMETRIC_COUNT_THREE                          _AD_CUTOUT_GEOMETRIC_COUNT_FOUR
#pragma shader_feature_local _ _AD_EDGE_BASE_SOURCE_CUTOUT_STANDARD                   _AD_EDGE_BASE_SOURCE_CUTOUT_GEOMETRIC                     _AD_EDGE_BASE_SOURCE_ALL
#pragma shader_feature_local _ _AD_EDGE_ADDITIONAL_COLOR_BASE_COLOR                   _AD_EDGE_ADDITIONAL_COLOR_CUSTOM_MAP                      _AD_EDGE_ADDITIONAL_COLOR_GRADIENT_MAP     _AD_EDGE_ADDITIONAL_COLOR_GRADIENT_COLOR     _AD_EDGE_ADDITIONAL_COLOR_USER_DEFINED
#pragma shader_feature_local _ _AD_GLOBAL_CONTROL_ID_ONE                              _AD_GLOBAL_CONTROL_ID_TWO                                 _AD_GLOBAL_CONTROL_ID_THREE                _AD_GLOBAL_CONTROL_ID_FOUR
//Advanced Dissolve Keywords End/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


#define ADVANCED_DISSOLVE_SHADER_GRAPH
#define ADVANCED_DISSOLVE_HIGH_DEFINITION_RENDER_PIPELINE
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Defines.cginc"
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                    CBUFFER_START(UnityPerMaterial)
        float4 _BaseColor;
        float4 _EmissiveColor;
        float _EmissiveIntensity;
        float _EmissiveExposureWeight;
        CBUFFER_END
        TEXTURE2D(_BaseColorMap); SAMPLER(sampler_BaseColorMap); float4 _BaseColorMap_TexelSize;
        TEXTURE2D(_EmissiveColorMap); SAMPLER(sampler_EmissiveColorMap); float4 _EmissiveColorMap_TexelSize;
        SAMPLER(_SampleTexture2D_9AB23BAE_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_5557C033_Sampler_3_Linear_Repeat);

                // Pixel Graph Inputs
                    struct SurfaceDescriptionInputs
                    {
                        float3 ObjectSpaceNormal; // optional
                        float3 WorldSpaceNormal; // optional
                        float3 ObjectSpacePosition; // optional
                        float3 WorldSpacePosition; // optional
                        float3 AbsoluteWorldSpacePosition; // optional
                        float4 uv0; // optional
                    };
                // Pixel Graph Outputs
                    struct SurfaceDescription
    {
        float3 Color;
        float Alpha;
        float AlphaClipThreshold;
    };

                // Shared Graph Node Functions
                
        void Unity_Multiply_float(float4 A, float4 B, out float4 Out)
        {
            Out = A * B;
        }

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/CommonLighting.hlsl"
        float3 Unity_HDRP_GetEmissionHDRColor_float(float3 ldrColor, float luminanceIntensity, float exposureWeight, float inverseCurrentExposureMultiplier)
        {
            float3 hdrColor = ldrColor * luminanceIntensity;

            // Inverse pre-expose using _EmissiveExposureWeight weight
            hdrColor = lerp(hdrColor * inverseCurrentExposureMultiplier, hdrColor, exposureWeight);
            return hdrColor;
        }

        void Unity_Add_float3(float3 A, float3 B, out float3 Out)
        {
            Out = A + B;
        }

        void AdvancedDissolveShaderGraphFunction_float(float2 UV, float3 PositionOS, float3 PositionWS, float3 PositionWSAbsolute, float3 NormalOS, float3 NormalWS, float CustomCutout, float4 CustomColor, out float Value)
        {
            Value = 0;
        }

        struct Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab
        {
            float3 ObjectSpaceNormal;
            float3 WorldSpaceNormal;
            float3 ObjectSpacePosition;
            float3 WorldSpacePosition;
            float3 AbsoluteWorldSpacePosition;
            half4 uv0;
        };

        void SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(float Vector1_9E44E7D0, float4 Color_9C152E30, Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab IN, out float Out_3)
        {
            float4 _UV_B7DC59D1_Out_0 = IN.uv0;
            float _Property_AA10DA06_Out_0 = Vector1_9E44E7D0;
            float4 _Property_D5854A9E_Out_0 = Color_9C152E30;
            float _CustomFunction_7278F8D6_Value_7;
            AdvancedDissolveShaderGraphFunction_float((_UV_B7DC59D1_Out_0.xy), IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, _Property_AA10DA06_Out_0, _Property_D5854A9E_Out_0, _CustomFunction_7278F8D6_Value_7);
            Out_3 = _CustomFunction_7278F8D6_Value_7;
        }

                // Pixel Graph Evaluation


//Advanced Dissolve
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Core.cginc"


                    SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float4 _Property_F9A284E6_Out_0 = _BaseColor;
        float4 _SampleTexture2D_9AB23BAE_RGBA_0 = SAMPLE_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, IN.uv0.xy);
        float _SampleTexture2D_9AB23BAE_R_4 = _SampleTexture2D_9AB23BAE_RGBA_0.r;
        float _SampleTexture2D_9AB23BAE_G_5 = _SampleTexture2D_9AB23BAE_RGBA_0.g;
        float _SampleTexture2D_9AB23BAE_B_6 = _SampleTexture2D_9AB23BAE_RGBA_0.b;
        float _SampleTexture2D_9AB23BAE_A_7 = _SampleTexture2D_9AB23BAE_RGBA_0.a;
        float4 _Multiply_84D535AA_Out_2;
        Unity_Multiply_float(_Property_F9A284E6_Out_0, _SampleTexture2D_9AB23BAE_RGBA_0, _Multiply_84D535AA_Out_2);
        float4 _Property_B1BF0B23_Out_0 = _EmissiveColor;
        float4 _SampleTexture2D_5557C033_RGBA_0 = SAMPLE_TEXTURE2D(_EmissiveColorMap, sampler_EmissiveColorMap, IN.uv0.xy);
        float _SampleTexture2D_5557C033_R_4 = _SampleTexture2D_5557C033_RGBA_0.r;
        float _SampleTexture2D_5557C033_G_5 = _SampleTexture2D_5557C033_RGBA_0.g;
        float _SampleTexture2D_5557C033_B_6 = _SampleTexture2D_5557C033_RGBA_0.b;
        float _SampleTexture2D_5557C033_A_7 = _SampleTexture2D_5557C033_RGBA_0.a;
        float4 _Multiply_B1DF16FF_Out_2;
        Unity_Multiply_float(_Property_B1BF0B23_Out_0, _SampleTexture2D_5557C033_RGBA_0, _Multiply_B1DF16FF_Out_2);
        float _Property_61BFA42D_Out_0 = _EmissiveIntensity;
        float _Property_8A7F8B80_Out_0 = _EmissiveExposureWeight;
        #ifdef SHADERGRAPH_PREVIEW
        float inverseExposureMultiplier = 1.0;
        #else
        float inverseExposureMultiplier = GetInverseCurrentExposureMultiplier();
        #endif
        float3 _EmissionNode_FAEA9631_Output_0 = Unity_HDRP_GetEmissionHDRColor_float((_Multiply_B1DF16FF_Out_2.xyz).xyz, ConvertEvToLuminance(_Property_61BFA42D_Out_0), _Property_8A7F8B80_Out_0, inverseExposureMultiplier);
        float3 _Add_B5FD95AE_Out_2;
        Unity_Add_float3((_Multiply_84D535AA_Out_2.xyz), _EmissionNode_FAEA9631_Output_0, _Add_B5FD95AE_Out_2);
        float _Split_609E0B65_R_1 = _SampleTexture2D_9AB23BAE_RGBA_0[0];
        float _Split_609E0B65_G_2 = _SampleTexture2D_9AB23BAE_RGBA_0[1];
        float _Split_609E0B65_B_3 = _SampleTexture2D_9AB23BAE_RGBA_0[2];
        float _Split_609E0B65_A_4 = _SampleTexture2D_9AB23BAE_RGBA_0[3];
        Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab _AdvancedDissolve_B8B8503F;
        _AdvancedDissolve_B8B8503F.ObjectSpaceNormal = IN.ObjectSpaceNormal;
        _AdvancedDissolve_B8B8503F.WorldSpaceNormal = IN.WorldSpaceNormal;
        _AdvancedDissolve_B8B8503F.ObjectSpacePosition = IN.ObjectSpacePosition;
        _AdvancedDissolve_B8B8503F.WorldSpacePosition = IN.WorldSpacePosition;
        _AdvancedDissolve_B8B8503F.AbsoluteWorldSpacePosition = IN.AbsoluteWorldSpacePosition;
        _AdvancedDissolve_B8B8503F.uv0 = IN.uv0;
        float _AdvancedDissolve_B8B8503F_Out_3;
        SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(0, float4 (0, 0, 0, 1), _AdvancedDissolve_B8B8503F, _AdvancedDissolve_B8B8503F_Out_3);
        surface.Color = _Add_B5FD95AE_Out_2;
        surface.Alpha = _Split_609E0B65_A_4;
        surface.AlphaClipThreshold = _AdvancedDissolve_B8B8503F_Out_3;


//ForwardOnly
AdvancedDissolveShaderGraph(IN.uv0.xy, IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, 0, 1, surface.Color, surface.Alpha, surface.AlphaClipThreshold);


return surface;

    }

        //-------------------------------------------------------------------------------------
        // End graph generated code
        //-------------------------------------------------------------------------------------

    // $include("VertexAnimation.template.hlsl")

    //-------------------------------------------------------------------------------------
    // TEMPLATE INCLUDE : SharedCode.template.hlsl
    //-------------------------------------------------------------------------------------

    #if !defined(SHADER_STAGE_RAY_TRACING)
        FragInputs BuildFragInputs(VaryingsMeshToPS input)
        {
            FragInputs output;
            ZERO_INITIALIZE(FragInputs, output);

            // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
            // TODO: this is a really poor workaround, but the variable is used in a bunch of places
            // to compute normals which are then passed on elsewhere to compute other values...
            output.tangentToWorld = k_identity3x3;
            output.positionSS = input.positionCS;       // input.positionCS is SV_Position

            output.positionRWS = input.positionRWS;
            output.tangentToWorld = BuildTangentToWorld(input.tangentWS, input.normalWS);
            output.texCoord0 = input.texCoord0;
            // output.texCoord1 = input.texCoord1;
            // output.texCoord2 = input.texCoord2;
            // output.texCoord3 = input.texCoord3;
            // output.color = input.color;
            #if _DOUBLESIDED_ON && SHADER_STAGE_FRAGMENT
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #elif SHADER_STAGE_FRAGMENT
            // output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #endif // SHADER_STAGE_FRAGMENT

            return output;
        }
    #endif
        SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
        {
            SurfaceDescriptionInputs output;
            ZERO_INITIALIZE(SurfaceDescriptionInputs, output);

            output.WorldSpaceNormal =            input.tangentToWorld[2].xyz;	// normal was already normalized in BuildTangentToWorld()
            output.ObjectSpaceNormal =           normalize(mul(output.WorldSpaceNormal, (float3x3) UNITY_MATRIX_M));           // transposed multiplication by inverse matrix to handle normal scale
            // output.ViewSpaceNormal =             mul(output.WorldSpaceNormal, (float3x3) UNITY_MATRIX_I_V);         // transposed multiplication by inverse matrix to handle normal scale
            // output.TangentSpaceNormal =          float3(0.0f, 0.0f, 1.0f);
            // output.WorldSpaceTangent =           input.tangentToWorld[0].xyz;
            // output.ObjectSpaceTangent =          TransformWorldToObjectDir(output.WorldSpaceTangent);
            // output.ViewSpaceTangent =            TransformWorldToViewDir(output.WorldSpaceTangent);
            // output.TangentSpaceTangent =         float3(1.0f, 0.0f, 0.0f);
            // output.WorldSpaceBiTangent =         input.tangentToWorld[1].xyz;
            // output.ObjectSpaceBiTangent =        TransformWorldToObjectDir(output.WorldSpaceBiTangent);
            // output.ViewSpaceBiTangent =          TransformWorldToViewDir(output.WorldSpaceBiTangent);
            // output.TangentSpaceBiTangent =       float3(0.0f, 1.0f, 0.0f);
            // output.WorldSpaceViewDirection =     normalize(viewWS);
            // output.ObjectSpaceViewDirection =    TransformWorldToObjectDir(output.WorldSpaceViewDirection);
            // output.ViewSpaceViewDirection =      TransformWorldToViewDir(output.WorldSpaceViewDirection);
            // float3x3 tangentSpaceTransform =     float3x3(output.WorldSpaceTangent,output.WorldSpaceBiTangent,output.WorldSpaceNormal);
            // output.TangentSpaceViewDirection =   mul(tangentSpaceTransform, output.WorldSpaceViewDirection);
            output.WorldSpacePosition =          input.positionRWS;
            output.ObjectSpacePosition =         TransformWorldToObject(input.positionRWS);
            // output.ViewSpacePosition =           TransformWorldToView(input.positionRWS);
            // output.TangentSpacePosition =        float3(0.0f, 0.0f, 0.0f);
            output.AbsoluteWorldSpacePosition =  GetAbsolutePositionWS(input.positionRWS);
            // output.ScreenPosition =              ComputeScreenPos(TransformWorldToHClip(input.positionRWS), _ProjectionParams.x);
            output.uv0 =                         input.texCoord0;
            // output.uv1 =                         input.texCoord1;
            // output.uv2 =                         input.texCoord2;
            // output.uv3 =                         input.texCoord3;
            // output.VertexColor =                 input.color;
            // output.FaceSign =                    input.isFrontFace;
            // output.TimeParameters =              _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value

            return output;
        }

    #if !defined(SHADER_STAGE_RAY_TRACING)

        // existing HDRP code uses the combined function to go directly from packed to frag inputs
        FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
        {
            UNITY_SETUP_INSTANCE_ID(input);
            VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
            return BuildFragInputs(unpacked);
        }
    #endif

    //-------------------------------------------------------------------------------------
    // END TEMPLATE INCLUDE : SharedCode.template.hlsl
    //-------------------------------------------------------------------------------------


        void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
        {
            // setup defaults -- these are used if the graph doesn't output a value
            ZERO_INITIALIZE(SurfaceData, surfaceData);

            // copy across graph values, if defined
            surfaceData.color = surfaceDescription.Color;

    #if defined(DEBUG_DISPLAY)
            if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
            {
                // TODO
            }
    #endif
        }

        void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData)
        {
            SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
            SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);

            // Perform alpha test very early to save performance (a killed pixel will not sample textures)
            // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
            DoAlphaTest(surfaceDescription.Alpha, surfaceDescription.AlphaClipThreshold);

            BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);

            // Builtin Data
            ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
            builtinData.opacity = surfaceDescription.Alpha;
        }

        //-------------------------------------------------------------------------------------
        // Pass Includes
        //-------------------------------------------------------------------------------------
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassForwardUnlit.hlsl"
        //-------------------------------------------------------------------------------------
        // End Pass Includes
        //-------------------------------------------------------------------------------------

        ENDHLSL
    }

    }
    //CustomEditor "UnityEditor.Rendering.HighDefinition.UnlitUI"
    CustomEditor "AmazingAssets.AdvancedDissolveEditor.ShaderGraph.DefaultShaderGraphGUI"
    FallBack "Hidden/Shader Graph/FallbackError"
}

