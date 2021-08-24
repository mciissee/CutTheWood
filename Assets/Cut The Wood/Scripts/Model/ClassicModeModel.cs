using InfinityEngine.Serialization;
using UnityEngine;

namespace CutTheWood
{
    /// <summary>
    /// Model of the mode <see cref="GameModes.Classic"/>
    /// </summary>
    public class ClassicModeModel : Model
    {
        [SerializeField] protected int lifeResetInterval = 100;
        [SerializeField] protected int maxLife = 3;

        private int lifeResetCounter;

        private bool HasLife => Life > 0;

        public override GameModes GameMode => GameModes.Classic;

        public override int LifeResetInterval => lifeResetInterval;

        public override int MaxLife => maxLife;

        public override void OnStart()
        {
            BestScore = R2.integers.ClassicModeBest.Value;
            Life = MaxLife;
            Score = 0;
            lifeResetCounter = 0;
            LaunchRepeatRate = 1.0f;
            IsStarted = true;
        }

        public override void OnGameEnd()
        {
            if (Score >= BestScore)
            {
                R2.integers.ClassicModeBest.Value = Score;
                BestScore = Score;
            }
            IsStarted = false;
        }

        public override bool CheckGameState()
        {

            if (lifeResetCounter >= LifeResetInterval)
            {
                lifeResetCounter = 0;

                if (Life < MaxLife)
                {
                    WonLife();
                }
            }

            return !HasLife;

        }

        public override void WonLife()
        {
            Life++;
            HasWonLife = true;
            NotifyObservers();
        }

        public override void LoseLife()
        {
            HasLoseLife = true;
            NotifyObservers();
            Life--;
        }

        public override void AddScore(int value)
        {
            lifeResetCounter += value;
            Score += value;
            NotifyObservers();
        }

        public override void OnItemFalldown(GameItem item)
        {
            if (item.ItemType == ItemTypes.Wood)
            {
                if (Life > 0)
                {
                    LoseLife();
                }
            }
        }

    }
}