using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    public List<AudioSource> MusicSource = new List<AudioSource>();
    public List<AudioSource> EffectSource = new List<AudioSource>();
    public List<AudioSource> VoiceSource = new List<AudioSource>();

    public Slider sliderMusic;
    public Slider sliderEffect;
    public Slider sliderVoice;

    public void MusicVolume(){
        for(int i = 0; i< MusicSource.Count; i++){
            MusicSource[i].volume = sliderMusic.value;
        }
    }
    public void EffectVolume(){
        for (int i = 0; i < EffectSource.Count; i++){
            EffectSource[i].volume = sliderEffect.value;
        }
    }
    public void VoiceVolume(){
        for (int i = 0; i < VoiceSource.Count; i++){
            VoiceSource[i].volume = sliderVoice.value;
        }
    }
}
