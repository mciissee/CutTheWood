/************************************************************************************************************************************
* Developed by Mamadou Cisse                                                                                                        *
* Mail => mciissee@gmail.com                                                                                                        *
* Twitter => http://www.twitter.com/IncMce                                                                                          *
* Unity Asset Store catalog: http://u3d.as/riS	                                                                                    *
*************************************************************************************************************************************/

namespace CutTheWood
{

    using UnityEngine;
    using InfinityEngine.DesignPatterns;
    using InfinityEngine;
    using InfinityEngine.Attributes;


    /// <summary>    
    /// Model component of MVC Design pattern
    /// </summary>
    public abstract class Model : Observable, IGameModel
    {

        #region Fields

        [MinMaxRange(0f, 5f)]
        [SerializeField] protected MinMax lanchInterval;
        [SerializeField] protected float comboCheckInterval = .5f;
        [SerializeField] protected int numberNeededToMakeCombo = 3;

        #endregion Fields

        public abstract GameModes GameMode { get; }

        public virtual float RemaningTime { get; set; }

        public virtual int LaunchCountDown { get; protected set; }

        public virtual float LaunchDelay => 1.0f;

        public virtual MinMax LaunchInterval => lanchInterval;

        public virtual float LaunchRepeatRate { get; set; }

        public virtual int MinItemToLaunch => 1;

        public virtual int MaxItemToLaunch
        {
            get
            {
                if (Score < 6)
                    return 1;

                if (Score < 50)
                    return 3;

                if (Score < 150)
                    return 5;

                if (Score < 300)
                    return 7;

                return Random.Range(4, 10);
            }
        }

        public virtual int MaxBombToLaunch
        {
            get
            {
                if (Score < 6)
                    return 0;

                if (Score < 50)
                    return 1;

                if (Score < 100)
                    return 2;

                if (Score < 150)
                    return 3;

                return 4;
            }
        }

        public virtual float BombProbability
        {
            get
            {
                if (Score < 5)
                    return 0;

                if (Score == 50)
                    return .01f;

                if (Score < 100)
                    return .1f;

                return .3f;
            }
        }

        public virtual int MaxLife { get; set; }

        public virtual int Life { get; set; }

        public virtual int LifeResetInterval { get; set; }

        public virtual int BestScore { get; protected set; }

        public virtual int Score { get; set; }

        public virtual int LastCombo { get; set; }

        public virtual float ComboCheckInterval => comboCheckInterval;

        public virtual bool HasCombo => LastCombo >= numberNeededToMakeCombo;

        public virtual bool IsStarted { get; protected set; }

        public virtual bool HasWonLife { get; set; }

        public virtual bool HasLoseLife { get; set; }

        #region Methods

        public virtual void OnStart()
        {
            return;
        }

        public virtual void OnGameEnd()
        {
            return;
        }

        public virtual bool CheckGameState()
        {

            return false;

        }

        public virtual void WonLife()
        {
            return;
        }

        public virtual void LoseLife()
        {
            return;
        }

        public virtual void AddScore(int value)
        {
            return;
        }

        public virtual void OnItemFalldown(GameItem item)
        {
            return;
        }

        #endregion Methods

    }
}