using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObject/Scene")]
public class SceneData : ScriptableObject
{
    [Tooltip("Si il est true => La cut sc�ne � �tait lue \n si il est faux, il n'as pas encore �tait jou�")]
    public bool[] triggersCutSceneIsChecked;

}
