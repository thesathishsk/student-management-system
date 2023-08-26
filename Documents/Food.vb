Public Class Food
    Private Food_name As String
    Private Food_quantity As Int64
    Private Food_price As Double

    Sub New(name As String, qant As Int64, rate As Double)
        Food_name = name
        Food_quantity = qant
        Food_price = rate
    End Sub

    Sub New()

    End Sub
    Public Property foodName As String
        Get
            Return Food_name
        End Get
        Set(value As String)
            Food_name = value
        End Set
    End Property

    Public Property Nos As Int64
        Get
            Return Food_quantity
        End Get
        Set(value As Int64)
            Food_quantity = value
        End Set
    End Property

    Public Property foodPrice As Double
        Get
            Return Food_price
        End Get
        Set(value As Double)
            Food_price = value
        End Set
    End Property

End Class
