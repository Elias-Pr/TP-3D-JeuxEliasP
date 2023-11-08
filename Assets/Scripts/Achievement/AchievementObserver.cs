using System;
using GameLoopEtHierarchie.Components;
using UnityEngine;
using UnityEngine.ProBuilder;

namespace Achievement
{
    [ExecuteAlways]
    public class AchievementObserver : Achievment.MonoBehaviourSingleton<AchievementObserver>
    {        
        private const string StrJumpCount = "JumpCount";
        private const string StrRed = "Red";
        private const string StrBlue = "Blue";
        private const string StrDeath = "Death";
        private const string StrWinGame = "Win";
        
        public int JumpCount
        {
            get => PlayerPrefs.GetInt(StrJumpCount);
            set => PlayerPrefs.SetInt(StrJumpCount, value);
        }

        public int Red
        {
            get => PlayerPrefs.GetInt(StrRed);
            set => PlayerPrefs.SetInt(StrRed, value);
        }

        public int Blue
        {
            get => PlayerPrefs.GetInt(StrBlue);
            set => PlayerPrefs.SetInt(StrBlue, value);        }

        public int Death
        {
            get => PlayerPrefs.GetInt(StrDeath);
            set => PlayerPrefs.SetInt(StrDeath, value);        }

        public int Win
        {
            get => PlayerPrefs.GetInt(StrWinGame);
            set => PlayerPrefs.SetInt(StrWinGame, value);        }



        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                ResetAll();
            }
        }

        private void OnEnable()
        {
            PlayerController.onJump += PlayerJumped;
            FireComponent.onBlue += BlueCreation;
            FireComponent.onRed += RedCreation;
            Kill.playerDeath += FirstDeath;
            WinCondition.playerWin += FirstWin;

            
        }

        private void OnDestroy()
        {
            PlayerController.onJump -= PlayerJumped;
            FireComponent.onBlue -= BlueCreation;
            FireComponent.onRed -= RedCreation;
            Kill.playerDeath -= FirstDeath;
            WinCondition.playerWin -= FirstWin;
            
            

        }
        
        public void PlayerJumped()
        {
            JumpCount++;
            PlayerPrefs.Save();

            if (JumpCount == 5)
            {
                Debug.Log("Mario Like");
            }
            
            if (JumpCount == 10) 
            {
                Debug.Log("SUPER Mario Like");
            }
        }
        
        public void BlueCreation()
        {
            Blue++;
            PlayerPrefs.Save();
            
            if (Blue == 1)
            {
                Debug.Log("This is not Portal");
            }

            if (Blue == 5)
            {
                Debug.Log("BUILD A BRIDGE !");
            }
        }
        
        public void RedCreation()
        {
            Red++;
            PlayerPrefs.Save();

            if (Red == 1)
            {
                Debug.Log("I SAID : This is not Portal");
            }
            
            if (Red == 3)
            {
                Debug.Log("I knew you would like it");
            }
        }

        public void FirstDeath()
        {
            Death++;
            PlayerPrefs.Save();

            if (Death == 1)
            {
                Debug.Log("Here we go again");
            }

            if (Death == 5)
            {
                Debug.Log("Having trouble ?");
            }
            
            if (Death == 10)
            {
                Debug.Log("Cmoooooooooon my grandma could do this !");
            }
        }
        
        public void FirstWin()
        {
            Win++;
            PlayerPrefs.Save();

            if (Win == 1)
            {
                Debug.Log("I like Interstellar, I dunno if it was clear");
            }
        }
        
        public  void ResetAll()
        {

            Debug.Log("ResetAll called");
    
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();

            Debug.Log("JumpCount: " + JumpCount);
            Debug.Log("Red: " + Red);
            Debug.Log("Blue: " + Blue);
            Debug.Log("Death: " + Death);
            Debug.Log("WinGame: " + Win);

        }
    }
}
