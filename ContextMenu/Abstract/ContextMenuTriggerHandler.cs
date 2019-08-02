﻿/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuTriggerHandler.cs
 *  Description  :  Handler of contex menu trigger.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UIForm;
using UnityEngine;

namespace MGS.ContextMenu
{
    /// <summary>
    /// Handler of contex menu trigger.
    /// </summary>
    public abstract class ContextMenuTriggerHandler : MonoBehaviour, IContextMenuTriggerHandler
    {
        #region Field and Property
        /// <summary>
        /// Target menu form.
        /// </summary>
        protected IContextMenuForm targetMenuForm;
        #endregion

        #region Public Method
        /// <summary>
        /// On context menu trigger enter.
        /// </summary>
        /// <param name="hitInfo">Raycast hit info of target.</param>
        public abstract void OnMenuTriggerEnter(RaycastHit hitInfo);

        /// <summary>
        /// On context menu trigger exit.
        /// </summary>
        public virtual void OnMenuTriggerExit()
        {
            if (targetMenuForm == null)
            {
                return;
            }

            if (targetMenuForm.IsOpen)
            {
                UIFormManager.Instance.CloseForm(targetMenuForm);
            }
        }
        #endregion
    }
}