using System;
using GameLoopEtHierarchie.Components;
using UnityEngine;
using UnityEngine.ProBuilder;

namespace Achievement
{
    [ExecuteAlways]
    public class AchievementObserver : Achievment.MonoBehaviourSingleton<AchievementObserver>
    {
        public static readonly string JumpCount = "JumpCount";
        public static readonly string Red = "Red";
        public static readonly string Blue = "Blue";
        public static readonly string Death = "Death";
        public static readonly string WinGame = "Win";
        
        
        
        private int _jumpCount = 0;
        
        private int _red = 0;
        private int _blue = 0;

        private int _death = 0;

        private int _win = 0;

        private void Awake()
        {
            _jumpCount = PlayerPrefs.GetInt(JumpCount, 0);
            _red = PlayerPrefs.GetInt(Red, 0);
            _blue = PlayerPrefs.GetInt(Blue, 0);
            _death = PlayerPrefs.GetInt(Death, 0);
            _win = PlayerPrefs.GetInt(WinGame, 0);
        }

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
            Win.playerWin += FirstWin;

            
        }

        private void OnDestroy()
        {
            PlayerController.onJump -= PlayerJumped;
            FireComponent.onBlue -= BlueCreation;
            FireComponent.onRed -= RedCreation;
            Kill.playerDeath -= FirstDeath;
            Win.playerWin -= FirstWin;
            
            

        }
        
        public void PlayerJumped()
        {
            _jumpCount++;
            PlayerPrefs.SetInt(JumpCount, _jumpCount);
            PlayerPrefs.Save();

            if (_jumpCount == 5)
            {
                Debug.Log("Mario Like");
            }
            
            if (_jumpCount == 10) 
            {
                Debug.Log("SUPER Mario Like");
            }
        }
        
        public void BlueCreation()
        {
            _blue++;
            PlayerPrefs.SetInt(Blue, _blue);
            PlayerPrefs.Save();
            
            if (_blue == 1)
            {
                Debug.Log("This is not Portal");
            }

            if (_blue == 5)
            {
                Debug.Log("You have 4s ...");
            }
        }
        
        public void RedCreation()
        {
            _red++;
            PlayerPrefs.SetInt(Red, _red);
            PlayerPrefs.Save();

            if (_blue == 1)
            {
                Debug.Log("I SAID : This is not Portal");
            }
            
            if (_red == 5)
            {
                Debug.Log("boiing");
            }
        }

        public void FirstDeath()
        {
            _death++;
            PlayerPrefs.SetInt(Death, _death);
            PlayerPrefs.Save();

            if (_death == 1)
            {
                Debug.Log("Here we go again");
            }

            if (_death == 5)
            {
                Debug.Log("Having trouble ?");
            }
            
            if (_death == 10)
            {
                Debug.Log("Cmoooooooooon my grandma could do this !");
            }
        }
        
        public void FirstWin()
        {
            _win++;
            PlayerPrefs.SetInt(WinGame, _win);
            PlayerPrefs.Save();
            
            Debug.Log("I like Interstellar, I dunno if it was clear");
        }

        
        public static void ResetAll()
        {

            Debug.Log("ResetAll called");
    
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();

            Debug.Log("JumpCount: " + PlayerPrefs.GetInt(JumpCount));
            Debug.Log("Red: " + PlayerPrefs.GetInt(Red));
            Debug.Log("Blue: " + PlayerPrefs.GetInt(Blue));
            Debug.Log("Death: " + PlayerPrefs.GetInt(Death));
            Debug.Log("WinGame: " + PlayerPrefs.GetInt(WinGame));

        }
    }
}
