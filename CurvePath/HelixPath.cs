﻿/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HelixPath.cs
 *  Description  :  Define path base on helix curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/14/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.Curve;
using UnityEngine;

namespace MGS.CurvePath
{
    /// <summary>
    /// Path base on helix curve.
    /// </summary>
    [AddComponentMenu("MGS/CurvePath/HelixPath")]
    public class HelixPath : MonoCurvePath
    {
        #region Field and Property
        /// <summary>
        /// Top ellipse args of curve.
        /// </summary>
        [Tooltip("Top ellipse args of curve.")]
        public EllipseArgs topEllipse = new EllipseArgs(Vector3.up, 1.0f, 1.0f);

        /// <summary>
        /// Bottom ellipse args of curve.
        /// </summary>
        [Tooltip("Bottom ellipse args of curve.")]
        public EllipseArgs bottomEllipse = new EllipseArgs(Vector3.zero, 1.0f, 1.0f);

        /// <summary>
        /// Max around radian of helix.
        /// </summary>
        [Tooltip("Max around radian of helix.")]
        public float maxRadian = 6;

        /// <summary>
        /// Curve for path.
        /// </summary>
        protected override ICurve Curve { get { return curve; } }

        /// <summary>
        /// Curve of path.
        /// </summary>
        protected HelixCurve curve = new HelixCurve();
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild path.
        /// </summary>
        public override void Rebuild()
        {
            curve.topEllipse = topEllipse;
            curve.bottomEllipse = bottomEllipse;
            curve.MaxKey = maxRadian * Mathf.PI;
            base.Rebuild();
        }
        #endregion
    }
}