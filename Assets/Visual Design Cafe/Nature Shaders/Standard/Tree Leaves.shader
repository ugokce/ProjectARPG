Shader "Nature Shaders/Tree Leaves"
{
    Properties
    {
        // Transparency
        _Cutoff("Cutoff", Range(0, 1)) = 0.5

        // Color
        _HSL("Hue, Saturation, Lightness", Vector) = (0, 0, 0, 0)
        _HSLVariation("Hue, Saturation, Lightness Variation", Vector) = (0, 0, 0, 0)
        _Tint("Tint", Color) = (1, 1, 1, 1)
        _TintVariation("Tint Variation", Color) = (1, 1, 1, 1)
        _ColorVariationSpread("Color Variation Spread", Float) = 0.2

        // Surface
        [NoScaleOffset]_MainTex("Main Texture", 2D) = "white" {}
        [NoScaleOffset]_Albedo("Albedo", 2D) = "white" {}
        [NoScaleOffset]_BumpMap("Normal Map", 2D) = "bump" {}
        [NoScaleOffset]_MaskMap("Mask Map", 2D) = "white" {}
        [NoScaleOffset]_MetallicGlossMap("Metallic Gloss Map", 2D) = "black" {}
        [NoScaleOffset]_OcclusionMap("Occlusion Map", 2D) = "white" {}
        _GlossRemap("Remap Smoothness", Vector) = (0, 1, 0, 0)
        _OcclusionRemap("Remap Occlusion", Vector) = (0, 1, 0, 0)
        _BumpScale("Normal Map Strength", Range(0, 1)) = 1
        _Glossiness("Smoothness", Range(0, 1)) = 0.2
        _Metallic("Metallic", Range(0, 1)) = 0
        _VertexNormalStrength("Vertex Normal Strength", Range(0, 1)) = 1

        // Wind
        _ObjectHeight("Grass Height", Float) = 0.5
        _ObjectRadius("Grass Radius", Float) = 0.5
        _WindVariation("Wind Variation", Range(0, 1)) = 0.3
        _WindStrength("Wind Strength", Range(0, 2)) = 1
        _TurbulenceStrength("Turbulence Strength", Range(0, 2)) = 1
        _TrunkBendFactor("Trunk Bending", Vector) = (2, 0.3, 0, 0)

        // Translucency
        [NoScaleOffset]_ThicknessMap("Thickness Map", 2D) = "black" {}
        _Translucency("Translucency", Range(0, 2)) = 1
        _TranslucencyDistortion("Translucency Distortion", Range(0, 1)) = 0.5
        _TranslucencyScattering("Translucency Scattering", Range(0, 3)) = 2
        _TranslucencyColor("Translucency Color", Color) = (1, 1, 1, 1)
        _ThicknessRemap("Thickness Remap", Vector) = (0, 1, 0, 0)

        // Keywords
        [KeywordEnum(Baked, UV, Vertex)]_WIND_CONTROL("Wind Control", Float) = 2
        [KeywordEnum(Ambient, Gust, Turbulence, None)]_DEBUG("Debug Wind", Float) = 3
        [Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 0
        //[ToggleOff] _SpecularHighlights("Specular Highlights", Float) = 1.0
        //[ToggleOff] _GlossyReflections("Glossy Reflections", Float) = 1.0
    }
    SubShader
    {
        Tags
		{ 
			"RenderType" = "TransparentCutout"  
			"Queue" = "AlphaTest+0" 
			"DisableBatching" = "True"
			"NatureRendererInstancing" = "True"
		}
        LOD 200

        // Render State
        Blend One Zero, One Zero
        Cull [_Cull]
        ZTest LEqual
        ZWrite On
        // ColorMask: <None>

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface NatureShaderSurface StandardCustom vertex:NatureShaderVertex addshadow fullforwardshadows nolightmap dithercrossfade
        
        // Pragmas
        #pragma multi_compile_instancing
        #pragma instancing_options procedural:SetupNatureRenderer
        #pragma target 4.0
        #pragma multi_compile_fog
    
        // Keywords
        #pragma shader_feature_local _WIND_CONTROL_BAKED _WIND_CONTROL_UV
        #pragma shader_feature_local _COLOR_HSL
        #pragma shader_feature_local _SURFACE_MAP_MASK
        #pragma shader_feature_local _SURFACE_MAP_ON
        #pragma shader_feature_local _BUMP_MAP_ON
        #pragma shader_feature_local _PER_VERTEX_TRANSLUCENCY
        #pragma shader_feature_local _ALPHA_CLIP_DISABLED

        //#pragma shader_feature _SPECULARHIGHLIGHTS_OFF
        //#pragma shader_feature _GLOSSYREFLECTIONS_OFF

        // Defines
        #define NATURE_SHADERS
        #define STANDARD_RENDER_PIPELINE
        #define _TYPE_TREE_LEAVES
        #define TRANSLUCENT
        #define PROPERTY_Albedo
        #define PROPERTY_BumpMap
        #define PROPERTY_MaskMap
        #define PROPERTY_ObjectHeight
        #define PROPERTY__ObjectRadius
        #define PROPERTY_VertexNormalStrength
        #define PROPERTY_WindVariation
        #define PROPERTY_WindStrength
        #define PROPERTY_TurbulenceStrength
        #define PROPERTY_HSL
        #define PROPERTY_HSLVariation
        #define PROPERTY_GlossRemap
        #define PROPERTY_OcclusionMap
        #define PROPERTY_OcclusionRemap
        #define PROPERTY_BumpScale
        #define PROPERTY_Tint
        #define PROPERTY_TintVariation
        #define PROPERTY_Cutoff
        #define PROPERTY_TrunkBendFactor
        #define PROPERTY_ThicknessMap
        #define PROPERTY_Translucency
        #define PROPERTY_TranslucencyDistortion
        #define PROPERTY_TranslucencyScattering
        #define PROPERTY_TranslucencyColor
        #define PROPERTY_ThicknessRemap
        #define PROPERTY_ColorVariationSpread

        // Includes
        #include "../Common/Surface Shader.cginc"
        ENDCG
    }

    Dependency "OptimizedShader" = "Nature Shaders/Tree Leaves" 
    Fallback Off
	CustomEditor "VisualDesignCafe.Nature.Editor.NatureMaterialEditor"
}
