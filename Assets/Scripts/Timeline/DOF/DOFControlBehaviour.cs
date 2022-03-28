using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class DOFControlBehaviour : PlayableBehaviour
{
    public bool isOn = true;
    public DOFControlMixerBehaviour.DofRange NearRange = new DOFControlMixerBehaviour.DofRange(0, 0);
    public DOFControlMixerBehaviour.DofRange FarRange = new DOFControlMixerBehaviour.DofRange(0, 0);
}
