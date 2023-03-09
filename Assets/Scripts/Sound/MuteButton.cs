using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI muteTextRef;
    [SerializeField] private string muteText, unmuteText;
    [SerializeField] private AudioMixer[] audioMixers;

    private bool isMuted = false;

    private void Start() {
        muteTextRef.text = muteText;
    }

    public void Mute() // is used from the Mute button
    {
        isMuted = !isMuted; // reverse switch

        foreach (var audioMixer in audioMixers)
        {
            if(isMuted) 
            {
                audioMixer.SetFloat("volume", -80f);
                muteTextRef.text = unmuteText;
            }
            if(!isMuted) 
            {
                audioMixer.SetFloat("volume", 0f);
                muteTextRef.text = muteText;
            }
        }
    }
}
