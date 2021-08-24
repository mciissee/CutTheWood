using UnityEngine;
using InfinityEngine.Extensions;
using InfinityEngine.Interpolations;
using UnityEngine.UI;
using InfinityEngine.Utils;

namespace CutTheWood
{
    /// <summary>
    /// View of the mode <see cref="GameModes.Arcade"/>
    /// </summary>
    public class ArcadeModeView : View
    {
        [SerializeField] private Text timerLabel;
        [SerializeField] private Text countDownLabel;

        private Interpolable timerAnim;

        /// <summary>
        /// Invoked when <see cref="Controller.OnStart"/> method is called.
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();
            countDownLabel.gameObject.SetActive(true);
            scoreLabel.text = "0";
            bestScoreLabel.text = string.Concat("Best ", model.BestScore);
            var timerLabelDefaultColor = timerLabel.color;
            if(timerAnim == null)
            {
                timerAnim = timerLabel.rectTransform.DOScale(Vector3.one, Vector3.one * 2f, .3f)
                    .SetCached()
                    .OnTerminate(arg =>
                    {
                        timerLabel.color = timerLabelDefaultColor;
                        timerLabel.transform.localScale = Vector3.one;
                    })
                    .SetRepeat(-1, LoopTypes.Reverse);
            }
        }

        /// <summary>
        /// Invoked when <see cref="Controller.OnEnd"/> method is called.
        /// </summary>
        protected override void OnEnd()
        {
            endScoreLabel.text = string.Concat("Score ", model.Score);
            endBestScoreLabel.text = string.Concat("Best ", model.BestScore);

            timerAnim.Terminate();
            base.OnEnd();
        }

        /// <summary>
        /// Called when the method <c>notifyObserver</c> of the model is invoked
        /// </summary>
        /// <param name="obj">The model</param>
        public override void OnChanged(object obj)
        {
            model = obj as IGameModel;

            if(!model.IsStarted)
            {
                countDownLabel.text =  model.LaunchCountDown.ToString();
            }
            else if(countDownLabel.gameObject.activeSelf)
            {
                countDownLabel.gameObject.SetActive(false);
            }

            timerLabel.text = ((int)model.RemaningTime).ToString();
            if(model.RemaningTime <= 10 && timerAnim != null && !timerAnim.IsStarted)
            {
                timerLabel.color = Color.red;
                timerAnim.Start();
                
            }
            base.OnChanged(obj);
        }
    }
}
