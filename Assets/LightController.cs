using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightController : MonoBehaviour
{
    //Bloom Color Change retreived from: https://stackoverflow.com/questions/61706589/unity-postprocessing-changing-color-of-bloom-in-code
    public Light cylinderLight;
    private PostProcessVolume postProcessVolume;

    private void Start()
    {
        postProcessVolume = FindObjectOfType<PostProcessVolume>();
        Bloom bloom = postProcessVolume.profile.GetSetting<UnityEngine.Rendering.PostProcessing.Bloom>();
        var colorParameter = new UnityEngine.Rendering.PostProcessing.ColorParameter();
        colorParameter.value = Color.white;
        bloom.color.Override(colorParameter);
    }
    private void OnTriggerEnter(Collider other)
    {
        //When player enters Light collider - do light effect
        //because Post-processing volume is global it changes all of the lights bloom color which is not intended :(
        if (other.gameObject.CompareTag("Player"))
        {
            Bloom bloom = postProcessVolume.profile.GetSetting<UnityEngine.Rendering.PostProcessing.Bloom>();
            var colorParameter = new UnityEngine.Rendering.PostProcessing.ColorParameter();
            cylinderLight.color = Color.green;
            colorParameter.value = Color.green;
            bloom.color.Override(colorParameter);

        }
        else
        {
            Bloom bloom = postProcessVolume.profile.GetSetting<UnityEngine.Rendering.PostProcessing.Bloom>();
            var colorParameter = new UnityEngine.Rendering.PostProcessing.ColorParameter();
            cylinderLight.color = Color.white;
            colorParameter.value = Color.white;
            bloom.color.Override(colorParameter);
        }

    }
}
