/************************************************************************************************************************************
* Developed by Mamadou Cisse                                                                                                        *
* Mail => mciissee@gmail.com                                                                                                        *
* Twitter => http://www.twitter.com/IncMce                                                                                          *
* Unity Asset Store catalog: http://u3d.as/riS	                                                                                    *
*************************************************************************************************************************************/
using UnityEngine;
using InfinityEngine.Extensions;
using InfinityEngine.Interpolations;
using InfinityEngine.DesignPatterns;
using UnityEngine.UI;
using InfinityEngine;
using System;
using InfinityEngine.Attributes;

namespace CutTheWood
{

    /// <summary>
    /// The view of 'classic' game mode.
    /// </summary>
    public class ClassicModeView : View
    {

        [Accordion("Life Panel"), SerializeField] private Transform lifePanel;
        [Accordion("Life Panel"), SerializeField] private Sprite lifeEmpty;
        [Accordion("Life Panel"), SerializeField] private Sprite lifeFilled;


        /// <summary>
        /// Invoked when <see cref="Controller.OnStart"/> method is called.
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();
            scoreLabel.text = "0";
            bestScoreLabel.text = string.Concat("Best ", model.BestScore);
            lifePanel.ForChild(child =>
            {
                child.GetComponent<Image>().sprite = lifeEmpty;
            });
        }

        /// <summary>
        /// Invoked when <see cref="Controller.OnEnd"/> method is called.
        /// </summary>
        protected override void OnEnd()
        {
            endScoreLabel.text = string.Concat("Score ", model.Score);
            endBestScoreLabel.text = string.Concat("Best ", model.BestScore);

            base.OnEnd();
        }

        /// <summary>
        /// Adds one life
        /// </summary>
        private void AddLife()
        {
            lifePanel.GetChild(model.MaxLife - model.Life).GetComponent<Image>().sprite = lifeEmpty;
        }

        /// <summary>
        /// Removes one life
        /// </summary>
        private void RemoveLife()
        {
            lifePanel.GetChild(model.MaxLife - model.Life).GetComponent<Image>().sprite = lifeFilled;
        }

        /// <summary>
        /// Called when the method <c>notifyObserver</c> of the model is invoked
        /// </summary>
        /// <param name="obj">The model</param>
        public override void OnChanged(object obj)
        {
            model = obj as IGameModel;

            if (model.HasWonLife)
            {
                AddLife();
                model.HasWonLife = false;
            }
            else if (model.HasLoseLife)
            {
                RemoveLife();
                model.HasLoseLife = false;
            }

            base.OnChanged(obj);
        }

    }
}