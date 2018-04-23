using ExpressionEvaluator_Filter.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ExpressionEvaluator_Filter {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new DataViewModel(10);
        }
    }
}
