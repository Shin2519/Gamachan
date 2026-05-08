using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class SetSkill : MonoBehaviour
{
    [SerializeField] UIManager manager;



    public void PlusTime(float time)
    {
        manager.gameTimer += time;
    }
}



