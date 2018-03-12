using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {

	public static GameUIController Instance { get; private set; }

    [SerializeField]
    Slider gravitySlider;    

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetGravitySlider(float value)
    {
        gravitySlider.value = value;
    }
}
