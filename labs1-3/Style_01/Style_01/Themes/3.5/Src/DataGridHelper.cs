// Copyright (c) Trevor Webster
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;
using MS.Internal;
using Microsoft.Windows.Controls;
using System.Windows.Shapes;
using Microsoft.Windows.Controls.Primitives;

namespace DataGridThemes
{
    public static class DataGridHelper
    {		          
       
		public static T FindParent<T>(FrameworkElement element) where T : FrameworkElement
		{
			FrameworkElement parent = LogicalTreeHelper.GetParent(element) as FrameworkElement;
			while (parent != null)
			{
				T correctlyTyped = parent as T;
				if (correctlyTyped != null)				
					return correctlyTyped;				
				else
					return FindParent<T>(parent);
			}

			return null;
		}

        /// <summary>
        ///     Walks up the templated parent tree looking for a parent type.
        /// </summary>
        public static T FindTemplatedParent<T>(FrameworkElement element) where T : FrameworkElement
        {
            FrameworkElement parent = element.TemplatedParent as FrameworkElement;

            while (parent != null)
            {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }

                parent = parent.TemplatedParent as FrameworkElement;
            }

            return null;
        }

        public static T FindVisualParent<T>(UIElement element) where T : UIElement
        {
            UIElement parent = element;
            while (parent != null)
            {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }

                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }

            return null;
        }

    }
}
