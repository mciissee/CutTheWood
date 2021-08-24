using InfinityEngine;
using InfinityEngine.DesignPatterns;

namespace CutTheWood
{
    /// <summary>
    /// A decorator class for <see cref="IGameModel"/>.
    /// You can inherits from this class to creates differents type of model objects
    /// whichs add extra behaviour to the model and changes dynamically the model
    /// of the controller.
    /// </summary>
    public class ModelDecorator : IGameModel
    {
        /// <summary>
        /// The original model to decorates
        /// </summary>
        protected IGameModel model;

        /// <summary>
        /// Decorates the given model
        /// </summary>
        /// <param name="model">The model to decorates</param>
        public ModelDecorator(IGameModel model) => this.model = model;

        #region Properties

        public virtual GameModes GameMode => model.GameMode;

        public virtual float RemaningTime { get => model.RemaningTime; set => model.RemaningTime = value; }

        public virtual int LaunchCountDown => model.LaunchCountDown;

        public virtual float LaunchDelay => model.LaunchDelay;

        public virtual MinMax LaunchInterval => model.LaunchInterval;

        public virtual float LaunchRepeatRate { get => model.LaunchRepeatRate; set => model.LaunchRepeatRate = value; }

        public virtual int MinItemToLaunch => model.MinItemToLaunch;

        public virtual int MaxItemToLaunch => model.MaxItemToLaunch;

        public virtual int MaxBombToLaunch => model.MaxBombToLaunch;

        public virtual float BombProbability => model.BombProbability;

        public virtual int MaxLife { get; set; }

        public virtual int Life { get; set; }

        public virtual int LifeResetInterval { get; set; }

        public virtual int BestScore { get; protected set; }

        public virtual int Score { get; set; }

        public virtual int LastCombo { get; set; }

        public virtual float ComboCheckInterval => model.ComboCheckInterval;

        public virtual bool HasCombo => model.HasCombo;

        public virtual bool IsStarted => model.IsStarted;

        public virtual bool HasWonLife { get => model.HasWonLife; set => model.HasWonLife = value; }

        public virtual bool HasLoseLife { get => model.HasLoseLife; set => model.HasLoseLife = value; }

        #endregion Properties

        #region Methods

        public virtual void OnStart() => model.OnStart();

        public virtual void OnGameEnd() => model.OnGameEnd();

        public virtual bool CheckGameState() => model.CheckGameState();

        public virtual void WonLife() => model.WonLife();

        public virtual void LoseLife() => model.LoseLife();

        public virtual void AddScore(int value) => model.AddScore(value);

        public virtual void OnItemFalldown(GameItem item) => model.OnItemFalldown(item);

        public void AddObserver(Observer obs) => model.AddObserver(obs);

        public void RemoveObservers() => model.RemoveObservers();

        public void RemoveObserver(Observer obs) => model.RemoveObserver(obs);

        public void NotifyObservers() => model.NotifyObservers();

        public bool HasObserver(Observer obs) => model.HasObserver(obs);

        #endregion Methods
    }
}