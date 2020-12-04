using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
    [SerializeField] Text text;
    string randomCode;
    bool knowCode = false;
    bool mirror = false;
    private enum States {cell,mirror,sheets,lock1,freedom };
    private States myState;
	// Use this for initialization
	void Start () {
        myState = States.cell;
        randomCode = Random.Range(12345, 99999).ToString();
    }
	// Update is called once per frame
	void Update () {
        if (myState == States.cell)           {State_cell();}
        else if (myState == States.mirror)    {State_Mirror();}
        else if (myState == States.sheets)    {State_Sheets(); }
        else if (myState == States.lock1)     {State_Lock1(); }
        else if (myState == States.freedom)   {State_freedom(); }
    }
    #region Level States
    void State_freedom()
    {
        text.text = "Finnaly you can go home and take a cup of tea!" +
                    "\n\nPress R to play again ;)";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
    }
    void State_Mirror()
    {
        if (mirror)
        {
            text.text = "Just white wall." +
                    "\n\nPress R to Return";
        }
        else
        {
            text.text = "You look handsome!\n\n T to take mirror with you" +
            "\n\nPress R to Return";
            if (Input.GetKeyDown(KeyCode.T)) { mirror = true; myState = States.cell; }
        }
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
    }
    void State_Lock1()
    {
        if (knowCode)
        {
            text.text = "Yeah! The code is " + randomCode +
                                 "\n\n Press E to enter code, R to Return";
            if (Input.GetKeyDown(KeyCode.E)) { myState = States.freedom; }
        }
        else if (mirror)
        {
            text.text = "Hm...Maybe you can see code from other side?" +
                                "\n\nPress U to use mirror, R to Return";
            if (Input.GetKeyDown(KeyCode.U))
            {
                text.text = "Yeah! The code is " + Random.Range(12345, 99999).ToString() +
                                     "\n\n Press E to enter code, R to Return";
                knowCode = true;
                if (Input.GetKeyDown(KeyCode.E)) { myState = States.freedom; }
            }
        }
        else
        {
            text.text = "It's not moving. It's dead. Metal." +
                   "\n\nPress R to Return";

        }
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
    }
    void State_cell()
    {
        text.text = "You're finally awake. " +
                    "Door is closed. " +
                    "You are on the bed with wet towel. " +
                    "Some light playing in the mirror. " +
                    "Unknown symbols on walls" +
                    "\n\n" +
                    "Press S to view Sheets, M - view Mirror, L - Lock";

        if (Input.GetKeyDown(KeyCode.S))   {myState = States.sheets;}
        if (Input.GetKeyDown(KeyCode.M))    { myState = States.mirror; }
        if (Input.GetKeyDown(KeyCode.L))    { myState = States.lock1; }
    }
    void State_Sheets()
    {
        text.text = "Oh my...Such dirty sheets!"+
                     "\n\nPress R to Return";
        if (Input.GetKeyDown(KeyCode.R))    {myState = States.cell;}

    }
}
    #endregion