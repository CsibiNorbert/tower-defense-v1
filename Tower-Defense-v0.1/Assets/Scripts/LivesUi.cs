using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUi : MonoBehaviour
{
    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If this is on a mobile platform, then we might need to put this into a co-routine
        livesText.text = PlayerStats.playerLives + "LIVES";
    }
}
