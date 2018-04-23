using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows;
using System.Collections;
using DevExpress.Xpf.Grid;
using DevExpress.Data.Filtering.Helpers;

namespace ExpressionEvaluator_Filter {
    public class FilteredDataSupport {
        public static readonly DependencyProperty VisibleDataProperty =
            DependencyProperty.RegisterAttached("VisibleData", typeof(IList), typeof(FilteredDataSupport), new PropertyMetadata(OnVisibleDataChanged));

        public static void SetVisibleData(UIElement element, IList value) {
            element.SetValue(VisibleDataProperty, value);
        }
        public static IList GetVisibleData(UIElement element) {
            return (IList)element.GetValue(VisibleDataProperty);
        }

        private static void OnVisibleDataChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            GridControl grid = sender as GridControl;
            if(grid == null)
                return;
            if(e.OldValue == null && e.NewValue != null)
                grid.FilterChanged += OnFilterChanged;
            else if(e.OldValue != null && e.NewValue == null)
                grid.FilterChanged -= OnFilterChanged;
        }

        static void OnFilterChanged(object sender, RoutedEventArgs e) {
            GridControl grid = sender as GridControl;
            if(grid == null)
                return;
            var res = grid.DataController.GetAllFilteredAndSortedRows();
            IList visibleData = grid.GetValue(VisibleDataProperty) as IList;
            if(visibleData == null)
                return;
            visibleData.Clear();
            foreach(object item in res) {
                visibleData.Add(item);
            }
        }
    }
}
