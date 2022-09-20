Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel

Namespace ExpressionEvaluator_Filter

    Friend Class DataViewModel
        Inherits ViewModelBase

        Public Sub New()
            CreateData(10)
        End Sub

        Private Sub CreateData(ByVal length As Integer)
            Data = New ObservableCollection(Of DataModel)()
            For i As Integer = 0 To length - 1
                Data.Add(New DataModel With {.Text = "Row" & i, .Number = i})
            Next
        End Sub

        Public Property Data As ObservableCollection(Of DataModel)
            Get
                Return GetProperty(Function() Me.Data)
            End Get

            Set(ByVal value As ObservableCollection(Of DataModel))
                SetProperty(Function() Data, value)
            End Set
        End Property

        Public Property VisibleData As ObservableCollection(Of Object)
            Get
                Return GetProperty(Function() Me.VisibleData)
            End Get

            Set(ByVal value As ObservableCollection(Of Object))
                SetProperty(Function() VisibleData, value)
            End Set
        End Property
    End Class
End Namespace
