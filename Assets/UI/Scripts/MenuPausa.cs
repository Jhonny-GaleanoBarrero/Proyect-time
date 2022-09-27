using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    private bool _juegoPausado = false;
    
    [Header("Options")]
    public Slider volumeFX;
    public Slider volumeMaster;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    
    [Header("Panels")]
    public GameObject pausaPanel;
    public GameObject optionsPanel;
    public GameObject botonPausa;

    public void Pausar()
    {
        _juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        pausaPanel.SetActive(true);
    }

    public void Reanudar()
    {
        _juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        pausaPanel.SetActive(false);
    }
    
    public void PlayLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
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
    private void Awake()
    {
        volumeFX.onValueChanged.AddListener(ChangeVolumeFX);
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
    }
    
    public void OpenPanel( GameObject panel)
    {
        pausaPanel.SetActive(false);
        optionsPanel.SetActive(false);

        panel.SetActive(true);
        PlaySoundButton();
    }
}
