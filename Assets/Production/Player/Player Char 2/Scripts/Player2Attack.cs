using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player2Attack : MonoBehaviour
{
    public bool isShooting;

    private CharacterAnimation player_Anim;

    private bool activateTimerToReset;

    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;

    private ComboState current_Combo_State;

    void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.NONE;
        isShooting = false;
    }

    
    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks()
    {

        if (CrossPlatformInputManager.GetButtonDown(Button.FIRE_1))
        {

            if (current_Combo_State == ComboState.KICK_2 || isShooting)
                return;


            current_Combo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            
            if (current_Combo_State == ComboState.PUNCH_3)
                current_Combo_State = ComboState.KICK_2;

            if (current_Combo_State == ComboState.PUNCH_1)
            {
                player_Anim.Punch_1();
            }

            if (current_Combo_State == ComboState.PUNCH_2)
            {
                player_Anim.Punch_2();
            }

            if (current_Combo_State == ComboState.KICK_2)
            {
                player_Anim.Kick_2();
            }

        } 

        
        if (CrossPlatformInputManager.GetButtonDown(Button.FIRE_2))
        {

            
            if (current_Combo_State == ComboState.KICK_2 || isShooting)
                return;

            
            current_Combo_State = ComboState.SHOOT;

            isShooting = true;

            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            player_Anim.Shoot();

        } 



    } 

    void ResetComboState()
    {

        if (activateTimerToReset)
        {

            current_Combo_Timer -= Time.deltaTime;

            if (current_Combo_Timer <= 0f)
            {

                current_Combo_State = ComboState.NONE;

                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;

            }

        }

    } 

} 
































