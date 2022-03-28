using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class SubtitleClip : PlayableAsset, ITimelineClipAsset
{
    public SubtitleBehaviour template = new SubtitleBehaviour();

    public ClipCaps clipCaps => ClipCaps.None;

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SubtitleBehaviour>.Create (graph, template);
        
        return playable;
    }
}
