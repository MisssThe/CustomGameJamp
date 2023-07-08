using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    public List<AudioClip> bgmAc;
    public List<AudioClip> dangerAc;
    public List<AudioClip> rewardAc;

    public Vector2Int point;
    //BGM（常驻）
    private AudioSource _bgmAs;
    //危险预警音（常驻）
    private AudioSource _dangerAs;
    //奖励提示音（常驻）
    private AudioSource _rewardAs;
    //撞墙、攻击等音 （短暂触发）
    private void Start()
    {
        this._bgmAs = this.gameObject.AddComponent<AudioSource>();
        this._dangerAs = this.gameObject.AddComponent<AudioSource>();
        this._rewardAs = this.gameObject.AddComponent<AudioSource>();
        this.InitAs(this._bgmAs);
        this.InitAs(this._dangerAs);
        this.InitAs(this._rewardAs);
        this.SetBGM(0);
    }

    private void InitAs(AudioSource audioSource)
    {
        if (audioSource == null)
        {
            return;
        }
        audioSource.loop = true;
    }

    private void Update()
    {
        this.UpdateVoice(this.point,Vector2Int.zero);
    }

    public void UpdateVoice(Vector2Int point, Vector2Int tryPoint)
    {
        //根据角色位置调整音乐大小
        int distance = MapDataCreator.FastWayItems[point.x][point.y].MinCount;
        float volume = 1.0f - (distance * 1.0f) / MapDataCreator.MaxDistance;
        this._bgmAs.volume = volume;
        //根据怪物位置进行预警
    }

    private void PlayVoice(int index, AudioSource audioSource, List<AudioClip> audioClip)
    {
        if (audioSource == null || audioClip == null)
        {
            return;
        }

        if (index < audioClip.Count)
        {
            index = (int)(audioClip.Count - 1);
        }

        audioSource.clip = audioClip[index];
        audioSource.Play();
    }

    private void MuteVoice(AudioSource audioSource)
    {
        if (!audioSource.isPlaying)
        {
            return;
        }
        audioSource.mute = true;
    }

    private void SetBGM(int index)
    {
        this.PlayVoice(index, this._bgmAs, this.bgmAc);
    }

    private void SetDanger(int index)
    {
        this.PlayVoice(index, this._dangerAs, this.dangerAc);
    }

    private void SetReward(int index)
    {
        this.PlayVoice(index, this._rewardAs, this.rewardAc);
    }

    private void SetPointVoice(int index)
    {
        
    }
}
