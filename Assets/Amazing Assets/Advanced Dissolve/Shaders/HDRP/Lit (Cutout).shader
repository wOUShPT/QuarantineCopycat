Shader "Amazing Assets/Advanced Dissolve/Shader Graph/Lit (Cutout)"
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
        Vector1_FCB2FF33("Cutout", Range(0, 1)) = 0.5
        _Metallic("Metallic", Range(0, 1)) = 0.5
        _Smoothness("Smoothness", Range(0, 1)) = 0
        [NoScaleOffset]_MaskMap("Mask Map (R) Metallic, (G) AO, (A) Smoothness", 2D) = "white" {}
        [NoScaleOffset]_NormalMap("Bump Map", 2D) = "bump" {}
        _EmissiveColor("Emission Color", Color) = (0, 0, 0, 0)
        _EmissiveIntensity("Emission Intensity", Float) = 0
        _EmissiveExposureWeight("Emission Exposure Weight", Range(0, 1)) = 1
        [NoScaleOffset]_EmissiveColorMap("Emission Map", 2D) = "white" {}
    }
    SubShader
    {
        Tags
    {
        "RenderPipeline"="HDRenderPipeline"
        "RenderType"="HDLitShader"
        "Queue"="AlphaTest+0"
    }

        Pass
    {
        // based on HDPBRPass.template
        Name "ShadowCaster"
        Tags { "LightMode" = "ShadowCaster" }

        //-------------------------------------------------------------------------------------
        // Render Modes (Blend, Cull, ZTest, Stencil, etc)
        //-------------------------------------------------------------------------------------
        Blend One Zero

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

        #pragma multi_compile_instancing
        #pragma instancing_options renderinglayer

        #pragma multi_compile _ LOD_FADE_CROSSFADE

        //-------------------------------------------------------------------------------------
        // Graph Defines
        //-------------------------------------------------------------------------------------
                // Shared Graph Keywords
                #define SHADERPASS SHADERPASS_SHADOWS
                // ACTIVE FIELDS:
                //   DoubleSided
                //   DoubleSided.Mirror
                //   FragInputs.isFrontFace
                //   AlphaTest
                //   features.NormalDropOffTS
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
                //   VaryingsMeshToPS.cullFace
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
        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------
        // Variant Definitions (active field translations to HDRP defines)
        //-------------------------------------------------------------------------------------

        // #define _MATERIAL_FEATURE_SPECULAR_COLOR 1
        // #define _SURFACE_TYPE_TRANSPARENT 1
        // #define _BLENDMODE_ALPHA 1
        // #define _BLENDMODE_ADD 1
        // #define _BLENDMODE_PRE_MULTIPLY 1
        #define _DOUBLESIDED_ON 1
        #define _NORMAL_DROPOFF_TS	1
        // #define _NORMAL_DROPOFF_OS	1
        // #define _NORMAL_DROPOFF_WS	1

        //-------------------------------------------------------------------------------------
        // End Variant Definitions
        //-------------------------------------------------------------------------------------

        #pragma vertex Vert
        #pragma fragment Frag

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"

        // define FragInputs structure
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"

        //-------------------------------------------------------------------------------------
        // Active Field Defines
        //-------------------------------------------------------------------------------------

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
        #define VARYINGS_NEED_CULLFACE
        // #define HAVE_MESH_MODIFICATION

        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------
    	

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #ifdef DEBUG_DISPLAY
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
        #endif

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"

    #if (SHADERPASS == SHADERPASS_FORWARD)
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/Lighting.hlsl"

        #define HAS_LIGHTLOOP

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoopDef.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoop.hlsl"
    #else
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
    #endif

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"

        //Used by SceneSelectionPass
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
        float Vector1_FCB2FF33;
        float _Metallic;
        float _Smoothness;
        float4 _EmissiveColor;
        float _EmissiveIntensity;
        float _EmissiveExposureWeight;
        CBUFFER_END
        TEXTURE2D(_BaseColorMap); SAMPLER(sampler_BaseColorMap); float4 _BaseColorMap_TexelSize;
        TEXTURE2D(_MaskMap); SAMPLER(sampler_MaskMap); float4 _MaskMap_TexelSize;
        TEXTURE2D(_NormalMap); SAMPLER(sampler_NormalMap); float4 _NormalMap_TexelSize;
        TEXTURE2D(_EmissiveColorMap); SAMPLER(sampler_EmissiveColorMap); float4 _EmissiveColorMap_TexelSize;
        SAMPLER(_SampleTexture2D_2231EDA7_Sampler_3_Linear_Repeat);

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
                
        void Unity_Multiply_float(float A, float B, out float Out)
        {
            Out = A * B;
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

        void Unity_Add_float(float A, float B, out float Out)
        {
            Out = A + B;
        }

                // Pixel Graph Evaluation


//Advanced Dissolve
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Core.cginc"


                    SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float4 _SampleTexture2D_2231EDA7_RGBA_0 = SAMPLE_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, IN.uv0.xy);
        float _SampleTexture2D_2231EDA7_R_4 = _SampleTexture2D_2231EDA7_RGBA_0.r;
        float _SampleTexture2D_2231EDA7_G_5 = _SampleTexture2D_2231EDA7_RGBA_0.g;
        float _SampleTexture2D_2231EDA7_B_6 = _SampleTexture2D_2231EDA7_RGBA_0.b;
        float _SampleTexture2D_2231EDA7_A_7 = _SampleTexture2D_2231EDA7_RGBA_0.a;
        float _Property_4AB6CADC_Out_0 = Vector1_FCB2FF33;
        float _Multiply_8B49D9AB_Out_2;
        Unity_Multiply_float(_Property_4AB6CADC_Out_0, 1.01, _Multiply_8B49D9AB_Out_2);
        Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab _AdvancedDissolve_ED28DB36;
        _AdvancedDissolve_ED28DB36.ObjectSpaceNormal = IN.ObjectSpaceNormal;
        _AdvancedDissolve_ED28DB36.WorldSpaceNormal = IN.WorldSpaceNormal;
        _AdvancedDissolve_ED28DB36.ObjectSpacePosition = IN.ObjectSpacePosition;
        _AdvancedDissolve_ED28DB36.WorldSpacePosition = IN.WorldSpacePosition;
        _AdvancedDissolve_ED28DB36.AbsoluteWorldSpacePosition = IN.AbsoluteWorldSpacePosition;
        _AdvancedDissolve_ED28DB36.uv0 = IN.uv0;
        float _AdvancedDissolve_ED28DB36_Out_3;
        SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(0, float4 (0, 0, 0, 1), _AdvancedDissolve_ED28DB36, _AdvancedDissolve_ED28DB36_Out_3);
        float _Add_4768B504_Out_2;
        Unity_Add_float(_Multiply_8B49D9AB_Out_2, _AdvancedDissolve_ED28DB36_Out_3, _Add_4768B504_Out_2);
        surface.Alpha = _SampleTexture2D_2231EDA7_A_7;
        surface.AlphaClipThreshold = _Add_4768B504_Out_2;


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
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
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
            surfaceData.ambientOcclusion = 1.0;
            surfaceData.specularOcclusion = 1.0; // This need to be init here to quiet the compiler in case of decal, but can be override later.

            // copy across graph values, if defined
            // surfaceData.baseColor =             surfaceDescription.Albedo;
            // surfaceData.perceptualSmoothness =  surfaceDescription.Smoothness;
            // surfaceData.ambientOcclusion =      surfaceDescription.Occlusion;
            // surfaceData.metallic =              surfaceDescription.Metallic;
            // surfaceData.specularColor =         surfaceDescription.Specular;

            // These static material feature allow compile time optimization
            surfaceData.materialFeatures = MATERIALFEATUREFLAGS_LIT_STANDARD;
    #ifdef _MATERIAL_FEATURE_SPECULAR_COLOR
            surfaceData.materialFeatures |= MATERIALFEATUREFLAGS_LIT_SPECULAR_COLOR;
    #endif

            float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
            // doubleSidedConstants = float3(-1.0, -1.0, -1.0);
            doubleSidedConstants = float3( 1.0,  1.0, -1.0);

            // normal delivered to master node
            float3 normalSrc = float3(0.0f, 0.0f, 1.0f);
            // normalSrc = surfaceDescription.Normal;

            // compute world space normal
    #if _NORMAL_DROPOFF_TS
            GetNormalWS(fragInputs, normalSrc, surfaceData.normalWS, doubleSidedConstants);
    #elif _NORMAL_DROPOFF_OS
    		surfaceData.normalWS = TransformObjectToWorldNormal(normalSrc);
    #elif _NORMAL_DROPOFF_WS
    		surfaceData.normalWS = normalSrc;
    #endif

            surfaceData.geomNormalWS = fragInputs.tangentToWorld[2];
            surfaceData.tangentWS = normalize(fragInputs.tangentToWorld[0].xyz);    // The tangent is not normalize in tangentToWorld for mikkt. TODO: Check if it expected that we normalize with Morten. Tag: SURFACE_GRADIENT

    #if HAVE_DECALS
            if (_EnableDecals)
            {
                // Both uses and modifies 'surfaceData.normalWS'.
                DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, surfaceDescription.Alpha);
                ApplyDecalToSurfaceData(decalSurfaceData, surfaceData);
            }
    #endif

            surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

    #ifdef DEBUG_DISPLAY
            if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
            {
                // TODO: need to update mip info
                surfaceData.metallic = 0;
            }

            // We need to call ApplyDebugToSurfaceData after filling the surfarcedata and before filling builtinData
            // as it can modify attribute use for static lighting
            ApplyDebugToSurfaceData(fragInputs.tangentToWorld, surfaceData);
    #endif

            // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion as PBR master node don't have any option
            surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
        }

        void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData)
        {
    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
            LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
    #endif

            float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
            // doubleSidedConstants = float3(-1.0, -1.0, -1.0);
            doubleSidedConstants = float3( 1.0,  1.0, -1.0);

            ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants);

            SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
            SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);

            // Perform alpha test very early to save performance (a killed pixel will not sample textures)
            // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
            DoAlphaTest(surfaceDescription.Alpha, surfaceDescription.AlphaClipThreshold);

            BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);

            // Builtin Data
            // For back lighting we use the oposite vertex normal
            InitBuiltinData(posInput, surfaceDescription.Alpha, surfaceData.normalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);

            // builtinData.emissiveColor = surfaceDescription.Emission;

            PostInitBuiltinData(V, posInput, surfaceData, builtinData);
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
        // based on HDPBRPass.template
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

        #pragma multi_compile_instancing
        #pragma instancing_options renderinglayer

        #pragma multi_compile _ LOD_FADE_CROSSFADE

        //-------------------------------------------------------------------------------------
        // Graph Defines
        //-------------------------------------------------------------------------------------
                // Shared Graph Keywords
                #define SHADERPASS SHADERPASS_LIGHT_TRANSPORT
                // ACTIVE FIELDS:
                //   DoubleSided
                //   DoubleSided.Mirror
                //   FragInputs.isFrontFace
                //   AlphaTest
                //   features.NormalDropOffTS
                //   SurfaceDescriptionInputs.ObjectSpaceNormal
                //   SurfaceDescriptionInputs.WorldSpaceNormal
                //   SurfaceDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescriptionInputs.WorldSpacePosition
                //   SurfaceDescriptionInputs.AbsoluteWorldSpacePosition
                //   SurfaceDescriptionInputs.uv0
                //   VertexDescriptionInputs.ObjectSpaceNormal
                //   VertexDescriptionInputs.ObjectSpaceTangent
                //   VertexDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescription.Albedo
                //   SurfaceDescription.Normal
                //   SurfaceDescription.Metallic
                //   SurfaceDescription.Emission
                //   SurfaceDescription.Smoothness
                //   SurfaceDescription.Occlusion
                //   SurfaceDescription.Alpha
                //   SurfaceDescription.AlphaClipThreshold
                //   AttributesMesh.normalOS
                //   AttributesMesh.tangentOS
                //   AttributesMesh.uv0
                //   AttributesMesh.uv1
                //   AttributesMesh.color
                //   AttributesMesh.uv2
                //   VaryingsMeshToPS.cullFace
                //   FragInputs.tangentToWorld
                //   FragInputs.positionRWS
                //   FragInputs.texCoord0
                //   AttributesMesh.positionOS
                //   VaryingsMeshToPS.tangentWS
                //   VaryingsMeshToPS.normalWS
                //   VaryingsMeshToPS.positionRWS
                //   VaryingsMeshToPS.texCoord0
        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------
        // Variant Definitions (active field translations to HDRP defines)
        //-------------------------------------------------------------------------------------

        // #define _MATERIAL_FEATURE_SPECULAR_COLOR 1
        // #define _SURFACE_TYPE_TRANSPARENT 1
        // #define _BLENDMODE_ALPHA 1
        // #define _BLENDMODE_ADD 1
        // #define _BLENDMODE_PRE_MULTIPLY 1
        #define _DOUBLESIDED_ON 1
        #define _NORMAL_DROPOFF_TS	1
        // #define _NORMAL_DROPOFF_OS	1
        // #define _NORMAL_DROPOFF_WS	1

        //-------------------------------------------------------------------------------------
        // End Variant Definitions
        //-------------------------------------------------------------------------------------

        #pragma vertex Vert
        #pragma fragment Frag

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"

        // define FragInputs structure
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"

        //-------------------------------------------------------------------------------------
        // Active Field Defines
        //-------------------------------------------------------------------------------------

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
        #define VARYINGS_NEED_CULLFACE
        // #define HAVE_MESH_MODIFICATION

        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------
    	

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #ifdef DEBUG_DISPLAY
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
        #endif

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"

    #if (SHADERPASS == SHADERPASS_FORWARD)
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/Lighting.hlsl"

        #define HAS_LIGHTLOOP

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoopDef.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoop.hlsl"
    #else
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
    #endif

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"

        //Used by SceneSelectionPass
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
        float Vector1_FCB2FF33;
        float _Metallic;
        float _Smoothness;
        float4 _EmissiveColor;
        float _EmissiveIntensity;
        float _EmissiveExposureWeight;
        CBUFFER_END
        TEXTURE2D(_BaseColorMap); SAMPLER(sampler_BaseColorMap); float4 _BaseColorMap_TexelSize;
        TEXTURE2D(_MaskMap); SAMPLER(sampler_MaskMap); float4 _MaskMap_TexelSize;
        TEXTURE2D(_NormalMap); SAMPLER(sampler_NormalMap); float4 _NormalMap_TexelSize;
        TEXTURE2D(_EmissiveColorMap); SAMPLER(sampler_EmissiveColorMap); float4 _EmissiveColorMap_TexelSize;
        SAMPLER(_SampleTexture2D_2231EDA7_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_EBE6E655_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_A32F7A5B_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_2993A4AD_Sampler_3_Linear_Repeat);

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
        float3 Albedo;
        float3 Normal;
        float Metallic;
        float3 Emission;
        float Smoothness;
        float Occlusion;
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

        void Unity_Multiply_float(float A, float B, out float Out)
        {
            Out = A * B;
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

        void Unity_Add_float(float A, float B, out float Out)
        {
            Out = A + B;
        }

                // Pixel Graph Evaluation


//Advanced Dissolve
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Core.cginc"


                    SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float4 _Property_46446BCB_Out_0 = _BaseColor;
        float4 _SampleTexture2D_2231EDA7_RGBA_0 = SAMPLE_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, IN.uv0.xy);
        float _SampleTexture2D_2231EDA7_R_4 = _SampleTexture2D_2231EDA7_RGBA_0.r;
        float _SampleTexture2D_2231EDA7_G_5 = _SampleTexture2D_2231EDA7_RGBA_0.g;
        float _SampleTexture2D_2231EDA7_B_6 = _SampleTexture2D_2231EDA7_RGBA_0.b;
        float _SampleTexture2D_2231EDA7_A_7 = _SampleTexture2D_2231EDA7_RGBA_0.a;
        float4 _Multiply_141A51E_Out_2;
        Unity_Multiply_float(_Property_46446BCB_Out_0, _SampleTexture2D_2231EDA7_RGBA_0, _Multiply_141A51E_Out_2);
        float4 _SampleTexture2D_EBE6E655_RGBA_0 = SAMPLE_TEXTURE2D(_NormalMap, sampler_NormalMap, IN.uv0.xy);
        _SampleTexture2D_EBE6E655_RGBA_0.rgb = UnpackNormal(_SampleTexture2D_EBE6E655_RGBA_0);
        float _SampleTexture2D_EBE6E655_R_4 = _SampleTexture2D_EBE6E655_RGBA_0.r;
        float _SampleTexture2D_EBE6E655_G_5 = _SampleTexture2D_EBE6E655_RGBA_0.g;
        float _SampleTexture2D_EBE6E655_B_6 = _SampleTexture2D_EBE6E655_RGBA_0.b;
        float _SampleTexture2D_EBE6E655_A_7 = _SampleTexture2D_EBE6E655_RGBA_0.a;
        float4 _Property_119E2903_Out_0 = _EmissiveColor;
        float4 _SampleTexture2D_A32F7A5B_RGBA_0 = SAMPLE_TEXTURE2D(_EmissiveColorMap, sampler_EmissiveColorMap, IN.uv0.xy);
        float _SampleTexture2D_A32F7A5B_R_4 = _SampleTexture2D_A32F7A5B_RGBA_0.r;
        float _SampleTexture2D_A32F7A5B_G_5 = _SampleTexture2D_A32F7A5B_RGBA_0.g;
        float _SampleTexture2D_A32F7A5B_B_6 = _SampleTexture2D_A32F7A5B_RGBA_0.b;
        float _SampleTexture2D_A32F7A5B_A_7 = _SampleTexture2D_A32F7A5B_RGBA_0.a;
        float4 _Multiply_36554B06_Out_2;
        Unity_Multiply_float(_Property_119E2903_Out_0, _SampleTexture2D_A32F7A5B_RGBA_0, _Multiply_36554B06_Out_2);
        float _Property_DAC26131_Out_0 = _EmissiveIntensity;
        float _Property_1E50B4E1_Out_0 = _EmissiveExposureWeight;
        #ifdef SHADERGRAPH_PREVIEW
        float inverseExposureMultiplier = 1.0;
        #else
        float inverseExposureMultiplier = GetInverseCurrentExposureMultiplier();
        #endif
        float3 _EmissionNode_CB31D1AF_Output_0 = Unity_HDRP_GetEmissionHDRColor_float((_Multiply_36554B06_Out_2.xyz).xyz, ConvertEvToLuminance(_Property_DAC26131_Out_0), _Property_1E50B4E1_Out_0, inverseExposureMultiplier);
        float _Property_DB6A213A_Out_0 = _Metallic;
        float4 _SampleTexture2D_2993A4AD_RGBA_0 = SAMPLE_TEXTURE2D(_MaskMap, sampler_MaskMap, IN.uv0.xy);
        float _SampleTexture2D_2993A4AD_R_4 = _SampleTexture2D_2993A4AD_RGBA_0.r;
        float _SampleTexture2D_2993A4AD_G_5 = _SampleTexture2D_2993A4AD_RGBA_0.g;
        float _SampleTexture2D_2993A4AD_B_6 = _SampleTexture2D_2993A4AD_RGBA_0.b;
        float _SampleTexture2D_2993A4AD_A_7 = _SampleTexture2D_2993A4AD_RGBA_0.a;
        float _Multiply_738B5170_Out_2;
        Unity_Multiply_float(_Property_DB6A213A_Out_0, _SampleTexture2D_2993A4AD_R_4, _Multiply_738B5170_Out_2);
        float _Property_D2EC53B3_Out_0 = _Smoothness;
        float _Multiply_FF35CABB_Out_2;
        Unity_Multiply_float(_Property_D2EC53B3_Out_0, _SampleTexture2D_2993A4AD_A_7, _Multiply_FF35CABB_Out_2);
        float _Property_4AB6CADC_Out_0 = Vector1_FCB2FF33;
        float _Multiply_8B49D9AB_Out_2;
        Unity_Multiply_float(_Property_4AB6CADC_Out_0, 1.01, _Multiply_8B49D9AB_Out_2);
        Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab _AdvancedDissolve_ED28DB36;
        _AdvancedDissolve_ED28DB36.ObjectSpaceNormal = IN.ObjectSpaceNormal;
        _AdvancedDissolve_ED28DB36.WorldSpaceNormal = IN.WorldSpaceNormal;
        _AdvancedDissolve_ED28DB36.ObjectSpacePosition = IN.ObjectSpacePosition;
        _AdvancedDissolve_ED28DB36.WorldSpacePosition = IN.WorldSpacePosition;
        _AdvancedDissolve_ED28DB36.AbsoluteWorldSpacePosition = IN.AbsoluteWorldSpacePosition;
        _AdvancedDissolve_ED28DB36.uv0 = IN.uv0;
        float _AdvancedDissolve_ED28DB36_Out_3;
        SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(0, float4 (0, 0, 0, 1), _AdvancedDissolve_ED28DB36, _AdvancedDissolve_ED28DB36_Out_3);
        float _Add_4768B504_Out_2;
        Unity_Add_float(_Multiply_8B49D9AB_Out_2, _AdvancedDissolve_ED28DB36_Out_3, _Add_4768B504_Out_2);
        surface.Albedo = (_Multiply_141A51E_Out_2.xyz);
        surface.Normal = (_SampleTexture2D_EBE6E655_RGBA_0.xyz);
        surface.Metallic = _Multiply_738B5170_Out_2;
        surface.Emission = _EmissionNode_CB31D1AF_Output_0;
        surface.Smoothness = _Multiply_FF35CABB_Out_2;
        surface.Occlusion = _SampleTexture2D_2993A4AD_G_5;
        surface.Alpha = _SampleTexture2D_2231EDA7_A_7;
        surface.AlphaClipThreshold = _Add_4768B504_Out_2;


//Unknown
AdvancedDissolveShaderGraph(IN.uv0.xy, IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, 0, 1, surface.Albedo, surface.Emission, surface.Alpha, surface.AlphaClipThreshold);


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
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
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
            surfaceData.ambientOcclusion = 1.0;
            surfaceData.specularOcclusion = 1.0; // This need to be init here to quiet the compiler in case of decal, but can be override later.

            // copy across graph values, if defined
            surfaceData.baseColor =             surfaceDescription.Albedo;
            surfaceData.perceptualSmoothness =  surfaceDescription.Smoothness;
            surfaceData.ambientOcclusion =      surfaceDescription.Occlusion;
            surfaceData.metallic =              surfaceDescription.Metallic;
            // surfaceData.specularColor =         surfaceDescription.Specular;

            // These static material feature allow compile time optimization
            surfaceData.materialFeatures = MATERIALFEATUREFLAGS_LIT_STANDARD;
    #ifdef _MATERIAL_FEATURE_SPECULAR_COLOR
            surfaceData.materialFeatures |= MATERIALFEATUREFLAGS_LIT_SPECULAR_COLOR;
    #endif

            float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
            // doubleSidedConstants = float3(-1.0, -1.0, -1.0);
            doubleSidedConstants = float3( 1.0,  1.0, -1.0);

            // normal delivered to master node
            float3 normalSrc = float3(0.0f, 0.0f, 1.0f);
            normalSrc = surfaceDescription.Normal;

            // compute world space normal
    #if _NORMAL_DROPOFF_TS
            GetNormalWS(fragInputs, normalSrc, surfaceData.normalWS, doubleSidedConstants);
    #elif _NORMAL_DROPOFF_OS
    		surfaceData.normalWS = TransformObjectToWorldNormal(normalSrc);
    #elif _NORMAL_DROPOFF_WS
    		surfaceData.normalWS = normalSrc;
    #endif

            surfaceData.geomNormalWS = fragInputs.tangentToWorld[2];
            surfaceData.tangentWS = normalize(fragInputs.tangentToWorld[0].xyz);    // The tangent is not normalize in tangentToWorld for mikkt. TODO: Check if it expected that we normalize with Morten. Tag: SURFACE_GRADIENT

    #if HAVE_DECALS
            if (_EnableDecals)
            {
                // Both uses and modifies 'surfaceData.normalWS'.
                DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, surfaceDescription.Alpha);
                ApplyDecalToSurfaceData(decalSurfaceData, surfaceData);
            }
    #endif

            surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

    #ifdef DEBUG_DISPLAY
            if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
            {
                // TODO: need to update mip info
                surfaceData.metallic = 0;
            }

            // We need to call ApplyDebugToSurfaceData after filling the surfarcedata and before filling builtinData
            // as it can modify attribute use for static lighting
            ApplyDebugToSurfaceData(fragInputs.tangentToWorld, surfaceData);
    #endif

            // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion as PBR master node don't have any option
            surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
        }

        void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData)
        {
    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
            LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
    #endif

            float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
            // doubleSidedConstants = float3(-1.0, -1.0, -1.0);
            doubleSidedConstants = float3( 1.0,  1.0, -1.0);

            ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants);

            SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
            SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);

            // Perform alpha test very early to save performance (a killed pixel will not sample textures)
            // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
            DoAlphaTest(surfaceDescription.Alpha, surfaceDescription.AlphaClipThreshold);

            BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);

            // Builtin Data
            // For back lighting we use the oposite vertex normal
            InitBuiltinData(posInput, surfaceDescription.Alpha, surfaceData.normalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);

            builtinData.emissiveColor = surfaceDescription.Emission;

            PostInitBuiltinData(V, posInput, surfaceData, builtinData);
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
        // based on HDPBRPass.template
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

        #pragma multi_compile_instancing
        #pragma instancing_options renderinglayer

        #pragma multi_compile _ LOD_FADE_CROSSFADE

        //-------------------------------------------------------------------------------------
        // Graph Defines
        //-------------------------------------------------------------------------------------
                // Shared Graph Keywords
                #define SHADERPASS SHADERPASS_DEPTH_ONLY
                #define SCENESELECTIONPASS
                #pragma editor_sync_compilation
                // ACTIVE FIELDS:
                //   DoubleSided
                //   DoubleSided.Mirror
                //   FragInputs.isFrontFace
                //   AlphaTest
                //   features.NormalDropOffTS
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
                //   VaryingsMeshToPS.cullFace
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
        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------
        // Variant Definitions (active field translations to HDRP defines)
        //-------------------------------------------------------------------------------------

        // #define _MATERIAL_FEATURE_SPECULAR_COLOR 1
        // #define _SURFACE_TYPE_TRANSPARENT 1
        // #define _BLENDMODE_ALPHA 1
        // #define _BLENDMODE_ADD 1
        // #define _BLENDMODE_PRE_MULTIPLY 1
        #define _DOUBLESIDED_ON 1
        #define _NORMAL_DROPOFF_TS	1
        // #define _NORMAL_DROPOFF_OS	1
        // #define _NORMAL_DROPOFF_WS	1

        //-------------------------------------------------------------------------------------
        // End Variant Definitions
        //-------------------------------------------------------------------------------------

        #pragma vertex Vert
        #pragma fragment Frag

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"

        // define FragInputs structure
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"

        //-------------------------------------------------------------------------------------
        // Active Field Defines
        //-------------------------------------------------------------------------------------

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
        #define VARYINGS_NEED_CULLFACE
        // #define HAVE_MESH_MODIFICATION

        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------
    	

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #ifdef DEBUG_DISPLAY
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
        #endif

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"

    #if (SHADERPASS == SHADERPASS_FORWARD)
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/Lighting.hlsl"

        #define HAS_LIGHTLOOP

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoopDef.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoop.hlsl"
    #else
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
    #endif

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"

        //Used by SceneSelectionPass
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
        float Vector1_FCB2FF33;
        float _Metallic;
        float _Smoothness;
        float4 _EmissiveColor;
        float _EmissiveIntensity;
        float _EmissiveExposureWeight;
        CBUFFER_END
        TEXTURE2D(_BaseColorMap); SAMPLER(sampler_BaseColorMap); float4 _BaseColorMap_TexelSize;
        TEXTURE2D(_MaskMap); SAMPLER(sampler_MaskMap); float4 _MaskMap_TexelSize;
        TEXTURE2D(_NormalMap); SAMPLER(sampler_NormalMap); float4 _NormalMap_TexelSize;
        TEXTURE2D(_EmissiveColorMap); SAMPLER(sampler_EmissiveColorMap); float4 _EmissiveColorMap_TexelSize;
        SAMPLER(_SampleTexture2D_2231EDA7_Sampler_3_Linear_Repeat);

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
                
        void Unity_Multiply_float(float A, float B, out float Out)
        {
            Out = A * B;
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

        void Unity_Add_float(float A, float B, out float Out)
        {
            Out = A + B;
        }

                // Pixel Graph Evaluation


//Advanced Dissolve
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Core.cginc"


                    SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float4 _SampleTexture2D_2231EDA7_RGBA_0 = SAMPLE_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, IN.uv0.xy);
        float _SampleTexture2D_2231EDA7_R_4 = _SampleTexture2D_2231EDA7_RGBA_0.r;
        float _SampleTexture2D_2231EDA7_G_5 = _SampleTexture2D_2231EDA7_RGBA_0.g;
        float _SampleTexture2D_2231EDA7_B_6 = _SampleTexture2D_2231EDA7_RGBA_0.b;
        float _SampleTexture2D_2231EDA7_A_7 = _SampleTexture2D_2231EDA7_RGBA_0.a;
        float _Property_4AB6CADC_Out_0 = Vector1_FCB2FF33;
        float _Multiply_8B49D9AB_Out_2;
        Unity_Multiply_float(_Property_4AB6CADC_Out_0, 1.01, _Multiply_8B49D9AB_Out_2);
        Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab _AdvancedDissolve_ED28DB36;
        _AdvancedDissolve_ED28DB36.ObjectSpaceNormal = IN.ObjectSpaceNormal;
        _AdvancedDissolve_ED28DB36.WorldSpaceNormal = IN.WorldSpaceNormal;
        _AdvancedDissolve_ED28DB36.ObjectSpacePosition = IN.ObjectSpacePosition;
        _AdvancedDissolve_ED28DB36.WorldSpacePosition = IN.WorldSpacePosition;
        _AdvancedDissolve_ED28DB36.AbsoluteWorldSpacePosition = IN.AbsoluteWorldSpacePosition;
        _AdvancedDissolve_ED28DB36.uv0 = IN.uv0;
        float _AdvancedDissolve_ED28DB36_Out_3;
        SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(0, float4 (0, 0, 0, 1), _AdvancedDissolve_ED28DB36, _AdvancedDissolve_ED28DB36_Out_3);
        float _Add_4768B504_Out_2;
        Unity_Add_float(_Multiply_8B49D9AB_Out_2, _AdvancedDissolve_ED28DB36_Out_3, _Add_4768B504_Out_2);
        surface.Alpha = _SampleTexture2D_2231EDA7_A_7;
        surface.AlphaClipThreshold = _Add_4768B504_Out_2;


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
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
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
            surfaceData.ambientOcclusion = 1.0;
            surfaceData.specularOcclusion = 1.0; // This need to be init here to quiet the compiler in case of decal, but can be override later.

            // copy across graph values, if defined
            // surfaceData.baseColor =             surfaceDescription.Albedo;
            // surfaceData.perceptualSmoothness =  surfaceDescription.Smoothness;
            // surfaceData.ambientOcclusion =      surfaceDescription.Occlusion;
            // surfaceData.metallic =              surfaceDescription.Metallic;
            // surfaceData.specularColor =         surfaceDescription.Specular;

            // These static material feature allow compile time optimization
            surfaceData.materialFeatures = MATERIALFEATUREFLAGS_LIT_STANDARD;
    #ifdef _MATERIAL_FEATURE_SPECULAR_COLOR
            surfaceData.materialFeatures |= MATERIALFEATUREFLAGS_LIT_SPECULAR_COLOR;
    #endif

            float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
            // doubleSidedConstants = float3(-1.0, -1.0, -1.0);
            doubleSidedConstants = float3( 1.0,  1.0, -1.0);

            // normal delivered to master node
            float3 normalSrc = float3(0.0f, 0.0f, 1.0f);
            // normalSrc = surfaceDescription.Normal;

            // compute world space normal
    #if _NORMAL_DROPOFF_TS
            GetNormalWS(fragInputs, normalSrc, surfaceData.normalWS, doubleSidedConstants);
    #elif _NORMAL_DROPOFF_OS
    		surfaceData.normalWS = TransformObjectToWorldNormal(normalSrc);
    #elif _NORMAL_DROPOFF_WS
    		surfaceData.normalWS = normalSrc;
    #endif

            surfaceData.geomNormalWS = fragInputs.tangentToWorld[2];
            surfaceData.tangentWS = normalize(fragInputs.tangentToWorld[0].xyz);    // The tangent is not normalize in tangentToWorld for mikkt. TODO: Check if it expected that we normalize with Morten. Tag: SURFACE_GRADIENT

    #if HAVE_DECALS
            if (_EnableDecals)
            {
                // Both uses and modifies 'surfaceData.normalWS'.
                DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, surfaceDescription.Alpha);
                ApplyDecalToSurfaceData(decalSurfaceData, surfaceData);
            }
    #endif

            surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

    #ifdef DEBUG_DISPLAY
            if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
            {
                // TODO: need to update mip info
                surfaceData.metallic = 0;
            }

            // We need to call ApplyDebugToSurfaceData after filling the surfarcedata and before filling builtinData
            // as it can modify attribute use for static lighting
            ApplyDebugToSurfaceData(fragInputs.tangentToWorld, surfaceData);
    #endif

            // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion as PBR master node don't have any option
            surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
        }

        void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData)
        {
    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
            LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
    #endif

            float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
            // doubleSidedConstants = float3(-1.0, -1.0, -1.0);
            doubleSidedConstants = float3( 1.0,  1.0, -1.0);

            ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants);

            SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
            SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);

            // Perform alpha test very early to save performance (a killed pixel will not sample textures)
            // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
            DoAlphaTest(surfaceDescription.Alpha, surfaceDescription.AlphaClipThreshold);

            BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);

            // Builtin Data
            // For back lighting we use the oposite vertex normal
            InitBuiltinData(posInput, surfaceDescription.Alpha, surfaceData.normalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);

            // builtinData.emissiveColor = surfaceDescription.Emission;

            PostInitBuiltinData(V, posInput, surfaceData, builtinData);
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
        // based on HDPBRPass.template
        Name "DepthOnly"
        Tags { "LightMode" = "DepthOnly" }

        //-------------------------------------------------------------------------------------
        // Render Modes (Blend, Cull, ZTest, Stencil, etc)
        //-------------------------------------------------------------------------------------
        
        Cull Off

        
        ZWrite On

        
        // Stencil setup
    Stencil
    {
       WriteMask 8
       Ref  8
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

        #pragma multi_compile_instancing
        #pragma instancing_options renderinglayer

        #pragma multi_compile _ LOD_FADE_CROSSFADE

        //-------------------------------------------------------------------------------------
        // Graph Defines
        //-------------------------------------------------------------------------------------
                // Shared Graph Keywords
                #define SHADERPASS SHADERPASS_DEPTH_ONLY
                #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
                #pragma multi_compile _ WRITE_NORMAL_BUFFER
                #pragma multi_compile _ WRITE_MSAA_DEPTH
                #define RAYTRACING_SHADER_GRAPH_HIGH
                // ACTIVE FIELDS:
                //   DoubleSided
                //   DoubleSided.Mirror
                //   FragInputs.isFrontFace
                //   AlphaTest
                //   features.NormalDropOffTS
                //   SurfaceDescriptionInputs.ObjectSpaceNormal
                //   SurfaceDescriptionInputs.WorldSpaceNormal
                //   SurfaceDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescriptionInputs.WorldSpacePosition
                //   SurfaceDescriptionInputs.AbsoluteWorldSpacePosition
                //   SurfaceDescriptionInputs.uv0
                //   VertexDescriptionInputs.ObjectSpaceNormal
                //   VertexDescriptionInputs.ObjectSpaceTangent
                //   VertexDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescription.Normal
                //   SurfaceDescription.Smoothness
                //   SurfaceDescription.Alpha
                //   SurfaceDescription.AlphaClipThreshold
                //   AttributesMesh.normalOS
                //   AttributesMesh.tangentOS
                //   AttributesMesh.uv0
                //   AttributesMesh.uv1
                //   AttributesMesh.color
                //   AttributesMesh.uv2
                //   AttributesMesh.uv3
                //   FragInputs.tangentToWorld
                //   FragInputs.positionRWS
                //   FragInputs.texCoord0
                //   FragInputs.texCoord1
                //   FragInputs.texCoord2
                //   FragInputs.texCoord3
                //   FragInputs.color
                //   VaryingsMeshToPS.cullFace
                //   AttributesMesh.positionOS
                //   VaryingsMeshToPS.tangentWS
                //   VaryingsMeshToPS.normalWS
                //   VaryingsMeshToPS.positionRWS
                //   VaryingsMeshToPS.texCoord0
                //   VaryingsMeshToPS.texCoord1
                //   VaryingsMeshToPS.texCoord2
                //   VaryingsMeshToPS.texCoord3
                //   VaryingsMeshToPS.color
        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------
        // Variant Definitions (active field translations to HDRP defines)
        //-------------------------------------------------------------------------------------

        // #define _MATERIAL_FEATURE_SPECULAR_COLOR 1
        // #define _SURFACE_TYPE_TRANSPARENT 1
        // #define _BLENDMODE_ALPHA 1
        // #define _BLENDMODE_ADD 1
        // #define _BLENDMODE_PRE_MULTIPLY 1
        #define _DOUBLESIDED_ON 1
        #define _NORMAL_DROPOFF_TS	1
        // #define _NORMAL_DROPOFF_OS	1
        // #define _NORMAL_DROPOFF_WS	1

        //-------------------------------------------------------------------------------------
        // End Variant Definitions
        //-------------------------------------------------------------------------------------

        #pragma vertex Vert
        #pragma fragment Frag

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"

        // define FragInputs structure
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"

        //-------------------------------------------------------------------------------------
        // Active Field Defines
        //-------------------------------------------------------------------------------------

        // this translates the new dependency tracker into the old preprocessor definitions for the existing HDRP shader code
        #define ATTRIBUTES_NEED_NORMAL
        #define ATTRIBUTES_NEED_TANGENT
        #define ATTRIBUTES_NEED_TEXCOORD0
        #define ATTRIBUTES_NEED_TEXCOORD1
        #define ATTRIBUTES_NEED_TEXCOORD2
        #define ATTRIBUTES_NEED_TEXCOORD3
        #define ATTRIBUTES_NEED_COLOR
        #define VARYINGS_NEED_POSITION_WS
        #define VARYINGS_NEED_TANGENT_TO_WORLD
        #define VARYINGS_NEED_TEXCOORD0
        #define VARYINGS_NEED_TEXCOORD1
        #define VARYINGS_NEED_TEXCOORD2
        #define VARYINGS_NEED_TEXCOORD3
        #define VARYINGS_NEED_COLOR
        #define VARYINGS_NEED_CULLFACE
        // #define HAVE_MESH_MODIFICATION

        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------
    	

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #ifdef DEBUG_DISPLAY
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
        #endif

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"

    #if (SHADERPASS == SHADERPASS_FORWARD)
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/Lighting.hlsl"

        #define HAS_LIGHTLOOP

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoopDef.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoop.hlsl"
    #else
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
    #endif

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"

        //Used by SceneSelectionPass
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
                float4 uv3 : TEXCOORD3; // optional
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
                float4 texCoord1; // optional
                float4 texCoord2; // optional
                float4 texCoord3; // optional
                float4 color; // optional
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
                float4 interp04 : TEXCOORD4; // auto-packed
                float4 interp05 : TEXCOORD5; // auto-packed
                float4 interp06 : TEXCOORD6; // auto-packed
                float4 interp07 : TEXCOORD7; // auto-packed
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
                output.interp04.xyzw = input.texCoord1;
                output.interp05.xyzw = input.texCoord2;
                output.interp06.xyzw = input.texCoord3;
                output.interp07.xyzw = input.color;
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
                output.texCoord1 = input.interp04.xyzw;
                output.texCoord2 = input.interp05.xyzw;
                output.texCoord3 = input.interp06.xyzw;
                output.color = input.interp07.xyzw;
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
        float Vector1_FCB2FF33;
        float _Metallic;
        float _Smoothness;
        float4 _EmissiveColor;
        float _EmissiveIntensity;
        float _EmissiveExposureWeight;
        CBUFFER_END
        TEXTURE2D(_BaseColorMap); SAMPLER(sampler_BaseColorMap); float4 _BaseColorMap_TexelSize;
        TEXTURE2D(_MaskMap); SAMPLER(sampler_MaskMap); float4 _MaskMap_TexelSize;
        TEXTURE2D(_NormalMap); SAMPLER(sampler_NormalMap); float4 _NormalMap_TexelSize;
        TEXTURE2D(_EmissiveColorMap); SAMPLER(sampler_EmissiveColorMap); float4 _EmissiveColorMap_TexelSize;
        SAMPLER(_SampleTexture2D_EBE6E655_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_2993A4AD_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_2231EDA7_Sampler_3_Linear_Repeat);

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
        float3 Normal;
        float Smoothness;
        float Alpha;
        float AlphaClipThreshold;
    };

                // Shared Graph Node Functions
                
        void Unity_Multiply_float(float A, float B, out float Out)
        {
            Out = A * B;
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

        void Unity_Add_float(float A, float B, out float Out)
        {
            Out = A + B;
        }

                // Pixel Graph Evaluation


//Advanced Dissolve
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Core.cginc"


                    SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float4 _SampleTexture2D_EBE6E655_RGBA_0 = SAMPLE_TEXTURE2D(_NormalMap, sampler_NormalMap, IN.uv0.xy);
        _SampleTexture2D_EBE6E655_RGBA_0.rgb = UnpackNormal(_SampleTexture2D_EBE6E655_RGBA_0);
        float _SampleTexture2D_EBE6E655_R_4 = _SampleTexture2D_EBE6E655_RGBA_0.r;
        float _SampleTexture2D_EBE6E655_G_5 = _SampleTexture2D_EBE6E655_RGBA_0.g;
        float _SampleTexture2D_EBE6E655_B_6 = _SampleTexture2D_EBE6E655_RGBA_0.b;
        float _SampleTexture2D_EBE6E655_A_7 = _SampleTexture2D_EBE6E655_RGBA_0.a;
        float _Property_D2EC53B3_Out_0 = _Smoothness;
        float4 _SampleTexture2D_2993A4AD_RGBA_0 = SAMPLE_TEXTURE2D(_MaskMap, sampler_MaskMap, IN.uv0.xy);
        float _SampleTexture2D_2993A4AD_R_4 = _SampleTexture2D_2993A4AD_RGBA_0.r;
        float _SampleTexture2D_2993A4AD_G_5 = _SampleTexture2D_2993A4AD_RGBA_0.g;
        float _SampleTexture2D_2993A4AD_B_6 = _SampleTexture2D_2993A4AD_RGBA_0.b;
        float _SampleTexture2D_2993A4AD_A_7 = _SampleTexture2D_2993A4AD_RGBA_0.a;
        float _Multiply_FF35CABB_Out_2;
        Unity_Multiply_float(_Property_D2EC53B3_Out_0, _SampleTexture2D_2993A4AD_A_7, _Multiply_FF35CABB_Out_2);
        float4 _SampleTexture2D_2231EDA7_RGBA_0 = SAMPLE_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, IN.uv0.xy);
        float _SampleTexture2D_2231EDA7_R_4 = _SampleTexture2D_2231EDA7_RGBA_0.r;
        float _SampleTexture2D_2231EDA7_G_5 = _SampleTexture2D_2231EDA7_RGBA_0.g;
        float _SampleTexture2D_2231EDA7_B_6 = _SampleTexture2D_2231EDA7_RGBA_0.b;
        float _SampleTexture2D_2231EDA7_A_7 = _SampleTexture2D_2231EDA7_RGBA_0.a;
        float _Property_4AB6CADC_Out_0 = Vector1_FCB2FF33;
        float _Multiply_8B49D9AB_Out_2;
        Unity_Multiply_float(_Property_4AB6CADC_Out_0, 1.01, _Multiply_8B49D9AB_Out_2);
        Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab _AdvancedDissolve_ED28DB36;
        _AdvancedDissolve_ED28DB36.ObjectSpaceNormal = IN.ObjectSpaceNormal;
        _AdvancedDissolve_ED28DB36.WorldSpaceNormal = IN.WorldSpaceNormal;
        _AdvancedDissolve_ED28DB36.ObjectSpacePosition = IN.ObjectSpacePosition;
        _AdvancedDissolve_ED28DB36.WorldSpacePosition = IN.WorldSpacePosition;
        _AdvancedDissolve_ED28DB36.AbsoluteWorldSpacePosition = IN.AbsoluteWorldSpacePosition;
        _AdvancedDissolve_ED28DB36.uv0 = IN.uv0;
        float _AdvancedDissolve_ED28DB36_Out_3;
        SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(0, float4 (0, 0, 0, 1), _AdvancedDissolve_ED28DB36, _AdvancedDissolve_ED28DB36_Out_3);
        float _Add_4768B504_Out_2;
        Unity_Add_float(_Multiply_8B49D9AB_Out_2, _AdvancedDissolve_ED28DB36_Out_3, _Add_4768B504_Out_2);
        surface.Normal = (_SampleTexture2D_EBE6E655_RGBA_0.xyz);
        surface.Smoothness = _Multiply_FF35CABB_Out_2;
        surface.Alpha = _SampleTexture2D_2231EDA7_A_7;
        surface.AlphaClipThreshold = _Add_4768B504_Out_2;


//DepthOnly
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
            output.texCoord1 = input.texCoord1;
            output.texCoord2 = input.texCoord2;
            output.texCoord3 = input.texCoord3;
            output.color = input.color;
            #if _DOUBLESIDED_ON && SHADER_STAGE_FRAGMENT
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #elif SHADER_STAGE_FRAGMENT
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
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
            surfaceData.ambientOcclusion = 1.0;
            surfaceData.specularOcclusion = 1.0; // This need to be init here to quiet the compiler in case of decal, but can be override later.

            // copy across graph values, if defined
            // surfaceData.baseColor =             surfaceDescription.Albedo;
            surfaceData.perceptualSmoothness =  surfaceDescription.Smoothness;
            // surfaceData.ambientOcclusion =      surfaceDescription.Occlusion;
            // surfaceData.metallic =              surfaceDescription.Metallic;
            // surfaceData.specularColor =         surfaceDescription.Specular;

            // These static material feature allow compile time optimization
            surfaceData.materialFeatures = MATERIALFEATUREFLAGS_LIT_STANDARD;
    #ifdef _MATERIAL_FEATURE_SPECULAR_COLOR
            surfaceData.materialFeatures |= MATERIALFEATUREFLAGS_LIT_SPECULAR_COLOR;
    #endif

            float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
            // doubleSidedConstants = float3(-1.0, -1.0, -1.0);
            doubleSidedConstants = float3( 1.0,  1.0, -1.0);

            // normal delivered to master node
            float3 normalSrc = float3(0.0f, 0.0f, 1.0f);
            normalSrc = surfaceDescription.Normal;

            // compute world space normal
    #if _NORMAL_DROPOFF_TS
            GetNormalWS(fragInputs, normalSrc, surfaceData.normalWS, doubleSidedConstants);
    #elif _NORMAL_DROPOFF_OS
    		surfaceData.normalWS = TransformObjectToWorldNormal(normalSrc);
    #elif _NORMAL_DROPOFF_WS
    		surfaceData.normalWS = normalSrc;
    #endif

            surfaceData.geomNormalWS = fragInputs.tangentToWorld[2];
            surfaceData.tangentWS = normalize(fragInputs.tangentToWorld[0].xyz);    // The tangent is not normalize in tangentToWorld for mikkt. TODO: Check if it expected that we normalize with Morten. Tag: SURFACE_GRADIENT

    #if HAVE_DECALS
            if (_EnableDecals)
            {
                // Both uses and modifies 'surfaceData.normalWS'.
                DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, surfaceDescription.Alpha);
                ApplyDecalToSurfaceData(decalSurfaceData, surfaceData);
            }
    #endif

            surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

    #ifdef DEBUG_DISPLAY
            if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
            {
                // TODO: need to update mip info
                surfaceData.metallic = 0;
            }

            // We need to call ApplyDebugToSurfaceData after filling the surfarcedata and before filling builtinData
            // as it can modify attribute use for static lighting
            ApplyDebugToSurfaceData(fragInputs.tangentToWorld, surfaceData);
    #endif

            // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion as PBR master node don't have any option
            surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
        }

        void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData)
        {
    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
            LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
    #endif

            float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
            // doubleSidedConstants = float3(-1.0, -1.0, -1.0);
            doubleSidedConstants = float3( 1.0,  1.0, -1.0);

            ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants);

            SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
            SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);

            // Perform alpha test very early to save performance (a killed pixel will not sample textures)
            // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
            DoAlphaTest(surfaceDescription.Alpha, surfaceDescription.AlphaClipThreshold);

            BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);

            // Builtin Data
            // For back lighting we use the oposite vertex normal
            InitBuiltinData(posInput, surfaceDescription.Alpha, surfaceData.normalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);

            // builtinData.emissiveColor = surfaceDescription.Emission;

            PostInitBuiltinData(V, posInput, surfaceData, builtinData);
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
        // based on HDPBRPass.template
        Name "GBuffer"
        Tags { "LightMode" = "GBuffer" }

        //-------------------------------------------------------------------------------------
        // Render Modes (Blend, Cull, ZTest, Stencil, etc)
        //-------------------------------------------------------------------------------------
        
        Cull Off

        ZTest Equal

        
        
        // Stencil setup
    Stencil
    {
       WriteMask 14
       Ref  10
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

        #pragma multi_compile_instancing
        #pragma instancing_options renderinglayer

        #pragma multi_compile _ LOD_FADE_CROSSFADE

        //-------------------------------------------------------------------------------------
        // Graph Defines
        //-------------------------------------------------------------------------------------
                // Shared Graph Keywords
                #define SHADERPASS SHADERPASS_GBUFFER
                #pragma multi_compile _ DEBUG_DISPLAY
                #pragma multi_compile _ LIGHTMAP_ON
                #pragma multi_compile _ DIRLIGHTMAP_COMBINED
                #pragma multi_compile _ DYNAMICLIGHTMAP_ON
                #pragma multi_compile _ SHADOWS_SHADOWMASK
                #pragma multi_compile DECALS_OFF DECALS_3RT DECALS_4RT
                #pragma multi_compile _ LIGHT_LAYERS
                #ifndef DEBUG_DISPLAY
    #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
    #endif
                // ACTIVE FIELDS:
                //   DoubleSided
                //   DoubleSided.Mirror
                //   FragInputs.isFrontFace
                //   AlphaTest
                //   features.NormalDropOffTS
                //   SurfaceDescriptionInputs.ObjectSpaceNormal
                //   SurfaceDescriptionInputs.WorldSpaceNormal
                //   SurfaceDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescriptionInputs.WorldSpacePosition
                //   SurfaceDescriptionInputs.AbsoluteWorldSpacePosition
                //   SurfaceDescriptionInputs.uv0
                //   VertexDescriptionInputs.ObjectSpaceNormal
                //   VertexDescriptionInputs.ObjectSpaceTangent
                //   VertexDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescription.Albedo
                //   SurfaceDescription.Normal
                //   SurfaceDescription.Metallic
                //   SurfaceDescription.Emission
                //   SurfaceDescription.Smoothness
                //   SurfaceDescription.Occlusion
                //   SurfaceDescription.Alpha
                //   SurfaceDescription.AlphaClipThreshold
                //   FragInputs.tangentToWorld
                //   FragInputs.positionRWS
                //   FragInputs.texCoord1
                //   FragInputs.texCoord2
                //   VaryingsMeshToPS.cullFace
                //   FragInputs.texCoord0
                //   AttributesMesh.normalOS
                //   AttributesMesh.tangentOS
                //   AttributesMesh.positionOS
                //   VaryingsMeshToPS.tangentWS
                //   VaryingsMeshToPS.normalWS
                //   VaryingsMeshToPS.positionRWS
                //   VaryingsMeshToPS.texCoord1
                //   VaryingsMeshToPS.texCoord2
                //   VaryingsMeshToPS.texCoord0
                //   AttributesMesh.uv1
                //   AttributesMesh.uv2
                //   AttributesMesh.uv0
        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------
        // Variant Definitions (active field translations to HDRP defines)
        //-------------------------------------------------------------------------------------

        // #define _MATERIAL_FEATURE_SPECULAR_COLOR 1
        // #define _SURFACE_TYPE_TRANSPARENT 1
        // #define _BLENDMODE_ALPHA 1
        // #define _BLENDMODE_ADD 1
        // #define _BLENDMODE_PRE_MULTIPLY 1
        #define _DOUBLESIDED_ON 1
        #define _NORMAL_DROPOFF_TS	1
        // #define _NORMAL_DROPOFF_OS	1
        // #define _NORMAL_DROPOFF_WS	1

        //-------------------------------------------------------------------------------------
        // End Variant Definitions
        //-------------------------------------------------------------------------------------

        #pragma vertex Vert
        #pragma fragment Frag

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"

        // define FragInputs structure
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"

        //-------------------------------------------------------------------------------------
        // Active Field Defines
        //-------------------------------------------------------------------------------------

        // this translates the new dependency tracker into the old preprocessor definitions for the existing HDRP shader code
        #define ATTRIBUTES_NEED_NORMAL
        #define ATTRIBUTES_NEED_TANGENT
        #define ATTRIBUTES_NEED_TEXCOORD0
        #define ATTRIBUTES_NEED_TEXCOORD1
        #define ATTRIBUTES_NEED_TEXCOORD2
        // #define ATTRIBUTES_NEED_TEXCOORD3
        // #define ATTRIBUTES_NEED_COLOR
        #define VARYINGS_NEED_POSITION_WS
        #define VARYINGS_NEED_TANGENT_TO_WORLD
        #define VARYINGS_NEED_TEXCOORD0
        #define VARYINGS_NEED_TEXCOORD1
        #define VARYINGS_NEED_TEXCOORD2
        // #define VARYINGS_NEED_TEXCOORD3
        // #define VARYINGS_NEED_COLOR
        #define VARYINGS_NEED_CULLFACE
        // #define HAVE_MESH_MODIFICATION

        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------
    	

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #ifdef DEBUG_DISPLAY
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
        #endif

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"

    #if (SHADERPASS == SHADERPASS_FORWARD)
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/Lighting.hlsl"

        #define HAS_LIGHTLOOP

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoopDef.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoop.hlsl"
    #else
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
    #endif

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"

        //Used by SceneSelectionPass
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
                float4 texCoord1; // optional
                float4 texCoord2; // optional
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
                float4 interp04 : TEXCOORD4; // auto-packed
                float4 interp05 : TEXCOORD5; // auto-packed
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
                output.interp04.xyzw = input.texCoord1;
                output.interp05.xyzw = input.texCoord2;
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
                output.texCoord1 = input.interp04.xyzw;
                output.texCoord2 = input.interp05.xyzw;
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
        float Vector1_FCB2FF33;
        float _Metallic;
        float _Smoothness;
        float4 _EmissiveColor;
        float _EmissiveIntensity;
        float _EmissiveExposureWeight;
        CBUFFER_END
        TEXTURE2D(_BaseColorMap); SAMPLER(sampler_BaseColorMap); float4 _BaseColorMap_TexelSize;
        TEXTURE2D(_MaskMap); SAMPLER(sampler_MaskMap); float4 _MaskMap_TexelSize;
        TEXTURE2D(_NormalMap); SAMPLER(sampler_NormalMap); float4 _NormalMap_TexelSize;
        TEXTURE2D(_EmissiveColorMap); SAMPLER(sampler_EmissiveColorMap); float4 _EmissiveColorMap_TexelSize;
        SAMPLER(_SampleTexture2D_2231EDA7_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_EBE6E655_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_A32F7A5B_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_2993A4AD_Sampler_3_Linear_Repeat);

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
        float3 Albedo;
        float3 Normal;
        float Metallic;
        float3 Emission;
        float Smoothness;
        float Occlusion;
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

        void Unity_Multiply_float(float A, float B, out float Out)
        {
            Out = A * B;
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

        void Unity_Add_float(float A, float B, out float Out)
        {
            Out = A + B;
        }

                // Pixel Graph Evaluation


//Advanced Dissolve
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Core.cginc"


                    SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float4 _Property_46446BCB_Out_0 = _BaseColor;
        float4 _SampleTexture2D_2231EDA7_RGBA_0 = SAMPLE_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, IN.uv0.xy);
        float _SampleTexture2D_2231EDA7_R_4 = _SampleTexture2D_2231EDA7_RGBA_0.r;
        float _SampleTexture2D_2231EDA7_G_5 = _SampleTexture2D_2231EDA7_RGBA_0.g;
        float _SampleTexture2D_2231EDA7_B_6 = _SampleTexture2D_2231EDA7_RGBA_0.b;
        float _SampleTexture2D_2231EDA7_A_7 = _SampleTexture2D_2231EDA7_RGBA_0.a;
        float4 _Multiply_141A51E_Out_2;
        Unity_Multiply_float(_Property_46446BCB_Out_0, _SampleTexture2D_2231EDA7_RGBA_0, _Multiply_141A51E_Out_2);
        float4 _SampleTexture2D_EBE6E655_RGBA_0 = SAMPLE_TEXTURE2D(_NormalMap, sampler_NormalMap, IN.uv0.xy);
        _SampleTexture2D_EBE6E655_RGBA_0.rgb = UnpackNormal(_SampleTexture2D_EBE6E655_RGBA_0);
        float _SampleTexture2D_EBE6E655_R_4 = _SampleTexture2D_EBE6E655_RGBA_0.r;
        float _SampleTexture2D_EBE6E655_G_5 = _SampleTexture2D_EBE6E655_RGBA_0.g;
        float _SampleTexture2D_EBE6E655_B_6 = _SampleTexture2D_EBE6E655_RGBA_0.b;
        float _SampleTexture2D_EBE6E655_A_7 = _SampleTexture2D_EBE6E655_RGBA_0.a;
        float4 _Property_119E2903_Out_0 = _EmissiveColor;
        float4 _SampleTexture2D_A32F7A5B_RGBA_0 = SAMPLE_TEXTURE2D(_EmissiveColorMap, sampler_EmissiveColorMap, IN.uv0.xy);
        float _SampleTexture2D_A32F7A5B_R_4 = _SampleTexture2D_A32F7A5B_RGBA_0.r;
        float _SampleTexture2D_A32F7A5B_G_5 = _SampleTexture2D_A32F7A5B_RGBA_0.g;
        float _SampleTexture2D_A32F7A5B_B_6 = _SampleTexture2D_A32F7A5B_RGBA_0.b;
        float _SampleTexture2D_A32F7A5B_A_7 = _SampleTexture2D_A32F7A5B_RGBA_0.a;
        float4 _Multiply_36554B06_Out_2;
        Unity_Multiply_float(_Property_119E2903_Out_0, _SampleTexture2D_A32F7A5B_RGBA_0, _Multiply_36554B06_Out_2);
        float _Property_DAC26131_Out_0 = _EmissiveIntensity;
        float _Property_1E50B4E1_Out_0 = _EmissiveExposureWeight;
        #ifdef SHADERGRAPH_PREVIEW
        float inverseExposureMultiplier = 1.0;
        #else
        float inverseExposureMultiplier = GetInverseCurrentExposureMultiplier();
        #endif
        float3 _EmissionNode_CB31D1AF_Output_0 = Unity_HDRP_GetEmissionHDRColor_float((_Multiply_36554B06_Out_2.xyz).xyz, ConvertEvToLuminance(_Property_DAC26131_Out_0), _Property_1E50B4E1_Out_0, inverseExposureMultiplier);
        float _Property_DB6A213A_Out_0 = _Metallic;
        float4 _SampleTexture2D_2993A4AD_RGBA_0 = SAMPLE_TEXTURE2D(_MaskMap, sampler_MaskMap, IN.uv0.xy);
        float _SampleTexture2D_2993A4AD_R_4 = _SampleTexture2D_2993A4AD_RGBA_0.r;
        float _SampleTexture2D_2993A4AD_G_5 = _SampleTexture2D_2993A4AD_RGBA_0.g;
        float _SampleTexture2D_2993A4AD_B_6 = _SampleTexture2D_2993A4AD_RGBA_0.b;
        float _SampleTexture2D_2993A4AD_A_7 = _SampleTexture2D_2993A4AD_RGBA_0.a;
        float _Multiply_738B5170_Out_2;
        Unity_Multiply_float(_Property_DB6A213A_Out_0, _SampleTexture2D_2993A4AD_R_4, _Multiply_738B5170_Out_2);
        float _Property_D2EC53B3_Out_0 = _Smoothness;
        float _Multiply_FF35CABB_Out_2;
        Unity_Multiply_float(_Property_D2EC53B3_Out_0, _SampleTexture2D_2993A4AD_A_7, _Multiply_FF35CABB_Out_2);
        float _Property_4AB6CADC_Out_0 = Vector1_FCB2FF33;
        float _Multiply_8B49D9AB_Out_2;
        Unity_Multiply_float(_Property_4AB6CADC_Out_0, 1.01, _Multiply_8B49D9AB_Out_2);
        Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab _AdvancedDissolve_ED28DB36;
        _AdvancedDissolve_ED28DB36.ObjectSpaceNormal = IN.ObjectSpaceNormal;
        _AdvancedDissolve_ED28DB36.WorldSpaceNormal = IN.WorldSpaceNormal;
        _AdvancedDissolve_ED28DB36.ObjectSpacePosition = IN.ObjectSpacePosition;
        _AdvancedDissolve_ED28DB36.WorldSpacePosition = IN.WorldSpacePosition;
        _AdvancedDissolve_ED28DB36.AbsoluteWorldSpacePosition = IN.AbsoluteWorldSpacePosition;
        _AdvancedDissolve_ED28DB36.uv0 = IN.uv0;
        float _AdvancedDissolve_ED28DB36_Out_3;
        SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(0, float4 (0, 0, 0, 1), _AdvancedDissolve_ED28DB36, _AdvancedDissolve_ED28DB36_Out_3);
        float _Add_4768B504_Out_2;
        Unity_Add_float(_Multiply_8B49D9AB_Out_2, _AdvancedDissolve_ED28DB36_Out_3, _Add_4768B504_Out_2);
        surface.Albedo = (_Multiply_141A51E_Out_2.xyz);
        surface.Normal = (_SampleTexture2D_EBE6E655_RGBA_0.xyz);
        surface.Metallic = _Multiply_738B5170_Out_2;
        surface.Emission = _EmissionNode_CB31D1AF_Output_0;
        surface.Smoothness = _Multiply_FF35CABB_Out_2;
        surface.Occlusion = _SampleTexture2D_2993A4AD_G_5;
        surface.Alpha = _SampleTexture2D_2231EDA7_A_7;
        surface.AlphaClipThreshold = _Add_4768B504_Out_2;


//GBuffer
AdvancedDissolveShaderGraph(IN.uv0.xy, IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, 0, 1, surface.Albedo, surface.Emission, surface.Alpha, surface.AlphaClipThreshold);


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
            output.texCoord1 = input.texCoord1;
            output.texCoord2 = input.texCoord2;
            // output.texCoord3 = input.texCoord3;
            // output.color = input.color;
            #if _DOUBLESIDED_ON && SHADER_STAGE_FRAGMENT
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #elif SHADER_STAGE_FRAGMENT
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
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
            surfaceData.ambientOcclusion = 1.0;
            surfaceData.specularOcclusion = 1.0; // This need to be init here to quiet the compiler in case of decal, but can be override later.

            // copy across graph values, if defined
            surfaceData.baseColor =             surfaceDescription.Albedo;
            surfaceData.perceptualSmoothness =  surfaceDescription.Smoothness;
            surfaceData.ambientOcclusion =      surfaceDescription.Occlusion;
            surfaceData.metallic =              surfaceDescription.Metallic;
            // surfaceData.specularColor =         surfaceDescription.Specular;

            // These static material feature allow compile time optimization
            surfaceData.materialFeatures = MATERIALFEATUREFLAGS_LIT_STANDARD;
    #ifdef _MATERIAL_FEATURE_SPECULAR_COLOR
            surfaceData.materialFeatures |= MATERIALFEATUREFLAGS_LIT_SPECULAR_COLOR;
    #endif

            float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
            // doubleSidedConstants = float3(-1.0, -1.0, -1.0);
            doubleSidedConstants = float3( 1.0,  1.0, -1.0);

            // normal delivered to master node
            float3 normalSrc = float3(0.0f, 0.0f, 1.0f);
            normalSrc = surfaceDescription.Normal;

            // compute world space normal
    #if _NORMAL_DROPOFF_TS
            GetNormalWS(fragInputs, normalSrc, surfaceData.normalWS, doubleSidedConstants);
    #elif _NORMAL_DROPOFF_OS
    		surfaceData.normalWS = TransformObjectToWorldNormal(normalSrc);
    #elif _NORMAL_DROPOFF_WS
    		surfaceData.normalWS = normalSrc;
    #endif

            surfaceData.geomNormalWS = fragInputs.tangentToWorld[2];
            surfaceData.tangentWS = normalize(fragInputs.tangentToWorld[0].xyz);    // The tangent is not normalize in tangentToWorld for mikkt. TODO: Check if it expected that we normalize with Morten. Tag: SURFACE_GRADIENT

    #if HAVE_DECALS
            if (_EnableDecals)
            {
                // Both uses and modifies 'surfaceData.normalWS'.
                DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, surfaceDescription.Alpha);
                ApplyDecalToSurfaceData(decalSurfaceData, surfaceData);
            }
    #endif

            surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

    #ifdef DEBUG_DISPLAY
            if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
            {
                // TODO: need to update mip info
                surfaceData.metallic = 0;
            }

            // We need to call ApplyDebugToSurfaceData after filling the surfarcedata and before filling builtinData
            // as it can modify attribute use for static lighting
            ApplyDebugToSurfaceData(fragInputs.tangentToWorld, surfaceData);
    #endif

            // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion as PBR master node don't have any option
            surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
        }

        void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData)
        {
    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
            LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
    #endif

            float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
            // doubleSidedConstants = float3(-1.0, -1.0, -1.0);
            doubleSidedConstants = float3( 1.0,  1.0, -1.0);

            ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants);

            SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
            SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);

            // Perform alpha test very early to save performance (a killed pixel will not sample textures)
            // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
            DoAlphaTest(surfaceDescription.Alpha, surfaceDescription.AlphaClipThreshold);

            BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);

            // Builtin Data
            // For back lighting we use the oposite vertex normal
            InitBuiltinData(posInput, surfaceDescription.Alpha, surfaceData.normalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);

            builtinData.emissiveColor = surfaceDescription.Emission;

            PostInitBuiltinData(V, posInput, surfaceData, builtinData);
        }

        //-------------------------------------------------------------------------------------
        // Pass Includes
        //-------------------------------------------------------------------------------------
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassGBuffer.hlsl"
        //-------------------------------------------------------------------------------------
        // End Pass Includes
        //-------------------------------------------------------------------------------------

        ENDHLSL
    }

        Pass
    {
        // based on HDPBRPass.template
        Name "MotionVectors"
        Tags { "LightMode" = "MotionVectors" }

        //-------------------------------------------------------------------------------------
        // Render Modes (Blend, Cull, ZTest, Stencil, etc)
        //-------------------------------------------------------------------------------------
        
        Cull Off

        
        
        
        // Stencil setup
    Stencil
    {
       WriteMask 40
       Ref  40
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

        #pragma multi_compile_instancing
        #pragma instancing_options renderinglayer

        #pragma multi_compile _ LOD_FADE_CROSSFADE

        //-------------------------------------------------------------------------------------
        // Graph Defines
        //-------------------------------------------------------------------------------------
                // Shared Graph Keywords
                #define SHADERPASS SHADERPASS_MOTION_VECTORS
                #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
                #pragma multi_compile _ WRITE_NORMAL_BUFFER
                #pragma multi_compile _ WRITE_MSAA_DEPTH
                #define RAYTRACING_SHADER_GRAPH_HIGH
                // ACTIVE FIELDS:
                //   DoubleSided
                //   AlphaTest
                //   features.NormalDropOffTS
                //   SurfaceDescriptionInputs.ObjectSpaceNormal
                //   SurfaceDescriptionInputs.WorldSpaceNormal
                //   SurfaceDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescriptionInputs.WorldSpacePosition
                //   SurfaceDescriptionInputs.AbsoluteWorldSpacePosition
                //   SurfaceDescriptionInputs.uv0
                //   VertexDescriptionInputs.ObjectSpaceNormal
                //   VertexDescriptionInputs.ObjectSpaceTangent
                //   VertexDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescription.Normal
                //   SurfaceDescription.Smoothness
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
        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------
        // Variant Definitions (active field translations to HDRP defines)
        //-------------------------------------------------------------------------------------

        // #define _MATERIAL_FEATURE_SPECULAR_COLOR 1
        // #define _SURFACE_TYPE_TRANSPARENT 1
        // #define _BLENDMODE_ALPHA 1
        // #define _BLENDMODE_ADD 1
        // #define _BLENDMODE_PRE_MULTIPLY 1
        #define _DOUBLESIDED_ON 1
        #define _NORMAL_DROPOFF_TS	1
        // #define _NORMAL_DROPOFF_OS	1
        // #define _NORMAL_DROPOFF_WS	1

        //-------------------------------------------------------------------------------------
        // End Variant Definitions
        //-------------------------------------------------------------------------------------

        #pragma vertex Vert
        #pragma fragment Frag

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"

        // define FragInputs structure
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"

        //-------------------------------------------------------------------------------------
        // Active Field Defines
        //-------------------------------------------------------------------------------------

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
        #define VARYINGS_NEED_CULLFACE
        // #define HAVE_MESH_MODIFICATION

        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------
    	

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #ifdef DEBUG_DISPLAY
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
        #endif

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"

    #if (SHADERPASS == SHADERPASS_FORWARD)
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/Lighting.hlsl"

        #define HAS_LIGHTLOOP

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoopDef.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoop.hlsl"
    #else
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
    #endif

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"

        //Used by SceneSelectionPass
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
        float Vector1_FCB2FF33;
        float _Metallic;
        float _Smoothness;
        float4 _EmissiveColor;
        float _EmissiveIntensity;
        float _EmissiveExposureWeight;
        CBUFFER_END
        TEXTURE2D(_BaseColorMap); SAMPLER(sampler_BaseColorMap); float4 _BaseColorMap_TexelSize;
        TEXTURE2D(_MaskMap); SAMPLER(sampler_MaskMap); float4 _MaskMap_TexelSize;
        TEXTURE2D(_NormalMap); SAMPLER(sampler_NormalMap); float4 _NormalMap_TexelSize;
        TEXTURE2D(_EmissiveColorMap); SAMPLER(sampler_EmissiveColorMap); float4 _EmissiveColorMap_TexelSize;
        SAMPLER(_SampleTexture2D_EBE6E655_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_2993A4AD_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_2231EDA7_Sampler_3_Linear_Repeat);

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
        float3 Normal;
        float Smoothness;
        float Alpha;
        float AlphaClipThreshold;
    };

                // Shared Graph Node Functions
                
        void Unity_Multiply_float(float A, float B, out float Out)
        {
            Out = A * B;
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

        void Unity_Add_float(float A, float B, out float Out)
        {
            Out = A + B;
        }

                // Pixel Graph Evaluation


//Advanced Dissolve
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Core.cginc"


                    SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float4 _SampleTexture2D_EBE6E655_RGBA_0 = SAMPLE_TEXTURE2D(_NormalMap, sampler_NormalMap, IN.uv0.xy);
        _SampleTexture2D_EBE6E655_RGBA_0.rgb = UnpackNormal(_SampleTexture2D_EBE6E655_RGBA_0);
        float _SampleTexture2D_EBE6E655_R_4 = _SampleTexture2D_EBE6E655_RGBA_0.r;
        float _SampleTexture2D_EBE6E655_G_5 = _SampleTexture2D_EBE6E655_RGBA_0.g;
        float _SampleTexture2D_EBE6E655_B_6 = _SampleTexture2D_EBE6E655_RGBA_0.b;
        float _SampleTexture2D_EBE6E655_A_7 = _SampleTexture2D_EBE6E655_RGBA_0.a;
        float _Property_D2EC53B3_Out_0 = _Smoothness;
        float4 _SampleTexture2D_2993A4AD_RGBA_0 = SAMPLE_TEXTURE2D(_MaskMap, sampler_MaskMap, IN.uv0.xy);
        float _SampleTexture2D_2993A4AD_R_4 = _SampleTexture2D_2993A4AD_RGBA_0.r;
        float _SampleTexture2D_2993A4AD_G_5 = _SampleTexture2D_2993A4AD_RGBA_0.g;
        float _SampleTexture2D_2993A4AD_B_6 = _SampleTexture2D_2993A4AD_RGBA_0.b;
        float _SampleTexture2D_2993A4AD_A_7 = _SampleTexture2D_2993A4AD_RGBA_0.a;
        float _Multiply_FF35CABB_Out_2;
        Unity_Multiply_float(_Property_D2EC53B3_Out_0, _SampleTexture2D_2993A4AD_A_7, _Multiply_FF35CABB_Out_2);
        float4 _SampleTexture2D_2231EDA7_RGBA_0 = SAMPLE_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, IN.uv0.xy);
        float _SampleTexture2D_2231EDA7_R_4 = _SampleTexture2D_2231EDA7_RGBA_0.r;
        float _SampleTexture2D_2231EDA7_G_5 = _SampleTexture2D_2231EDA7_RGBA_0.g;
        float _SampleTexture2D_2231EDA7_B_6 = _SampleTexture2D_2231EDA7_RGBA_0.b;
        float _SampleTexture2D_2231EDA7_A_7 = _SampleTexture2D_2231EDA7_RGBA_0.a;
        float _Property_4AB6CADC_Out_0 = Vector1_FCB2FF33;
        float _Multiply_8B49D9AB_Out_2;
        Unity_Multiply_float(_Property_4AB6CADC_Out_0, 1.01, _Multiply_8B49D9AB_Out_2);
        Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab _AdvancedDissolve_ED28DB36;
        _AdvancedDissolve_ED28DB36.ObjectSpaceNormal = IN.ObjectSpaceNormal;
        _AdvancedDissolve_ED28DB36.WorldSpaceNormal = IN.WorldSpaceNormal;
        _AdvancedDissolve_ED28DB36.ObjectSpacePosition = IN.ObjectSpacePosition;
        _AdvancedDissolve_ED28DB36.WorldSpacePosition = IN.WorldSpacePosition;
        _AdvancedDissolve_ED28DB36.AbsoluteWorldSpacePosition = IN.AbsoluteWorldSpacePosition;
        _AdvancedDissolve_ED28DB36.uv0 = IN.uv0;
        float _AdvancedDissolve_ED28DB36_Out_3;
        SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(0, float4 (0, 0, 0, 1), _AdvancedDissolve_ED28DB36, _AdvancedDissolve_ED28DB36_Out_3);
        float _Add_4768B504_Out_2;
        Unity_Add_float(_Multiply_8B49D9AB_Out_2, _AdvancedDissolve_ED28DB36_Out_3, _Add_4768B504_Out_2);
        surface.Normal = (_SampleTexture2D_EBE6E655_RGBA_0.xyz);
        surface.Smoothness = _Multiply_FF35CABB_Out_2;
        surface.Alpha = _SampleTexture2D_2231EDA7_A_7;
        surface.AlphaClipThreshold = _Add_4768B504_Out_2;


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
            surfaceData.ambientOcclusion = 1.0;
            surfaceData.specularOcclusion = 1.0; // This need to be init here to quiet the compiler in case of decal, but can be override later.

            // copy across graph values, if defined
            // surfaceData.baseColor =             surfaceDescription.Albedo;
            surfaceData.perceptualSmoothness =  surfaceDescription.Smoothness;
            // surfaceData.ambientOcclusion =      surfaceDescription.Occlusion;
            // surfaceData.metallic =              surfaceDescription.Metallic;
            // surfaceData.specularColor =         surfaceDescription.Specular;

            // These static material feature allow compile time optimization
            surfaceData.materialFeatures = MATERIALFEATUREFLAGS_LIT_STANDARD;
    #ifdef _MATERIAL_FEATURE_SPECULAR_COLOR
            surfaceData.materialFeatures |= MATERIALFEATUREFLAGS_LIT_SPECULAR_COLOR;
    #endif

            float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
            // doubleSidedConstants = float3(-1.0, -1.0, -1.0);
            // doubleSidedConstants = float3( 1.0,  1.0, -1.0);

            // normal delivered to master node
            float3 normalSrc = float3(0.0f, 0.0f, 1.0f);
            normalSrc = surfaceDescription.Normal;

            // compute world space normal
    #if _NORMAL_DROPOFF_TS
            GetNormalWS(fragInputs, normalSrc, surfaceData.normalWS, doubleSidedConstants);
    #elif _NORMAL_DROPOFF_OS
    		surfaceData.normalWS = TransformObjectToWorldNormal(normalSrc);
    #elif _NORMAL_DROPOFF_WS
    		surfaceData.normalWS = normalSrc;
    #endif

            surfaceData.geomNormalWS = fragInputs.tangentToWorld[2];
            surfaceData.tangentWS = normalize(fragInputs.tangentToWorld[0].xyz);    // The tangent is not normalize in tangentToWorld for mikkt. TODO: Check if it expected that we normalize with Morten. Tag: SURFACE_GRADIENT

    #if HAVE_DECALS
            if (_EnableDecals)
            {
                // Both uses and modifies 'surfaceData.normalWS'.
                DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, surfaceDescription.Alpha);
                ApplyDecalToSurfaceData(decalSurfaceData, surfaceData);
            }
    #endif

            surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

    #ifdef DEBUG_DISPLAY
            if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
            {
                // TODO: need to update mip info
                surfaceData.metallic = 0;
            }

            // We need to call ApplyDebugToSurfaceData after filling the surfarcedata and before filling builtinData
            // as it can modify attribute use for static lighting
            ApplyDebugToSurfaceData(fragInputs.tangentToWorld, surfaceData);
    #endif

            // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion as PBR master node don't have any option
            surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
        }

        void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData)
        {
    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
            LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
    #endif

            float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
            // doubleSidedConstants = float3(-1.0, -1.0, -1.0);
            // doubleSidedConstants = float3( 1.0,  1.0, -1.0);

            ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants);

            SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
            SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);

            // Perform alpha test very early to save performance (a killed pixel will not sample textures)
            // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
            DoAlphaTest(surfaceDescription.Alpha, surfaceDescription.AlphaClipThreshold);

            BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);

            // Builtin Data
            // For back lighting we use the oposite vertex normal
            InitBuiltinData(posInput, surfaceDescription.Alpha, surfaceData.normalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);

            // builtinData.emissiveColor = surfaceDescription.Emission;

            PostInitBuiltinData(V, posInput, surfaceData, builtinData);
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
        // based on HDPBRPass.template
        Name "Forward"
        Tags { "LightMode" = "Forward" }

        //-------------------------------------------------------------------------------------
        // Render Modes (Blend, Cull, ZTest, Stencil, etc)
        //-------------------------------------------------------------------------------------
        Blend One Zero, One Zero

        Cull Off

        ZTest Equal

        
        
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

        #pragma multi_compile_instancing
        #pragma instancing_options renderinglayer

        #pragma multi_compile _ LOD_FADE_CROSSFADE

        //-------------------------------------------------------------------------------------
        // Graph Defines
        //-------------------------------------------------------------------------------------
                // Shared Graph Keywords
                #define SHADERPASS SHADERPASS_FORWARD
                #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
                #pragma multi_compile _ DEBUG_DISPLAY
                #pragma multi_compile _ LIGHTMAP_ON
                #pragma multi_compile _ DIRLIGHTMAP_COMBINED
                #pragma multi_compile _ DYNAMICLIGHTMAP_ON
                #pragma multi_compile _ SHADOWS_SHADOWMASK
                #pragma multi_compile DECALS_OFF DECALS_3RT DECALS_4RT
                #pragma multi_compile USE_FPTL_LIGHTLIST USE_CLUSTERED_LIGHTLIST
                #pragma multi_compile SHADOW_LOW SHADOW_MEDIUM SHADOW_HIGH
                #ifndef DEBUG_DISPLAY
    #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
    #endif
                // ACTIVE FIELDS:
                //   DoubleSided
                //   DoubleSided.Mirror
                //   FragInputs.isFrontFace
                //   AlphaTest
                //   features.NormalDropOffTS
                //   SurfaceDescriptionInputs.ObjectSpaceNormal
                //   SurfaceDescriptionInputs.WorldSpaceNormal
                //   SurfaceDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescriptionInputs.WorldSpacePosition
                //   SurfaceDescriptionInputs.AbsoluteWorldSpacePosition
                //   SurfaceDescriptionInputs.uv0
                //   VertexDescriptionInputs.ObjectSpaceNormal
                //   VertexDescriptionInputs.ObjectSpaceTangent
                //   VertexDescriptionInputs.ObjectSpacePosition
                //   SurfaceDescription.Albedo
                //   SurfaceDescription.Normal
                //   SurfaceDescription.Metallic
                //   SurfaceDescription.Emission
                //   SurfaceDescription.Smoothness
                //   SurfaceDescription.Occlusion
                //   SurfaceDescription.Alpha
                //   SurfaceDescription.AlphaClipThreshold
                //   FragInputs.tangentToWorld
                //   FragInputs.positionRWS
                //   FragInputs.texCoord1
                //   FragInputs.texCoord2
                //   VaryingsMeshToPS.cullFace
                //   FragInputs.texCoord0
                //   AttributesMesh.normalOS
                //   AttributesMesh.tangentOS
                //   AttributesMesh.positionOS
                //   VaryingsMeshToPS.tangentWS
                //   VaryingsMeshToPS.normalWS
                //   VaryingsMeshToPS.positionRWS
                //   VaryingsMeshToPS.texCoord1
                //   VaryingsMeshToPS.texCoord2
                //   VaryingsMeshToPS.texCoord0
                //   AttributesMesh.uv1
                //   AttributesMesh.uv2
                //   AttributesMesh.uv0
        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------
        // Variant Definitions (active field translations to HDRP defines)
        //-------------------------------------------------------------------------------------

        // #define _MATERIAL_FEATURE_SPECULAR_COLOR 1
        // #define _SURFACE_TYPE_TRANSPARENT 1
        // #define _BLENDMODE_ALPHA 1
        // #define _BLENDMODE_ADD 1
        // #define _BLENDMODE_PRE_MULTIPLY 1
        #define _DOUBLESIDED_ON 1
        #define _NORMAL_DROPOFF_TS	1
        // #define _NORMAL_DROPOFF_OS	1
        // #define _NORMAL_DROPOFF_WS	1

        //-------------------------------------------------------------------------------------
        // End Variant Definitions
        //-------------------------------------------------------------------------------------

        #pragma vertex Vert
        #pragma fragment Frag

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"

        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"

        // define FragInputs structure
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"

        //-------------------------------------------------------------------------------------
        // Active Field Defines
        //-------------------------------------------------------------------------------------

        // this translates the new dependency tracker into the old preprocessor definitions for the existing HDRP shader code
        #define ATTRIBUTES_NEED_NORMAL
        #define ATTRIBUTES_NEED_TANGENT
        #define ATTRIBUTES_NEED_TEXCOORD0
        #define ATTRIBUTES_NEED_TEXCOORD1
        #define ATTRIBUTES_NEED_TEXCOORD2
        // #define ATTRIBUTES_NEED_TEXCOORD3
        // #define ATTRIBUTES_NEED_COLOR
        #define VARYINGS_NEED_POSITION_WS
        #define VARYINGS_NEED_TANGENT_TO_WORLD
        #define VARYINGS_NEED_TEXCOORD0
        #define VARYINGS_NEED_TEXCOORD1
        #define VARYINGS_NEED_TEXCOORD2
        // #define VARYINGS_NEED_TEXCOORD3
        // #define VARYINGS_NEED_COLOR
        #define VARYINGS_NEED_CULLFACE
        // #define HAVE_MESH_MODIFICATION

        //-------------------------------------------------------------------------------------
        // End Defines
        //-------------------------------------------------------------------------------------
    	

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
        #ifdef DEBUG_DISPLAY
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
        #endif

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"

    #if (SHADERPASS == SHADERPASS_FORWARD)
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/Lighting.hlsl"

        #define HAS_LIGHTLOOP

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoopDef.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/LightLoop/LightLoop.hlsl"
    #else
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/Lit.hlsl"
    #endif

        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Decal/DecalUtilities.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Lit/LitDecalData.hlsl"
        #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"

        //Used by SceneSelectionPass
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
                float4 texCoord1; // optional
                float4 texCoord2; // optional
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
                float4 interp04 : TEXCOORD4; // auto-packed
                float4 interp05 : TEXCOORD5; // auto-packed
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
                output.interp04.xyzw = input.texCoord1;
                output.interp05.xyzw = input.texCoord2;
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
                output.texCoord1 = input.interp04.xyzw;
                output.texCoord2 = input.interp05.xyzw;
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
        float Vector1_FCB2FF33;
        float _Metallic;
        float _Smoothness;
        float4 _EmissiveColor;
        float _EmissiveIntensity;
        float _EmissiveExposureWeight;
        CBUFFER_END
        TEXTURE2D(_BaseColorMap); SAMPLER(sampler_BaseColorMap); float4 _BaseColorMap_TexelSize;
        TEXTURE2D(_MaskMap); SAMPLER(sampler_MaskMap); float4 _MaskMap_TexelSize;
        TEXTURE2D(_NormalMap); SAMPLER(sampler_NormalMap); float4 _NormalMap_TexelSize;
        TEXTURE2D(_EmissiveColorMap); SAMPLER(sampler_EmissiveColorMap); float4 _EmissiveColorMap_TexelSize;
        SAMPLER(_SampleTexture2D_2231EDA7_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_EBE6E655_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_A32F7A5B_Sampler_3_Linear_Repeat);
        SAMPLER(_SampleTexture2D_2993A4AD_Sampler_3_Linear_Repeat);

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
        float3 Albedo;
        float3 Normal;
        float Metallic;
        float3 Emission;
        float Smoothness;
        float Occlusion;
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

        void Unity_Multiply_float(float A, float B, out float Out)
        {
            Out = A * B;
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

        void Unity_Add_float(float A, float B, out float Out)
        {
            Out = A + B;
        }

                // Pixel Graph Evaluation


//Advanced Dissolve
#include "Assets/Amazing Assets/Advanced Dissolve/Shaders/cginc/Core.cginc"


                    SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
    {
        SurfaceDescription surface = (SurfaceDescription)0;
        float4 _Property_46446BCB_Out_0 = _BaseColor;
        float4 _SampleTexture2D_2231EDA7_RGBA_0 = SAMPLE_TEXTURE2D(_BaseColorMap, sampler_BaseColorMap, IN.uv0.xy);
        float _SampleTexture2D_2231EDA7_R_4 = _SampleTexture2D_2231EDA7_RGBA_0.r;
        float _SampleTexture2D_2231EDA7_G_5 = _SampleTexture2D_2231EDA7_RGBA_0.g;
        float _SampleTexture2D_2231EDA7_B_6 = _SampleTexture2D_2231EDA7_RGBA_0.b;
        float _SampleTexture2D_2231EDA7_A_7 = _SampleTexture2D_2231EDA7_RGBA_0.a;
        float4 _Multiply_141A51E_Out_2;
        Unity_Multiply_float(_Property_46446BCB_Out_0, _SampleTexture2D_2231EDA7_RGBA_0, _Multiply_141A51E_Out_2);
        float4 _SampleTexture2D_EBE6E655_RGBA_0 = SAMPLE_TEXTURE2D(_NormalMap, sampler_NormalMap, IN.uv0.xy);
        _SampleTexture2D_EBE6E655_RGBA_0.rgb = UnpackNormal(_SampleTexture2D_EBE6E655_RGBA_0);
        float _SampleTexture2D_EBE6E655_R_4 = _SampleTexture2D_EBE6E655_RGBA_0.r;
        float _SampleTexture2D_EBE6E655_G_5 = _SampleTexture2D_EBE6E655_RGBA_0.g;
        float _SampleTexture2D_EBE6E655_B_6 = _SampleTexture2D_EBE6E655_RGBA_0.b;
        float _SampleTexture2D_EBE6E655_A_7 = _SampleTexture2D_EBE6E655_RGBA_0.a;
        float4 _Property_119E2903_Out_0 = _EmissiveColor;
        float4 _SampleTexture2D_A32F7A5B_RGBA_0 = SAMPLE_TEXTURE2D(_EmissiveColorMap, sampler_EmissiveColorMap, IN.uv0.xy);
        float _SampleTexture2D_A32F7A5B_R_4 = _SampleTexture2D_A32F7A5B_RGBA_0.r;
        float _SampleTexture2D_A32F7A5B_G_5 = _SampleTexture2D_A32F7A5B_RGBA_0.g;
        float _SampleTexture2D_A32F7A5B_B_6 = _SampleTexture2D_A32F7A5B_RGBA_0.b;
        float _SampleTexture2D_A32F7A5B_A_7 = _SampleTexture2D_A32F7A5B_RGBA_0.a;
        float4 _Multiply_36554B06_Out_2;
        Unity_Multiply_float(_Property_119E2903_Out_0, _SampleTexture2D_A32F7A5B_RGBA_0, _Multiply_36554B06_Out_2);
        float _Property_DAC26131_Out_0 = _EmissiveIntensity;
        float _Property_1E50B4E1_Out_0 = _EmissiveExposureWeight;
        #ifdef SHADERGRAPH_PREVIEW
        float inverseExposureMultiplier = 1.0;
        #else
        float inverseExposureMultiplier = GetInverseCurrentExposureMultiplier();
        #endif
        float3 _EmissionNode_CB31D1AF_Output_0 = Unity_HDRP_GetEmissionHDRColor_float((_Multiply_36554B06_Out_2.xyz).xyz, ConvertEvToLuminance(_Property_DAC26131_Out_0), _Property_1E50B4E1_Out_0, inverseExposureMultiplier);
        float _Property_DB6A213A_Out_0 = _Metallic;
        float4 _SampleTexture2D_2993A4AD_RGBA_0 = SAMPLE_TEXTURE2D(_MaskMap, sampler_MaskMap, IN.uv0.xy);
        float _SampleTexture2D_2993A4AD_R_4 = _SampleTexture2D_2993A4AD_RGBA_0.r;
        float _SampleTexture2D_2993A4AD_G_5 = _SampleTexture2D_2993A4AD_RGBA_0.g;
        float _SampleTexture2D_2993A4AD_B_6 = _SampleTexture2D_2993A4AD_RGBA_0.b;
        float _SampleTexture2D_2993A4AD_A_7 = _SampleTexture2D_2993A4AD_RGBA_0.a;
        float _Multiply_738B5170_Out_2;
        Unity_Multiply_float(_Property_DB6A213A_Out_0, _SampleTexture2D_2993A4AD_R_4, _Multiply_738B5170_Out_2);
        float _Property_D2EC53B3_Out_0 = _Smoothness;
        float _Multiply_FF35CABB_Out_2;
        Unity_Multiply_float(_Property_D2EC53B3_Out_0, _SampleTexture2D_2993A4AD_A_7, _Multiply_FF35CABB_Out_2);
        float _Property_4AB6CADC_Out_0 = Vector1_FCB2FF33;
        float _Multiply_8B49D9AB_Out_2;
        Unity_Multiply_float(_Property_4AB6CADC_Out_0, 1.01, _Multiply_8B49D9AB_Out_2);
        Bindings_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab _AdvancedDissolve_ED28DB36;
        _AdvancedDissolve_ED28DB36.ObjectSpaceNormal = IN.ObjectSpaceNormal;
        _AdvancedDissolve_ED28DB36.WorldSpaceNormal = IN.WorldSpaceNormal;
        _AdvancedDissolve_ED28DB36.ObjectSpacePosition = IN.ObjectSpacePosition;
        _AdvancedDissolve_ED28DB36.WorldSpacePosition = IN.WorldSpacePosition;
        _AdvancedDissolve_ED28DB36.AbsoluteWorldSpacePosition = IN.AbsoluteWorldSpacePosition;
        _AdvancedDissolve_ED28DB36.uv0 = IN.uv0;
        float _AdvancedDissolve_ED28DB36_Out_3;
        SG_AdvancedDissolve_40a0ec735cfda6043bd217c139a901ab(0, float4 (0, 0, 0, 1), _AdvancedDissolve_ED28DB36, _AdvancedDissolve_ED28DB36_Out_3);
        float _Add_4768B504_Out_2;
        Unity_Add_float(_Multiply_8B49D9AB_Out_2, _AdvancedDissolve_ED28DB36_Out_3, _Add_4768B504_Out_2);
        surface.Albedo = (_Multiply_141A51E_Out_2.xyz);
        surface.Normal = (_SampleTexture2D_EBE6E655_RGBA_0.xyz);
        surface.Metallic = _Multiply_738B5170_Out_2;
        surface.Emission = _EmissionNode_CB31D1AF_Output_0;
        surface.Smoothness = _Multiply_FF35CABB_Out_2;
        surface.Occlusion = _SampleTexture2D_2993A4AD_G_5;
        surface.Alpha = _SampleTexture2D_2231EDA7_A_7;
        surface.AlphaClipThreshold = _Add_4768B504_Out_2;


//Forward
AdvancedDissolveShaderGraph(IN.uv0.xy, IN.ObjectSpacePosition, IN.WorldSpacePosition, IN.AbsoluteWorldSpacePosition, IN.ObjectSpaceNormal, IN.WorldSpaceNormal, 0, 1, surface.Albedo, surface.Emission, surface.Alpha, surface.AlphaClipThreshold);


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
            output.texCoord1 = input.texCoord1;
            output.texCoord2 = input.texCoord2;
            // output.texCoord3 = input.texCoord3;
            // output.color = input.color;
            #if _DOUBLESIDED_ON && SHADER_STAGE_FRAGMENT
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
            #elif SHADER_STAGE_FRAGMENT
            output.isFrontFace = IS_FRONT_VFACE(input.cullFace, true, false);
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
            surfaceData.ambientOcclusion = 1.0;
            surfaceData.specularOcclusion = 1.0; // This need to be init here to quiet the compiler in case of decal, but can be override later.

            // copy across graph values, if defined
            surfaceData.baseColor =             surfaceDescription.Albedo;
            surfaceData.perceptualSmoothness =  surfaceDescription.Smoothness;
            surfaceData.ambientOcclusion =      surfaceDescription.Occlusion;
            surfaceData.metallic =              surfaceDescription.Metallic;
            // surfaceData.specularColor =         surfaceDescription.Specular;

            // These static material feature allow compile time optimization
            surfaceData.materialFeatures = MATERIALFEATUREFLAGS_LIT_STANDARD;
    #ifdef _MATERIAL_FEATURE_SPECULAR_COLOR
            surfaceData.materialFeatures |= MATERIALFEATUREFLAGS_LIT_SPECULAR_COLOR;
    #endif

            float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
            // doubleSidedConstants = float3(-1.0, -1.0, -1.0);
            doubleSidedConstants = float3( 1.0,  1.0, -1.0);

            // normal delivered to master node
            float3 normalSrc = float3(0.0f, 0.0f, 1.0f);
            normalSrc = surfaceDescription.Normal;

            // compute world space normal
    #if _NORMAL_DROPOFF_TS
            GetNormalWS(fragInputs, normalSrc, surfaceData.normalWS, doubleSidedConstants);
    #elif _NORMAL_DROPOFF_OS
    		surfaceData.normalWS = TransformObjectToWorldNormal(normalSrc);
    #elif _NORMAL_DROPOFF_WS
    		surfaceData.normalWS = normalSrc;
    #endif

            surfaceData.geomNormalWS = fragInputs.tangentToWorld[2];
            surfaceData.tangentWS = normalize(fragInputs.tangentToWorld[0].xyz);    // The tangent is not normalize in tangentToWorld for mikkt. TODO: Check if it expected that we normalize with Morten. Tag: SURFACE_GRADIENT

    #if HAVE_DECALS
            if (_EnableDecals)
            {
                // Both uses and modifies 'surfaceData.normalWS'.
                DecalSurfaceData decalSurfaceData = GetDecalSurfaceData(posInput, surfaceDescription.Alpha);
                ApplyDecalToSurfaceData(decalSurfaceData, surfaceData);
            }
    #endif

            surfaceData.tangentWS = Orthonormalize(surfaceData.tangentWS, surfaceData.normalWS);

    #ifdef DEBUG_DISPLAY
            if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
            {
                // TODO: need to update mip info
                surfaceData.metallic = 0;
            }

            // We need to call ApplyDebugToSurfaceData after filling the surfarcedata and before filling builtinData
            // as it can modify attribute use for static lighting
            ApplyDebugToSurfaceData(fragInputs.tangentToWorld, surfaceData);
    #endif

            // By default we use the ambient occlusion with Tri-ace trick (apply outside) for specular occlusion as PBR master node don't have any option
            surfaceData.specularOcclusion = GetSpecularOcclusionFromAmbientOcclusion(ClampNdotV(dot(surfaceData.normalWS, V)), surfaceData.ambientOcclusion, PerceptualSmoothnessToRoughness(surfaceData.perceptualSmoothness));
        }

        void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData)
        {
    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
            LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
    #endif

            float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
            // doubleSidedConstants = float3(-1.0, -1.0, -1.0);
            doubleSidedConstants = float3( 1.0,  1.0, -1.0);

            ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants);

            SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
            SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);

            // Perform alpha test very early to save performance (a killed pixel will not sample textures)
            // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
            DoAlphaTest(surfaceDescription.Alpha, surfaceDescription.AlphaClipThreshold);

            BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);

            // Builtin Data
            // For back lighting we use the oposite vertex normal
            InitBuiltinData(posInput, surfaceDescription.Alpha, surfaceData.normalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);

            builtinData.emissiveColor = surfaceDescription.Emission;

            PostInitBuiltinData(V, posInput, surfaceData, builtinData);
        }

        //-------------------------------------------------------------------------------------
        // Pass Includes
        //-------------------------------------------------------------------------------------
            #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassForward.hlsl"
        //-------------------------------------------------------------------------------------
        // End Pass Includes
        //-------------------------------------------------------------------------------------

        ENDHLSL
    }

    }
    //CustomEditor "UnityEditor.Rendering.HighDefinition.HDPBRLitGUI"
    CustomEditor "AmazingAssets.AdvancedDissolveEditor.ShaderGraph.DefaultShaderGraphGUI"
    FallBack "Hidden/Shader Graph/FallbackError"
}

