Namespace DataTypes
    Public Structure Vector2
        Public x, y As Double

        Sub New(x As Double, y As Double)
            Me.x = x
            Me.y = y
        End Sub

        Function MagnitudeSquare() As Double
            Return x ^ 2 + y ^ 2
        End Function

        Function Magnitude() As Double
            Return Math.Sqrt(MagnitudeSquare())
        End Function

        Public Shared Operator -(v As Vector2) As Vector2
            Return New Vector2(-v.x, -v.y)
        End Operator

        Public Shared Operator +(v1 As Vector2, v2 As Vector2) As Vector2
            Return New Vector2(v1.x + v2.x, v1.y + v2.y)
        End Operator

        Public Shared Operator -(v1 As Vector2, v2 As Vector2) As Vector2
            Return New Vector2(v1.x - v2.x, v1.y - v2.y)
        End Operator

        Public Shared Operator *(v1 As Vector2, m As Double) As Vector2
            Return New Vector2(v1.x * m, v1.y * m)
        End Operator

        Public Shared Operator *(m As Double, v1 As Vector2) As Vector2
            Return New Vector2(v1.x * m, v1.y * m)
        End Operator

        Public Shared Operator /(v1 As Vector2, d As Double) As Vector2
            Return New Vector2(v1.x / d, v1.y / d)
        End Operator

        Public Shared Function NormSquare(v1 As Vector2, v2 As Vector2) As Double
            Return (v1.x - v2.x) ^ 2 + (v1.y - v2.y) ^ 2
        End Function

        Public Shared Function Norm(v1 As Vector2, v2 As Vector2) As Double
            Return Math.Sqrt(NormSquare(v1, v2))
        End Function

        Public Shared Function Average(vectors As Vector2()) As Vector2
            Dim sum As New Vector2(0, 0)
            For Each v As Vector2 In vectors
                sum += v
            Next
            Return sum / vectors.Length
        End Function

        Public Shared Function DotProduct(v1 As Vector2, v2 As Vector2) As Double
            Return v1.x * v2.y + v1.y * v2.x
        End Function

        Public Shared Function UnitVector(angle As Double) As Vector2
            Return New Vector2(Math.Cos(angle), Math.Sin(angle))
        End Function

    End Structure
End Namespace