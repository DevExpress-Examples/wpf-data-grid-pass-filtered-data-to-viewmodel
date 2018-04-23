Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.ComponentModel
Imports System.Windows
Imports System.Collections
Imports DevExpress.Xpf.Grid
Imports DevExpress.Data.Filtering.Helpers

Namespace ExpressionEvaluator_Filter
	Public Class FilteredDataSupport
        Public Shared ReadOnly VisibleDataProperty As DependencyProperty = DependencyProperty.RegisterAttached("VisibleData", GetType(IList), GetType(FilteredDataSupport), New PropertyMetadata(AddressOf OnVisibleDataChanged))

		Public Shared Sub SetVisibleData(ByVal element As UIElement, ByVal value As IList)
			element.SetValue(VisibleDataProperty, value)
		End Sub
		Public Shared Function GetVisibleData(ByVal element As UIElement) As IList
			Return CType(element.GetValue(VisibleDataProperty), IList)
		End Function

		Private Shared Sub OnVisibleDataChanged(ByVal sender As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim grid As GridControl = TryCast(sender, GridControl)
			If grid Is Nothing Then
				Return
			End If
			If e.OldValue Is Nothing AndAlso e.NewValue IsNot Nothing Then
				AddHandler grid.FilterChanged, AddressOf OnFilterChanged
			ElseIf e.OldValue IsNot Nothing AndAlso e.NewValue Is Nothing Then
				RemoveHandler grid.FilterChanged, AddressOf OnFilterChanged
			End If
		End Sub

		Private Shared Sub OnFilterChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim grid As GridControl = TryCast(sender, GridControl)
			If grid Is Nothing Then
				Return
			End If
			Dim res = grid.DataController.GetAllFilteredAndSortedRows()
			Dim visibleData As IList = TryCast(grid.GetValue(VisibleDataProperty), IList)
			If visibleData Is Nothing Then
				Return
			End If
			visibleData.Clear()
			For Each item As Object In res
				visibleData.Add(item)
			Next item
		End Sub
	End Class
End Namespace
