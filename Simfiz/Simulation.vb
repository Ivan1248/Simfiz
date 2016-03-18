Imports Simfiz.Datatypes
Imports Simfiz.SimObjects
Imports Simfiz.World

Public Class Simulation

#Region "Fields"


    Private Running As Boolean = False
    Dim Frequency As Integer = 100
    Dim Chronon As Double = 0.01       ' 1/Frequncy

#End Region

#Region "Methods"
    Public Shared Sub Run()
        Dim v As New Vector2(5, 5)
        Dim b As New Vector2(4, 7)
        While True
            v.x = GeomertyFunctions.PointPlaneDistance(v, b, v)
            b.x = GeomertyFunctions.PointPlaneDistance(v, b, v)
            'CalculateNextPossAndAngs()
            'TestCollisions()
        End While
        'Petlja
        '   Izračunati sljedeće položaje i zakrete
        '   Provjeriti sudare -> ponovo izračunati neke položaje i zakrete
        '   Izračunati ostale parametre
    End Sub

    Public Sub CalculateNextPossAndAngs()
        For Each ps As RigidBody In AllBodies
            ps.NextPos = ps.Pos + ps.Vel * Chronon
            ps.NextAng = ps.NextAng + ps.AngVel * Chronon
        Next
    End Sub

    Public Sub TestCollisions()
        For Each p As HalfPlane In Planes
            For Each c As Circle In Circles
                If PointPlaneDistance(c.NextPos, p.Point, p.UnitNormal) < c.Radius Then
                    CirclesCollidingPlanes.Add(New Tuple(Of Circle, HalfPlane)(c, p))
                End If
            Next
        Next
        For i As Integer = 0 To Circles.Count - 1
            For j As Integer = i + 1 To Circles.Count
                If i = j Then Continue For
                Dim radiiSum As Double = Circles(i).Radius + Circles(j).Radius
                If Math.Abs(Circles(i).Position.x - Circles(j).Position.x) > radiiSum OrElse
                    Math.Abs(Circles(i).Position.y - Circles(j).Position.y) > radiiSum Then
                    Continue For
                End If
                If Vector2.Norm(Circles(i).NextPos, Circles(j).NextPos) < radiiSum Then
                    CirclesCollidingCircles.Add(New Tuple(Of Circle, Circle)(Circles(i), Circles(j)))
                End If
            Next
            ' Provjera istovremenog sudara s više objekata
        Next
    End Sub

    Public Sub ResolveCollision()

    End Sub

#End Region

End Class
