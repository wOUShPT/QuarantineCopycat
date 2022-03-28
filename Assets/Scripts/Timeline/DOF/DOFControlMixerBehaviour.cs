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
            //finalIntensity += input.intensity * inputWeight;
            finalNearRange.Start += input.NearRange.Start * inputWeight;
            finalNearRange.End += input.NearRange.End * inputWeight;
            finalFarRange.Start += input.FarRange.Start * inputWeight;
            finalFarRange.End += input.FarRange.End * inputWeight;
        }

        if (!trackBinding.TryGet(out DepthOfField dof) && !dof.IsNearLayerActive())
        {
            return;
        }
        //assign the result to the bound object
        dof.nearFocusStart.overrideState = true;
        dof.nearFocusEnd.overrideState = true;
        dof.farFocusStart.overrideState = true;
        dof.farFocusEnd.overrideState = true;
        dof.nearFocusStart.value = finalNearRange.Start;
        dof.nearFocusEnd.value = finalNearRange.End;
        dof.farFocusStart.value = finalFarRange.Start;
        dof.farFocusEnd.value = finalFarRange.End;
    }
    
    [Serializable]
    public struct DofRange
    {
        public float Start;
        public float End;

        public DofRange(float start, float end)
        {
            Start = start;
            End = end;
        }
    }
    
}
