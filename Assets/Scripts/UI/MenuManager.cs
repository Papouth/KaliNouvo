using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;


    [Header("Main Menu")]
    [SerializeField]
    private UIDocument docMainMenu;
    public string sceneIntro;
    public string mainMenuScene;
    private VisualElement rootMainMenu;

    [Header("Settings Menu")]
    [SerializeField]
    private UIDocument docSettingsMenu;
    private VisualElement rootSettingsMenu;
    public AudioManager audioManager;
    public VisualTreeAsset docBinding;


    [Header("Credits Menu")]
    [SerializeField]
    private UIDocument docCreditMenu;
    private VisualElement rootCreditMenu;


    [Header("Play Menu")]
    [SerializeField]
    private UIDocument docPlayMenu;
    private VisualElement rootPlayMenu;

    private VisualElement currentVisualElement;
    private UIDocument lastMenuCheck;
    [SerializeField] private PlayerInputManager playerInput;
    private bool activeMenuGame;

    [Header("Tutoriel")]
    [SerializeField]
    private UIDocument docTutoMenu;
    private VisualElement rootTutoMenu;
    public Label infoText;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(Instance);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);

        if (docMainMenu) rootMainMenu = docMainMenu.rootVisualElement;
        else Debug.LogError("NO MAIN MENU REFERENCE");

        if (docSettingsMenu) rootSettingsMenu = docSettingsMenu.rootVisualElement;
        else Debug.LogError("NO SETTINGS MENU REFERENCE !");

        if (docCreditMenu) rootCreditMenu = docCreditMenu.rootVisualElement;
        else Debug.LogError("NO Credits MENU REFERENCE !");

        if (docPlayMenu) rootPlayMenu = docPlayMenu.rootVisualElement;
        else Debug.LogError("NO Play MENU REFERENCE !");

        if (docTutoMenu) rootTutoMenu = docTutoMenu.rootVisualElement;
        else Debug.LogError("NO TUTO MENU REFERENCE");

        SetMainMenu();
        SetOptionsMenu();
        SetCreditMenu();
        SetPlayMenu();
        SetTutoMenu();


        docMainMenu.rootVisualElement.style.display = DisplayStyle.Flex;
        docSettingsMenu.rootVisualElement.style.display = DisplayStyle.None;
        docCreditMenu.rootVisualElement.style.display = DisplayStyle.None;
        docPlayMenu.rootVisualElement.style.display = DisplayStyle.None;
        infoText.style.display = DisplayStyle.None;
    }

    private void Update()
    {
        EnableMenu();
    }

    /// <summary>
    /// Set the main menu settings
    /// </summary>
    private void SetMainMenu()
    {
        if (rootMainMenu == null) Debug.LogError("Can't set the main menu, null ref");

        Button newGameButton = rootMainMenu.Q<Button>("NewGame");
        Button optionButton = rootMainMenu.Q<Button>("Options");
        Button creditsButton = rootMainMenu.Q<Button>("Credits");
        Button leaveButton = rootMainMenu.Q<Button>("Leave");

        newGameButton.clickable.clicked += () => { LauchGame(); };
        optionButton.clickable.clicked += () => { EnableMenu(docSettingsMenu, docMainMenu); };
        creditsButton.clickable.clicked += () => { EnableMenu(docCreditMenu, docMainMenu); };
        leaveButton.clickable.clicked += LeaveGame;


        Debug.Log("Menu Set");
    }


    #region Settings Menu

    /// <summary>
    /// Set the option menu for button and activate input
    /// </summary>
    private void SetOptionsMenu()
    {
        if (rootSettingsMenu == null) Debug.LogError("Can't set the settings menu, null ref");

        Button audioButton = rootSettingsMenu.Q<Button>("Audio");
        Button manetteButton = rootSettingsMenu.Q<Button>("Manette");
        Button clavierButton = rootSettingsMenu.Q<Button>("Clavier");
        Button exitButton = rootSettingsMenu.Q<Button>("Leave");

        VisualElement audioVisual = rootSettingsMenu.Q<VisualElement>("AudioSetting");
        VisualElement manetteVisual = rootSettingsMenu.Q<VisualElement>("ManetteSetting");
        VisualElement clavierSetting = rootSettingsMenu.Q<VisualElement>("ClavierSetting");

        audioButton.clickable.clicked += () => { EnableVisualElement(audioVisual); };
        manetteButton.clickable.clicked += () => { EnableVisualElement(manetteVisual); };
        clavierButton.clickable.clicked += () => { EnableVisualElement(clavierSetting); };
        exitButton.clickable.clicked += () => { EnableMenu(lastMenuCheck, docSettingsMenu); };

        SetClavierSettings();
        SetAudioSettings();

        EnableVisualElement(audioVisual);

        Debug.Log("Option menu Set");
    }

    private void SetAudioSettings()
    {
        //Audio part :
        Slider sliderMasterVolume = rootSettingsMenu.Q<Slider>("MasterVolume");
        audioManager.allSlider[0] = sliderMasterVolume;
        Slider sliderMusicVolume = rootSettingsMenu.Q<Slider>("MusicVolume");
        audioManager.allSlider[1] = sliderMusicVolume;
        Slider sliderDialogueVolume = rootSettingsMenu.Q<Slider>("DialogueVolume");
        audioManager.allSlider[2] = sliderDialogueVolume;
        Slider sliderSFXVolume = rootSettingsMenu.Q<Slider>("SFXVolume");
        audioManager.allSlider[3] = sliderSFXVolume;


        sliderMasterVolume.RegisterValueChangedCallback(audioManager.SetMasterLevel);
        sliderMusicVolume.RegisterValueChangedCallback(audioManager.SetMusiqueLevel);
        sliderDialogueVolume.RegisterValueChangedCallback(audioManager.SetDialogueVolume);
        sliderSFXVolume.RegisterValueChangedCallback(audioManager.SetEffectLevel);

        audioManager.LoadAllLevel();
    }

    private void SetClavierSettings()
    {
        ScrollView scrollView = rootSettingsMenu.Q<ScrollView>("BindList");

        for (int i = 0; i < GameManager.GM.actionMap.Length; i++)
        {
            int j = i;
            VisualElement visualToAdd = docBinding.CloneTree();
            TextField textInput = visualToAdd.Q<TextField>("Input");

            textInput.label = GameManager.GM.actionMap[i].nameAction;

            textInput.RegisterCallback<MouseDownEvent>(evt =>
            {
                GameManager.GM.StartRebinding(j, textInput);
                Debug.Log("Change");
            });

            /*textInput.RegisterValueChangedCallback(evt =>
            {
                GameManager.GM.StartRebinding(j, textInput);
                Debug.Log("Change");
            });*/


            textInput.SetValueWithoutNotify(InputControlPath.ToHumanReadableString(
                GameManager.GM.actionMap[j].actionReference.action.bindings[0]
                .effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice));

            scrollView.Add(visualToAdd);
        }
    }

    #endregion


    /// <summary>
    /// Set the settings menu for button and activate input
    /// </summary>
    private void SetCreditMenu()
    {
        if (rootCreditMenu == null) Debug.LogError("Can't set the credit menu, null ref");

        Button leaveButton = rootCreditMenu.Q<Button>("Leave");
        leaveButton.clickable.clicked += () => { EnableMenu(docMainMenu, docCreditMenu); };

        Debug.Log("Credit menu Set");
    }

    /// <summary>
    /// Set the play menu of the game
    /// </summary>
    private void SetPlayMenu()
    {
        if (rootPlayMenu == null) Debug.LogError("Can't set the play  menu, null ref");

        Button resumeButton = rootPlayMenu.Q<Button>("Resume");
        Button optionButton = rootPlayMenu.Q<Button>("Options");
        Button leaveButton = rootPlayMenu.Q<Button>("Leave");

        resumeButton.clickable.clicked += () => { EnableMenu(null, docPlayMenu); Time.timeScale = 1; activeMenuGame = true; };
        optionButton.clickable.clicked += () => { EnableMenu(docSettingsMenu, docPlayMenu); };
        leaveButton.clickable.clicked += () => { EnableMenu(docMainMenu, docPlayMenu); BackMenuToMenu(); };

        Debug.Log("Play Menu Set");
    }

    private void SetTutoMenu()
    {
        infoText = rootTutoMenu.Q<Label>("TutoText");

    }


    #region DialogueSet
   
    public void MajInfoText(string sentences)
    {
        infoText.text = sentences;
    }

    /// <summary>
    /// Enable the tuto text
    /// </summary>
    /// <param name="enabled"></param>
    public void EnableInfoText(bool enabled)
    {
        if (enabled)
            infoText.style.display = DisplayStyle.Flex;
        else
            infoText.style.display = DisplayStyle.None;
    }


    #endregion

    #region MainMenuVoid

    /// <summary>
    /// Lauch the main game
    /// </summary>
    private void LauchGame()
    {
        Debug.Log("Game Lauch");

        EnableMenu(null, docMainMenu);
        Time.timeScale = 1;

        MusicManager.Instance.ChangeMusic(1);

        SceneManager.LoadScene(sceneIntro, LoadSceneMode.Additive);


    }


    private void BackMenuToMenu()
    {
        PlayerTemporel player = playerInput.GetComponent<PlayerTemporel>();

        player.GetComponent<CharacterController>().enabled = false;

        SceneManager.UnloadSceneAsync(player.present);
        SceneManager.UnloadSceneAsync(player.past);
    }

    /// <summary>
    /// Leave the game
    /// </summary>
    private void LeaveGame()
    {
        Debug.Log("You leave the game");
        Application.Quit();
    }

    #endregion


    /// <summary>
    /// Enable or disable a UI Menu 
    /// </summary>
    /// <param name="docToActivate">The UI Doc to activate</param>
    /// <param name="docToDisable">The UI Doc to disable</param>
    private void EnableMenu(UIDocument docToActivate, UIDocument docToDisable)
    {
        if (docToActivate != null)
        {
            Debug.Log("Enable menu : " + docToActivate.gameObject.name);
            docToActivate.rootVisualElement.style.display = DisplayStyle.Flex;
        }

        if (docToDisable != null)
        {
            docToDisable.rootVisualElement.style.display = DisplayStyle.None;
            lastMenuCheck = docToDisable;
        }
    }


    /// <summary>
    /// Enable or disable a Visual Element
    /// </summary>
    /// <param name="visualElementToActivate"></param>
    /// <param name="visualElementToDisable"></param>
    private void EnableVisualElement(VisualElement visualElementToActivate)
    {
        if (currentVisualElement != null)
        {
            currentVisualElement.style.display = DisplayStyle.None;
            Debug.Log("Disable Visual : " + currentVisualElement.name);
        }

        Debug.Log("Enable Visual : " + visualElementToActivate.name);
        visualElementToActivate.style.display = DisplayStyle.Flex;
        currentVisualElement = visualElementToActivate;
    }

    private void EnableMenu()
    {
        if (playerInput.CanMenu)
        {
            if (activeMenuGame)
            {
                Time.timeScale = 0;
                EnableMenu(docPlayMenu, null);
                activeMenuGame = false;
            }
            else
            {
                Time.timeScale = 1;
                EnableMenu(null, docPlayMenu);
                activeMenuGame = true;
            }

            playerInput.CanMenu = false;
        }
    }



}