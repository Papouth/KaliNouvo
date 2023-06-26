using UnityEngine;
using UnityEngine.SceneManagement;


public class PastToPresent : MonoBehaviour
{
    #region Variables
    [Header("Component")]
    //[SerializeField] private Rigidbody rb;
    [HideInInspector]
    public bool canLift;

    [Tooltip("Le prefab du passe")]
    public GameObject pastPrefab;

    [Tooltip("Le prefab du present")]
    public GameObject presentPrefab;


    [Header("Scenes Infos")]
    [SerializeField] private bool isPresent;
    private bool prefabState;
    [Tooltip("La scene dans laquelle la caisse se trouve")]
    public string actualScene;
    private Scene scene;
    private bool alreadyCheck;

    [Header("Plante Evolutive")]
    [Tooltip("Si le prefab est une plante : true \n Si le prefab n'est pas une plante : false")]
    [SerializeField] private bool isPlant;
    [Tooltip("Si la plante est dans un pot de fleur, elle peut evoluer")]
    private bool canEvo;


    [Header("Player Components")]
    private PlayerTemporel playerTemporel;
    #endregion

    #region Built In Methods
    private void Awake()
    {
        playerTemporel = FindObjectOfType<PlayerTemporel>();

        //rb = GetComponent<Rigidbody>();
        //if (rb == null) rb = GetComponentInChildren<Rigidbody>();
    }

    private void Start()
    {
        actualScene = SceneManager.GetActiveScene().name;
        scene = SceneManager.GetSceneByName(actualScene);
        alreadyCheck = false;

        if (scene.isLoaded && isPresent)
        {
            if (!gameObject.activeSelf) gameObject.SetActive(true);

            pastPrefab.SetActive(false);
            presentPrefab.SetActive(false);
        }
    }

    private void Update()
    {
        // Security
        if (!scene.isLoaded && !alreadyCheck)
        {
            alreadyCheck = true;
            gameObject.SetActive(false);
        }

        SceneFinder();

        //PushOnOff();

        LiftOnOff();
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pot2Fleur"))
        {
            canEvo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pot2Fleur"))
        {
            canEvo = false;
        }
    }


    /// <summary>
    /// Determine la temporalite dans laquelle le joueur se trouve actuellement
    /// </summary>
    private void SceneFinder()
    {
        // sceneState == false -> on est dans le present
        // sceneState == true -> on est dans le passe

        if(playerTemporel == null) return;

        if (!playerTemporel.sceneState)
        {
            //Debug.Log("On est dans le present");
            isPresent = true;

            if (isPlant)
            {
                if (prefabState && canEvo)
                {
                    // Si je n'ai pas encore modifier le prefab + que je suis en collision avec un pot de fleur
                    pastPrefab.SetActive(false);
                    presentPrefab.SetActive(true);
                    prefabState = !prefabState;
                }
                else if (prefabState && !canEvo)
                {
                    // Si pas encore modifier le prefab + pas en collision avec le pot de fleur
                    pastPrefab.SetActive(false);
                    presentPrefab.SetActive(false);
                    prefabState = !prefabState;
                }
            }
            else if (!isPlant)
            {
                if (prefabState)
                {
                    // Si je n'ai pas encore modifier le prefab
                    pastPrefab.SetActive(false);
                    presentPrefab.SetActive(true);
                    prefabState = !prefabState;
                }
            }

        }
        else if (playerTemporel.sceneState)
        {
            //Debug.Log("On est dans le passe");
            isPresent = false;


            // Si je n'ai pas encore modifier le prefab
            if (!prefabState)
            {
                presentPrefab.SetActive(false);
                pastPrefab.SetActive(true);
                prefabState = !prefabState;
            }
        }
    }

    /// <summary>
    /// Le joueur peut pousser l'objet dans le passe
    /// </summary>
    private void PushOnOff()
    {
        //if (isPresent) rb.isKinematic = true;
        //else if (!isPresent && !canLift) rb.isKinematic = false;
    }

    /// <summary>
    /// Le joueur ne peux pas porter l'objet dans le pr�sent
    /// </summary>
    private void LiftOnOff()
    {
        if (isPresent) canLift = false;
        else if (!isPresent) canLift = true;
    }
}