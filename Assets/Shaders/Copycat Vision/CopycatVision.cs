using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using System;
using UnityEngine.Rendering.PostProcessing;

[Serializable, VolumeComponentMenu("Post-processing/Custom/Copycat Vision")]
public sealed class CopycatVision : CustomPostProcessVolumeComponent, IPostProcessComponent
{
    //[Tooltip("Controls the intensity of the effect.")]
    //public ClampedFloatParameter blurIntensity = new ClampedFloatParameter(0f, 0f, 1f);
    [Tooltip("Controls the intensity of the effect.")]
    public ClampedFloatParameter ghostingIntensity = new ClampedFloatParameter(0f, 0f, 1f);
    [Tooltip("Controls the intensity of the effect.")]
    public ClampedFloatParameter distortionIntensity = new ClampedFloatParameter(0f, 0f, 1f);
    [Tooltip("Controls the intensity of the effect.")]
    public ClampedFloatParameter distortionSpeed = new ClampedFloatParameter(0f, 0f, 1f);
    [Tooltip("Controls the intensity of the effect.")]
    public ClampedFloatParameter vignetteIntensity = new ClampedFloatParameter(0f, 0f, 1f);
    [Tooltip("Controls the intensity of the effect.")]
    public ClampedFloatParameter noiseIntensity = new ClampedFloatParameter(0f, 0f, 1f);

    Material _material;

    public bool IsActive() => _material != null && ghostingIntensity.value > 0 && distortionIntensity.value > 0 && distortionSpeed.value > 0 && vignetteIntensity.value > 0 && noiseIntensity.value > 0;

    public override CustomPostProcessInjectionPoint injectionPoint => CustomPostProcessInjectionPoint.BeforeTAA;

    public override void Setup()
    {
        if (Shader.Find("Hidden/Shader/CopycatVisionPostProcessing") != null)
            _material = new Material(Shader.Find("Hidden/Shader/CopycatVisionPostProcessing"));
    }

    public override void Render(CommandBuffer cmd, HDCamera camera, RTHandle source, RTHandle destination)
    {
        if (_material == null)
            return;

        _material.SetTexture("_MainTex", source);
        //m_Material.SetFloat("_BlurIntensity", blurIntensity.value);
        _material.SetFloat("_GhostingIntensity", ghostingIntensity.value);
        _material.SetFloat("_DistortionIntensity", distortionIntensity.value);
        _material.SetFloat("_DistortionSpeed", distortionSpeed.value);
        _material.SetFloat("_VignetteIntensity", vignetteIntensity.value);
        _material.SetFloat("_NoiseIntensity", noiseIntensity.value);
        HDUtils.DrawFullScreen(cmd, _material, destination);
    }

    public override void Cleanup() => CoreUtils.Destroy(_material);
}
