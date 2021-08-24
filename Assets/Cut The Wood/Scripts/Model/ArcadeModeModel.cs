using InfinityEngine;
using InfinityEngine.ResourceManagement;
using InfinityEngine.Serialization;
using System.Collections;
using UnityEngine;

namespace CutTheWood
{
    /// <summary>
    /// The model of the mode <see cref="GameModes.Arcade"/>
    /// </summary>
    public class ArcadeModeModel : Model
    {
        [SerializeField]
        private float maxTime;
        private float nextTick;

        public override GameModes GameMode => GameModes.Arcade;

        public override float LaunchDelay => 3;

        public override int MaxItemToLaunch => 10;

        public override float BombProbability => 0;

        public override int MaxBombToLaunch => 0;

        public override void OnStart()
        {
            BestScore = R2.integers.ArcadeModeBest.Value;
            Score = 0;
            LaunchCountDown = 3;
            LaunchRepeatRate = 1.0f;
            RemaningTime = maxTime;
            StartCoroutine(_StartCoundDown());
        }

        public override void OnGameEnd()
        {
            if (Score >= BestScore)
            {
                R2.integers.ArcadeModeBest.Value = Score;
                BestScore = Score;
            }
            IsStarted = false;
        }

        public override bool CheckGameState()
        {
            NotifyObservers();
            if (IsStarted)
            {
                RemaningTime -= Time.deltaTime;
                if (RemaningTime <= 10)
                {

                    if (nextTick <= 0)
                    {
                        SoundManager.PlayEffect(R.audioclip.TimeTick);
                        nextTick += 1;
                    }
                    else
                    {
                        nextTick -= Time.deltaTime;
                    }

                }
            }

            return RemaningTime <= 0;
        }

        public override void AddScore(int value)
        {
            Score += value;
            NotifyObservers();
        }

        private IEnumerator _StartCoundDown()
        {
            while (LaunchCountDown > 0)
            {
                LaunchCountDown--;
                yield return new WaitForSeconds(1);
            }
            IsStarted = true;
        }
    }
}