using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    [SerializeField]
    private string footStepEvent;
    public void PlayFootSteps()
    {
        FMODUnity.RuntimeManager.PlayOneShot(footStepEvent);
    }
}
