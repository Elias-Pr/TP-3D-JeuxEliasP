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
        private const string StrBounce = "Bounce";
        private const string StrLaunch = "GameLaunch";
        private const string StrCheckPoint = "CheckPoint";
        private const string StrPlatform = "Platform";
        private const string StrFireCooldown = "Platform";
        
        
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

        public int BounceCount
        {
            get => PlayerPrefs.GetInt(StrBounce);
            set => PlayerPrefs.SetInt(StrBounce, value);
        }
        
        public int Launch
        {
            get => PlayerPrefs.GetInt(StrLaunch);
            set => PlayerPrefs.SetInt(StrLaunch, value);
        }
        
        public int CheckpointCount
        {
            get => PlayerPrefs.GetInt(StrCheckPoint);
            set => PlayerPrefs.SetInt(StrCheckPoint, value);
        }

        public int PlatformCollide
        {
            get => PlayerPrefs.GetInt(StrPlatform);
            set => PlayerPrefs.SetInt(StrPlatform, value);
        }
        
        public int FailedCount
        {
            get => PlayerPrefs.GetInt(StrFireCooldown);
            set => PlayerPrefs.SetInt(StrFireCooldown, value);
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
            WinCondition.playerWin += FirstWin;
            BouncyPlatform.playerBounce += PlayerBounced;
            ButtonPlay.launch += FirstLaunch;
            CheckPoint.checkPoint += CheckPointActive;
            AchievementCorridor.plateformTranslation += PlatformCollision;
            FireComponent.fireCooldown += FireFailed;

        }

        private void OnDestroy()
        {
            PlayerController.onJump -= PlayerJumped;
            FireComponent.onBlue -= BlueCreation;
            FireComponent.onRed -= RedCreation;
            Kill.playerDeath -= FirstDeath;
            WinCondition.playerWin -= FirstWin;
            BouncyPlatform.playerBounce -= PlayerBounced;
            ButtonPlay.launch -= FirstLaunch;
            CheckPoint.checkPoint -= CheckPointActive;
            AchievementCorridor.plateformTranslation -= PlatformCollision;
            FireComponent.fireCooldown -= FireFailed;
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

        public void PlayerBounced()
        {
            BounceCount++;
            PlayerPrefs.Save();

            if (BounceCount == 1)
            {
                Debug.Log("Boooooiiiiiiiing");
            }
            if (BounceCount == 2)
            {
                Debug.Log("Bowiiiiing");
            }
            if (BounceCount == 3)
            {
                Debug.Log("I like this feature");
            }
            if (BounceCount == 4)
            {
                Debug.Log("So glad they putted it in the game");
            }
            
        }
        
        public void FirstLaunch()
        {
            Launch++;
            PlayerPrefs.Save();

            if (Launch == 1)
            {
                Debug.Log("The beginning of a new adventure !");
            }
        }

        public void CheckPointActive()
        {
            CheckpointCount++;
            PlayerPrefs.Save();

            if (CheckpointCount == 1)
            {
                Debug.Log("Progression saved !");
            }
            if (CheckpointCount == 2)
            {
                Debug.Log("Bonfire lit !");
            }
        }
        
        public void PlatformCollision()
        {
            PlatformCollide++;
            PlayerPrefs.Save();

            if (PlatformCollide == 1)
            {
                Debug.Log("Watch your feet !");
            }
        }
        
        public void FireFailed()
        {
            FailedCount++;
            PlayerPrefs.Save();

            if (FailedCount == 1)
            {
                Debug.Log("Need a magzine ? Too bad !");
            }
        }
        
        public  void ResetAll()
        {

            Debug.Log("All Achievements are reset");
    
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();

        }
    }
}
