using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOsmose : MonoBehaviour
{
    private PlayerInputManager playerInput;
    public bool stateOsmose;

    private PlayerInteractor playerInteractor;

    private PlayerInteractorDistance playerInteractorDistance;
    private PlayerStats playerStats;


    // D�mo Osmose Technologique
    public GameObject[] scenesPrefabs;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInputManager>();
        playerInteractor = GetComponent<PlayerInteractor>();
        playerInteractorDistance = GetComponent<PlayerInteractorDistance>();
    }

    private void Update()
    {
        UseOsmose();
    }

    private void UseOsmose()
    {
        if (playerInput.CanOsmose && playerStats.haveOsmose)
        {
            Debug.Log("Utilisation de l'Osmose Technologique en cours !");

            stateOsmose = !stateOsmose;

            if (stateOsmose == true)
            {

                playerInteractor.enabled = false;
                playerInteractorDistance.enabled = true;
                
                if(scenesPrefabs == null) return ;
                foreach (var prefab in scenesPrefabs)
                {
                    var rendMat = prefab.GetComponent<Renderer>().material;
                    Color color = rendMat.color;
                    color.a = 0.5f;
                    rendMat.color = color;
                }
            }
            else if (stateOsmose == false)
            {

                playerInteractor.enabled = true;
                playerInteractorDistance.enabled = false;

                foreach (var prefab in scenesPrefabs)
                {
                    var rendMat = prefab.GetComponent<Renderer>().material;
                    Color color = rendMat.color;
                    color.a = 1f;
                    rendMat.color = color;
                }
            }

            playerInput.CanOsmose = false;
            return;
        }

        return;
    }


}