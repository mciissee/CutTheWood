/************************************************************************************************************************************
* Developed by Mamadou Cisse                                                                                                        *
* Mail => mciissee@gmail.com                                                                                                        *
* Twitter => http://www.twitter.com/IncMce                                                                                          *
* Unity Asset Store catalog: http://u3d.as/riS	                                                                                    *
*************************************************************************************************************************************/

namespace CutTheWood
{
    
    using InfinityEngine;
    using InfinityEngine.DesignPatterns;

    public interface IGameModel : IObservable
    {

        /// <summary>
        /// Gets the current game mode
        /// </summary>
        GameModes GameMode { get; }

        /// <summary>
        /// Gets the remaning time before the end of the timer (only for game modes with timer system). 
        /// </summary>
        float RemaningTime { get; set; }

        /// <summary>
        /// The number of items that the player must cut to restore one life (only for game modes with life system). 
        /// </summary>
        int LifeResetInterval { get; set; }

        /// <summary>
        /// Gets or sets the number of life of the player (only for game modes with life system). 
        /// </summary>
        int Life { get; set; }

        /// <summary>
        /// The maximum number of life of the player in the current game mode (only for game modes with life system). 
        /// </summary>
        int MaxLife { get; set; }

        /// <summary>
        /// The value of the countdown before the starts of the game (only for game modes with timer system). 
        /// </summary>
        int LaunchCountDown { get; }

        /// <summary>
        /// Gets the min and max time between the launch of the items
        /// </summary>
        MinMax LaunchInterval { get; }

        /// <summary>
        /// Gets the delay to wait before launching the first item when the game starts
        /// </summary>
        float LaunchDelay { get; }

        /// <summary>
        /// The minimum number of item to launch
        /// </summary>
        int MinItemToLaunch { get; }

        /// <summary>
        /// The maximum number of item to launch
        /// </summary>
        int MaxItemToLaunch { get; }

        /// <summary>
        /// The number maximum of bomb to integrated to the items
        /// </summary>
        int MaxBombToLaunch { get; }

        /// <summary>
        /// The probability to generate bomb item in the rande [0, 1]
        /// </summary>
        float BombProbability { get; }

        /// <summary>
        /// The repeat rate of <see cref="Controller.LaunchItems"/> method.
        /// </summary>
        float LaunchRepeatRate { get; set; }

        /// <summary>
        ///  The number of items that the player must cut to restore one life.
        /// </summary>
        int BestScore { get; }

        /// <summary>
        /// Gets or sets the current score of the player
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// Gets or sets the number of item cutted by the player during the last '<see cref="ComboCheckInterval"/>' seconds.
        /// </summary>
        int LastCombo { get; set; }

        /// <summary>
        /// Gets the time interval during which the <see cref="Controller"/> checks if the player has made a combo.
        /// </summary>
        float ComboCheckInterval { get; }

        /// <summary>
        /// Gets a value indicating whether the game is started
        /// </summary>
        bool IsStarted { get; }

        /// <summary>
        /// Gets a value indicating whether the player has made a combo in the last '<see cref="ComboCheckInterval"/>' seconds.
        /// </summary>
        bool HasCombo { get; }

        /// <summary>
        /// Gets a value indicating whether the player has a won a life (only for game modes with life system). 
        /// </summary>
        bool HasWonLife { get; set; }

        /// <summary>
        /// Gets a value indicating whether the player has a lose a life (only for game modes with life system). 
        /// </summary>
        bool HasLoseLife { get; set; }

        /// <summary>
        /// Adds a score to the model
        /// </summary>
        /// <param name="value">The value to add</param>
        void AddScore(int value);

        /// <summary>
        /// Called when <see cref="Controller.OnStart"/> is called
        /// </summary>
        void OnStart();

        /// <summary>
        /// Called when <see cref="Controller.OnEnd"/> is called
        /// </summary>
        void OnGameEnd();

        /// <summary>
        /// Increments the life of the model (only for game modes with life system). 
        /// </summary>
        void WonLife();

        /// <summary>
        /// Decrements the life of the model (only for game modes with life system).
        /// </summary>
        void LoseLife();

        /// <summary>
        /// Called when an item fall down
        /// </summary>
        /// <param name="item"></param>
        void OnItemFalldown(GameItem item);

        /// <summary>
        /// Updates the model states and checks if the game should be ended
        /// </summary>
        /// <returns><c>true</c> if the game should be ended</returns>
        bool CheckGameState();
    }
}