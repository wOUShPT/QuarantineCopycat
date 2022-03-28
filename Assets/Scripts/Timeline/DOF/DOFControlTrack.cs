using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Timeline;

[TrackClipType(typeof(DOFControlAsset))]
[TrackBindingType(typeof(VolumeProfile))]
public class DOFControlTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount) {
        return ScriptPlayable<DOFControlMixerBehaviour>.Create(graph, inputCount);
    }
}
