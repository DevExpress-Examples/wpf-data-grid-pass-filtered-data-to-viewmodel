Imports Microsoft.VisualBasic
Imports DevExpress.Mvvm
Imports ExpressionEvaluator_Filter.Model
Imports System.Collections.ObjectModel

Namespace ExpressionEvaluator_Filter.ViewModel
	Friend Class DataViewModel
		Inherits ObservableObject
		Public Sub New(ByVal length As Integer)
			CreateData(length)
		End Sub

		Private Sub CreateData(ByVal length As Integer)
			Data = New ObservableCollection(Of DataModel)()
			VisibleData = New ObservableCollection(Of DataModel)()
			For i As Integer = 0 To length - 1
				Data.Add(New DataModel With {.Text = "Row" & i, .Number = i})
			Next i
			For Each item As DataModel In Data
				VisibleData.Add(New DataModel With {.Text = item.Text, .Number = item.Number})
			Next item
		End Sub

		Private _Data As ObservableCollection(Of DataModel)
		Private _VisibleData As ObservableCollection(Of DataModel)

		Public Property Data() As ObservableCollection(Of DataModel)
			Get
				Return _Data
			End Get
			Set(ByVal value As ObservableCollection(Of DataModel))
				_Data = value
				OnPropertyChanged("Data")
			End Set
		End Property

		Public Property VisibleData() As ObservableCollection(Of DataModel)
			Get
				Return _VisibleData
			End Get
			Set(ByVal value As ObservableCollection(Of DataModel))
				_VisibleData = value
				OnPropertyChanged("FilteredData")
			End Set
		End Property
	End Class
End Namespace
