using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DOFControlAsset : PlayableAsset, ITimelineClipAsset
{
    public DOFControlBehaviour template;

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner) {
        var playable = ScriptPlayable<DOFControlBehaviour>.Create(graph, template);
        return playable;
    }

    public ClipCaps clipCaps => ClipCaps.All;
}
