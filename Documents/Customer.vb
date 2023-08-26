Public Class Customer
    Private Order_Type As String
    Private Bill_Amount As Double
    Public Selectedlist As List(Of Food) = New List(Of Food)


    Public Property orderType As String
        Get
            Return Order_Type
        End Get
        Set(value As String)
            Order_Type = value
        End Set
    End Property


    Public Property BillAmount As Double
        Get
            Return Bill_Amount
        End Get
        Set(value As Double)
            Bill_Amount = value
        End Set
    End Property

End Class
