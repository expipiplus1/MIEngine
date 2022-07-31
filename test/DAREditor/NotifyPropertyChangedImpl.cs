﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAREditor
{
    /// <summary>
    /// Implementation of INotifyPropertyChanged
    /// </summary>
    internal class NotifyPropertyChangedImpl : INotifyPropertyChanged
    {
        /// <summary>
        /// Listen to this event to know property change
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(string propertyName, ref T memberVariable, T newValue) where T : IEquatable<T>
        {
            if (memberVariable.Equals(newValue))
            {
                return;
            }

            memberVariable = newValue;
            OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// helper to send property change event
        /// </summary>
        /// <param name="propertyName">property name changed</param>
        protected void OnPropertyChanged(string propertyName)
        {
            Debug.Assert(this.GetType().GetProperty(propertyName) != null, "Invalid Property Name");
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
