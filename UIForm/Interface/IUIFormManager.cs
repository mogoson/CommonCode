/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IUIFormManager.cs
 *  Description  :  Interface of manager for custom UI form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Enum;
using UnityEngine;

namespace MGS.UIForm
{
    /// <summary>
    /// Interface of manager for custom UI form.
    /// </summary>
    public interface IUIFormManager
    {
        #region Method
        /// <summary>
        /// Open form by specified form type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <param name="data">Data of form to show.</param>
        T OpenForm<T>(object data = null) where T : Component, IUIForm;

        /// <summary>
        /// Find form by specified type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <returns>Target form.</returns>
        T FindForm<T>() where T : IUIForm;

        /// <summary>
        /// Find all forms.
        /// </summary>
        /// <returns>All forms.</returns>
        IUIForm[] FindForms();

        /// <summary>
        /// Find forms by layer.
        /// </summary>
        /// <param name="layer">Target layer.</param>
        /// <returns>Target forms.</returns>
        IUIForm[] FindForms(string layer);

        /// <summary>
        /// Find forms by filter options.
        /// </summary>
        /// <param name="form">Specified form.</param>
        /// <param name="options">Options for filter forms.</param>
        /// <returns>Target forms.</returns>
        IUIForm[] FindForms(IUIForm form, FilterOptions options);

        /// <summary>
        /// Find forms by specified type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <returns>Target forms.</returns>
        T[] FindForms<T>() where T : IUIForm;

        /// <summary>
        /// Mirror forms.
        /// </summary>
        /// <param name="mode">Mode of mirror.</param>
        void MirrorForms(MirrorMode mode);

        /// <summary>
        /// Mirror forms.
        /// </summary>
        /// <param name="layer">Target layer.</param>
        /// <param name="mode">Mode of mirror.</param>
        void MirrorForms(string layer, MirrorMode mode);

        /// <summary>
        /// Set language of forms.
        /// </summary>
        /// <param name="language">Language name.</param>
        void LanguageForms(string language);

        /// <summary>
        /// Close form by specified form.
        /// </summary>
        /// <param name="form">Specified form instance.</param>
        /// <param name="destroy">Destroy form on closed?</param>
        void CloseForm(IUIForm form, bool destroy = false);

        /// <summary>
        /// Close form by specified form type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <param name="destroy">Destroy form on closed?</param>
        void CloseForm<T>(bool destroy = false) where T : IUIForm;

        /// <summary>
        /// Close all the forms.
        /// </summary>
        /// <param name="destroy">Destroy form on closed?</param>
        void CloseForms(bool destroy = false);

        /// <summary>
        /// Close forms by layer.
        /// </summary>
        /// <param name="layer">Target layer.</param>
        /// <param name="destroy">Destroy form on closed?</param>
        void CloseForms(string layer, bool destroy = false);

        /// <summary>
        /// Close forms by filter options.
        /// </summary>
        /// <param name="form">Specified form instance.</param>
        /// <param name="options">Options for filter forms.</param>
        /// <param name="destroy">Destroy form on closed?</param>
        void CloseForms(IUIForm form, FilterOptions options, bool destroy = false);

        /// <summary>
        /// Close forms by specified form type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <param name="destroy">Destroy form on closed?</param>
        void CloseForms<T>(bool destroy = false) where T : IUIForm;
        #endregion
    }

    /// <summary>
    /// Options for filter forms.
    /// </summary>
    public enum FilterOptions
    {
        /// <summary>
        /// Forms those in front of the specified form.
        /// </summary>
        FrontForms = 0,

        /// <summary>
        /// Forms those in back of the specified form.
        /// </summary>
        BackForms = 1
    }
}