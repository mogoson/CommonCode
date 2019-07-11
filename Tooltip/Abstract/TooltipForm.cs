﻿/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TooltipForm.cs
 *  Description  :  Define tooltip form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/2/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UIForm;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.Tooltip
{
    /// <summary>
    /// Tooltip form.
    /// </summary>
    [UIFormInfo(UIFromPattern.Single, "Tooltip")]
    public abstract class TooltipForm : MonoUIForm, ITooltipForm
    {
        #region Field and Property
        /// <summary>
        /// Margin of tip form base on screen.
        /// </summary>
        [Tooltip("Margin of tip form base on screen.")]
        [SerializeField]
        protected RectOffset margin = new RectOffset(5, 5, 5, 5);

        /// <summary>
        /// Offset for tip form to align to target position.
        /// </summary>
        [Tooltip("Offset for tip form to align to target position.")]
        [SerializeField]
        protected Vector2 offset = new Vector2(10, -10);

        /// <summary>
        /// Alignment for tip form to align to target position.
        /// </summary>
        [Tooltip("Alignment for tip form to align to target position.")]
        [SerializeField]
        protected TextAnchor alignment = TextAnchor.UpperLeft;

        /// <summary>
        /// Tip form auto follow mouse pointer?
        /// </summary>
        public virtual bool AutoFollowPointer
        {
            set { enabled = value; }
            get { return enabled; }
        }

        /// <summary>
        /// Margin of tip form base on screen.
        /// </summary>
        public RectOffset Margin
        {
            set { margin = value; }
            get { return margin; }
        }

        /// <summary>
        /// Offset for tip form to align to target position.
        /// </summary>
        public Vector2 Offset
        {
            set { offset = value; }
            get { return offset; }
        }

        /// <summary>
        /// Alignment for tip form to align to target position.
        /// </summary>
        public TextAnchor Alignment
        {
            set { alignment = value; }
            get { return alignment; }
        }
        #endregion

        #region Protected Method
        /// <summary>
        /// Reset tip form.
        /// </summary>
        protected virtual void Reset()
        {
            rectTransform = transform as RectTransform;
            rectTransform.anchorMin = rectTransform.anchorMax = Vector2.zero;
        }

        /// <summary>
        /// Tip update.
        /// </summary>
        protected virtual void Update()
        {
            SetFormPosition(new Vector2(Input.mousePosition.x, Input.mousePosition.y) + offset);
        }

        /// <summary>
        /// Set tip form position.
        /// </summary>
        /// <param name="screenPos">Target screen position of tip form.</param>
        protected void SetFormPosition(Vector2 screenPos)
        {
            rectTransform.anchoredPosition = GetPreferredPosition(screenPos);
        }

        /// <summary>
        /// Get preferred position of tip form base on screen position.
        /// </summary>
        /// <param name="screenPos">Target screen position of tip form.</param>
        /// <returns>Preferred position of tip form.</returns>
        protected virtual Vector2 GetPreferredPosition(Vector2 screenPos)
        {
            var pivot = Text.GetTextAnchorPivot(alignment);
            rectTransform.pivot = pivot;

            var xMin = margin.left + rectTransform.rect.width * pivot.x;
            var xPos = screenPos.x;
            if (xPos <= xMin)
            {
                xPos = xMin;
            }
            else
            {
                var xMax = Screen.width - margin.right - rectTransform.rect.width * (1 - pivot.x);
                if (xPos > xMax)
                {
                    xPos = xMax;
                }
            }

            var yMin = margin.bottom + rectTransform.rect.height * pivot.y;
            var yPos = screenPos.y;
            if (yPos <= yMin)
            {
                yPos = yMin;
            }
            else
            {
                var yMax = Screen.height - margin.right - rectTransform.rect.height * (1 - pivot.y);
                if (yPos > yMax)
                {
                    yPos = yMax;
                }
            }

            return new Vector2(xPos, yPos);
        }
        #endregion
    }
}