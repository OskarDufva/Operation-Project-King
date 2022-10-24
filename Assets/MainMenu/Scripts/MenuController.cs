using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField] private TMP_Text _volumeTextValue = null;
    [SerializeField] private Slider _volumeSlider = null;
    [SerializeField] private float _defaultVolume = 1f;

    [Header("Gameplay Settings")]
    [SerializeField] private TMP_Text _controllerSensTextValue = null;
    [SerializeField] private Slider _controllerSlider = null;
    [SerializeField] private int _defaultSens = 4;
    public int MainControllerSens = 4;

    [Header("Toggle Settings")]
    [SerializeField] private Toggle _invertYToggle = null;

    [Header("Graphics Settings")]
    [SerializeField] private Slider _brightnessSlider = null;
    [SerializeField] TMP_Text _brightnessTextValue = null;
    [SerializeField] private float _DefaultBrightness = 1;

    private int _qualityLevel;
    private bool _isFullScreen;
    private float _brightnessLevel;

    [Header("Confirmation")]
    [SerializeField] private GameObject _confirmationPrompt = null;

    [Header("Levels To Load")]
    public string NewGameLevel;
    private string _levelToLoad;
    [SerializeField] private GameObject _noSavedGameDialog = null;

    //When pressing yes button on dialogScreen NewGameDialogScreen will load a new game
    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(NewGameLevel);
    }

    public void LoadGameDialogYes()
    {
        //will check for file called Saved Level and if yes will load the file called saved level.
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            _levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(_levelToLoad);
        }
        else
        {
            _noSavedGameDialog.SetActive(true);
        }
    }

    //Quites the applications
    public void ExitButton()
    {
        Application.Quit();
    }

    //Sets audo listener to value chosen on slider between 0 and 1 and changes text next to slider
    public void SetVolume(float Volume)
    {
        AudioListener.volume = Volume;
        _volumeTextValue.text = Volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("MasterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public void SetControllerSens(float sensitivity)
    {
        MainControllerSens = Mathf.RoundToInt(sensitivity);
        _controllerSensTextValue.text = sensitivity.ToString("0");
    }

    public void GameplayApply()
    {
        if (_invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("masterInvertY", 1);
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY", 0);
        }

        PlayerPrefs.SetFloat("masterSens", MainControllerSens);
        StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string MenuType)
    {
        if(MenuType == "Audio")
        {
            AudioListener.volume = _defaultVolume;
            _volumeSlider.value = _defaultVolume;
            _volumeTextValue.text = _defaultVolume.ToString("0.0");
            VolumeApply();
        }

        if (MenuType == "Gameplay")
        {
            _controllerSensTextValue.text = _defaultSens.ToString("0");
            _controllerSlider.value = _defaultSens;
            MainControllerSens = _defaultSens;
            _invertYToggle.isOn = false;
            GameplayApply();
        }
    }

    public IEnumerator ConfirmationBox()
    {
        _confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        _confirmationPrompt.SetActive(false);

    }
}
