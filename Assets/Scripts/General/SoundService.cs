using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Game.Services
{
    [Flags]
    public enum SoundEffect
    {
        /* Background music */
        BackgroundGame = 1 << 1,
        /* Common  */
        Click = 1 << 2,
        /* Player */
        Talk1 = 1 << 3,
        Talk2 = 1 << 4,
        Talk3 = 1 << 5,
        Death = 1 << 6,
        /* Audience */
        Applause = 1 << 7,
        Laugh1 = 1 << 8,
        Laugh2 = 1 << 9,
        Laugh3 = 1 << 10,
        Boo = 1 << 11,
        /* Minigames common  */
        AlarmMinigame = 1 << 12,
        StartMinigame = 1 << 13,
        FinishMinigame = 1 << 14,
        /* Background music bitset */
        Background = BackgroundGame
    }

    public class SoundService : MonoBehaviour
    {
        [SerializeField] private AudioSource _bgSource;
        [SerializeField] private AudioSource _effectsSource;

        private Dictionary<SoundEffect, AudioClip> _clips =
            new Dictionary<SoundEffect, AudioClip>();

        [SerializeField] private List<Sound> sounds = new List<Sound>();

        public bool SoundEnabled;
        public bool MusicEnabled;

        const string MusicEnabledKey = "MusicEnabled";
        const string SoundEnabledKey = "SoundEnabled";

        private void Awake()
        {
            MusicEnabled = PlayerPrefs.GetInt(MusicEnabledKey, 1) == 1;
            SoundEnabled = PlayerPrefs.GetInt(SoundEnabledKey, 1) == 1;
            foreach (var sound in sounds)
            {
                _clips.Add(sound.soundEffect, sound.clip);
            }
        }

        public void EnableSound(bool enable)
        {
            SoundEnabled = enable;
            PlayerPrefs.SetInt(SoundEnabledKey, enable ? 1 : 0);
        }

        public void EnableMusic(bool enable)
        {
            MusicEnabled = enable;
            PlayerPrefs.SetInt(MusicEnabledKey, enable ? 1 : 0);
            if (enable)
            {
                _bgSource.UnPause();
            }
            else
            {
                _bgSource.Pause();
            }
        }

        public void Play(SoundEffect soundEffect, float volume, bool loop = false)
        {
            var effect = GetEffect(soundEffect);
            if (effect == null) return;
            var audioSource = GetSource(soundEffect);
            if (!SoundEnabled && audioSource == _effectsSource)
            {
                return;
            }

            if (audioSource.clip == effect && loop)
                return;

            if (audioSource == _effectsSource)
            {
                audioSource.PlayOneShot(effect, volume);
            }
            else if (audioSource == _bgSource)
            {
                audioSource.Stop();
                audioSource.volume = volume;
                audioSource.loop = loop;
                audioSource.clip = effect;
                audioSource.Play();
            }

            if (!MusicEnabled && audioSource == _bgSource)
            {
                audioSource.Pause();
            }
        }

        public void Stop(SoundEffect soundEffect)
        {
            var effect = GetEffect(soundEffect);
            if (effect == null) return;
            var audioSource = GetSource(soundEffect);
            audioSource.Stop();
        }

        AudioSource GetSource(SoundEffect effect)
        {
            return (SoundEffect.Background & effect) != 0 ? _bgSource : _effectsSource;
        }

        private AudioClip GetEffect(SoundEffect soundEffect)
        {
            return !_clips.ContainsKey(soundEffect) ? null : _clips[soundEffect];
        }
    }

    [Serializable]
    public class Sound
    {
        public SoundEffect soundEffect;
        public AudioClip clip;
    }
}
