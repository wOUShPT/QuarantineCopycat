using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class DOFControlMixerBehaviour : PlayableBehaviour
{
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        VolumeProfile trackBinding = playerData as VolumeProfile;
        bool isOn = true;
        DofRange finalNearRange = new DofRange(0, 0);
        DofRange finalFarRange = new DofRange(0, 0);

        if (!trackBinding)
            return;

        int inputCount = playable.GetInputCount (); //get the number of all clips on this track

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<DOFControlBehaviour> inputPlayable = (ScriptPlayable<DOFControlBehaviour>)playable.GetInput(i);
            DOFControlBehaviour input = inputPlayable.GetBehaviour();

            // Use the above variables to process each frame of this playable.
            isOn = input.isOn;
            finalNearRange.Start.value += input.NearRange.Start.value * inputWeight;
            finalNearRange.End.value += input.NearRange.End.value * inputWeight;
            finalFarRange.Start.value += input.FarRange.Start.value * inputWeight;
            finalFarRange.End.value += input.FarRange.End.value * inputWeight;
        }

        if (!trackBinding.TryGet(out DepthOfField dof) && !dof.IsNearLayerActive())
        {
            return;
        }
        //assign the result to the bound object
        dof.active = isOn; 
        dof.nearFocusStart.overrideState = finalFarRange.Start.overrideState;
        dof.nearFocusEnd.overrideState = finalNearRange.End.overrideState;
        dof.farFocusStart.overrideState = finalFarRange.Start.overrideState;
        dof.farFocusEnd.overrideState = finalFarRange.End.overrideState;
        dof.nearFocusStart.value = finalNearRange.Start.value;
        dof.nearFocusEnd.value = finalNearRange.End.value;
        dof.farFocusStart.value = finalFarRange.Start.value;
        dof.farFocusEnd.value = finalFarRange.End.value;
    }
    
    [Serializable]
    public struct DofRange
    {
        public MinFloatParameter Start;
        public MinFloatParameter End;

        public DofRange(float start, float end)
        {
            Start = new MinFloatParameter(start, 0, true);
            End = new MinFloatParameter(end, 0, true);
        }
    }
    
}
