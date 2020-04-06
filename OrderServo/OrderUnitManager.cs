/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderUnitManager.cs
 *  Description  :  Manager of order units.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;
using System.Collections.Generic;
using UnityEngine;

namespace MGS.OrderServo
{
    /// <summary>
    /// Manager of order units.
    /// </summary>
    [AddComponentMenu("MGS/OrderServo/OrderUnitManager")]
    public class OrderUnitManager : MonoBehaviour, IOrderUnitManager
    {
        #region Field and Property
        /// <summary>
        /// On order respond.
        /// </summary>
        public GenericEvent<Order> OnRespond { get; } = new GenericEvent<Order>();

        /// <summary>
        /// units managed by this manager.
        /// </summary>
        protected Dictionary<string, IOrderUnit> units = new Dictionary<string, IOrderUnit>();
        #endregion

        #region Private Method
        /// <summary>
        /// On order unit respond.
        /// </summary>
        /// <param name="code">Order code.</param>
        /// <param name="args">Order args.</param>
        protected void OnUnitRespond(string code, object args)
        {
            OnRespond.Invoke(new Order(code, args));
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Add order unit.
        /// </summary>
        /// <param name="unit">Order unit.</param>
        public void AddUnit(IOrderUnit unit)
        {
            if (unit == null || string.IsNullOrEmpty(unit.Code) || units.ContainsKey(unit.Code))
            {
                return;
            }

            unit.OnRespond.AddListener(OnUnitRespond);
            units.Add(unit.Code, unit);
        }

        /// <summary>
        /// Remove order unit.
        /// </summary>
        /// <param name="code">Unit code.</param>
        public void RemoveUnit(string code)
        {
            if (units.ContainsKey(code))
            {
                units[code].OnRespond.RemoveListener(OnUnitRespond);
                units.Remove(code);
            }
        }

        /// <summary>
        /// Clear order units.
        /// </summary>
        public void ClearUnits()
        {
            foreach (var unit in units.Values)
            {
                unit.OnRespond.RemoveListener(OnUnitRespond);
            }
            units.Clear();
        }

        /// <summary>
        /// Execute order.
        /// </summary>
        /// <param name="order">Order to execute.</param>
        public void Execute(Order order)
        {
            if (units.ContainsKey(order.code))
            {
                units[order.code].Execute(order);
            }
        }
        #endregion
    }
}