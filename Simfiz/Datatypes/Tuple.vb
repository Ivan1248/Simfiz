Namespace DataTypes
    Public Structure Tuple(Of T1, T2)
        Public E1 As T1
        Public E2 As T2

        Sub New(t1 As T1, t2 As T2)
            Me.E1 = t1
            Me.E2 = t2
        End Sub
    End Structure

    Public Structure Tuple(Of T1, T2, T3)
        Public E1 As T1
        Public E2 As T2
        Public E3 As T3

        Sub New(t1 As T1, t2 As T2, t3 As T3)
            Me.E1 = t1
            Me.E2 = t2
            Me.E3 = t3
        End Sub
    End Structure
End Namespace