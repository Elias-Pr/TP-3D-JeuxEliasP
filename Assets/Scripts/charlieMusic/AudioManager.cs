using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace charlieMusic
{
    public class AudioManager : MonoBehaviourSingleton<AudioManager>
    {
            public AudioSource audioSource; // Main audio
            public AudioSource ambientAudioSource; // Ambient audio

            [Range(0, 1)] public float maximumVolume = 1f;
            [Range(0, 1)] public float ambientMaximumVolume = 1f;
            [Range(0, 1)] public float masterVolume = 1f; // Master volume control

            public Slider musicVolumeSlider;    // Slider for main volume
            public Slider ambientVolumeSlider; // Slider for ambient volume
            public Slider masterVolumeSlider;  // Slider for master volume

            private AudioClip _pendingAudioClip;

            private void Awake()
            {
                DontDestroyOnLoad(this.gameObject);
                SetMusicVolume(musicVolumeSlider.value);
                SetAmbientVolume(ambientVolumeSlider.value);
                SetMasterVolume(masterVolumeSlider.value);

                // Add listeners to sliders to update volume dynamically
                musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
                ambientVolumeSlider.onValueChanged.AddListener(SetAmbientVolume);
                masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
            }

            // Methods for setting volumes
            public void SetMusicVolume(float userMultiplier)
            {
                audioSource.volume = maximumVolume * userMultiplier * masterVolume;
            }

            public void SetAmbientVolume(float userMultiplier)
            {
                ambientAudioSource.volume = ambientMaximumVolume * userMultiplier * masterVolume;
            }

            public void SetMasterVolume(float newMasterVolume)
            {
                masterVolume = newMasterVolume; // Directly use master slider value
                SetMusicVolume(musicVolumeSlider.value);     // Apply master to music volume
                SetAmbientVolume(ambientVolumeSlider.value); // Apply master to ambient volume
            }

            public void PlayClip(AudioClip newClip)
        {
            audioSource.clip = newClip;
            audioSource.Play();
        }

        public void PauseAudio()
        {
            audioSource.Pause();
        }

        public void ResumeAudio()
        {
            audioSource.Play();
        }

        public void ChangeAudioClip(AudioClip newClip)
        {
            if (newClip == null) {
                throw new Exception("ERROR: Audio Manager!");
            }

            _pendingAudioClip = newClip;
            StartCoroutine(SwitchAudioClipWithFade());
        }

        public void ChangeAudioClip(string pathToAudioClip)
        {
            _pendingAudioClip = Resources.Load<AudioClip>(pathToAudioClip);
            StartCoroutine(SwitchAudioClipWithFade());
        }

        public IEnumerator FadeSound()
        {
            const float fadeTime = 1f;
            float t = 0f;
            float initialVolume = audioSource.volume;

            while (t < 1)
            {
                t += Time.deltaTime / fadeTime;
                audioSource.volume = Mathf.Lerp(initialVolume, 0.00f, t);
                yield return null;
            }
        }

        private IEnumerator SwitchAudioClipWithFade()
        {
            const float fadeTime = 1f;
            float t = 0f;
            float initialVolume = audioSource.volume;

            while (t < 1)
            {
                t += Time.unscaledDeltaTime / fadeTime;
                audioSource.volume = Mathf.Lerp(initialVolume, 0.00f, t);
                yield return null;
            }

            audioSource.Stop();
            audioSource.clip = _pendingAudioClip;
            audioSource.Play();
            t = 0f;

            while (t < 1)
            {
                t += Time.unscaledDeltaTime / fadeTime;
                audioSource.volume = Mathf.Lerp(0.00f, initialVolume, t);
                yield return null;
            }

            _pendingAudioClip = null;
        }
        
    }
}
