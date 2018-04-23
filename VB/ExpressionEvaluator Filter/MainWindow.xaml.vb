Imports Microsoft.VisualBasic
Imports ExpressionEvaluator_Filter.ViewModel
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows

Namespace ExpressionEvaluator_Filter
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			DataContext = New DataViewModel(10)
		End Sub
	End Class
End Namespace
