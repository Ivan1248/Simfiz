Imports Simfiz.Datatypes

Module GeomertyFunctions
    Public Function PointInTriangle(point As Vector2, t1 As Vector2, t2 As Vector2, t3 As Vector2) As Boolean
        Dim d, r As Double
        Dim p As Double
        Dim c As Vector2 = (t1 + t2 + t3) / 3
        d = (c - point).MagnitudeSqr
        r = Math.Max((c - t1).MagnitudeSqr, Math.Max((c - t2).MagnitudeSqr, (c - t3).MagnitudeSqr))

        If d > r Then Return False

        'Nova ideja: Neka su vrhovi trokuta A, B i C. Točka T nalazi se i

        Return True
    End Function

    ' Vraća negativnu vrijednost ako je točka s lijeve strane vektora smijera pravca ako vektor pokazuje prema gore
    Public Function PointPlaneDistance(point As Vector2, linePoint As Vector2, planeUnitNormal As Vector2) As Double
        Return Vector2.DotProduct(point - linePoint, planeUnitNormal)
    End Function

End Module
