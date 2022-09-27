using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Scripts
{
    public class MainPanel : MonoBehaviour
    {
        [Header("Options")]
        public Slider volumeFX;
        public Slider volumeMaster;
        public AudioMixer mixer;
        public AudioSource fxSource;
        public AudioClip clickSound;
        [Header("Panels")]
        public GameObject mainPanel;
        public GameObject optionsPanel;    

 
        private void Awake()
        {
            volumeFX.onValueChanged.AddListener(ChangeVolumeFX);
            volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
        }

        public void PlayLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    
        public void OpenPanel( GameObject panel)
        {
            mainPanel.SetActive(false);
            optionsPanel.SetActive(false);

            panel.SetActive(true);
            PlaySoundButton();
        }

        public void ChangeVolumeMaster(float v)
        {
            mixer.SetFloat("VolMaster", v);
        }
        public void ChangeVolumeFX(float v)
        {
            mixer.SetFloat("VolFX", v);
        }
        public void PlaySoundButton()
        {
            fxSource.PlayOneShot(clickSound);
        }
    }
}
