Imports Simfiz.Datatypes

Namespace SimObjects
    Public MustInherit Class SimObject
        Public SimObjectId As Integer
    End Class

    Public Class HalfPlane : Inherits SimObject
        Public Point As Vector2
        Public UnitNormal As Vector2 ' Unit vector
        Public Restitution As Double
        Public Friction As Double

        Sub New(point As Vector2, normalAngle As Double)
            Me.Point = point
            Me.UnitNormal = Vector2.UnitVector(normalAngle)
        End Sub

        Sub New(point As Vector2, unitNormal As Vector2)
            Me.Point = point
            Me.UnitNormal = unitNormal
        End Sub
    End Class

    Public MustInherit Class PlaneFigure
        Inherits SimObject
        Public BodyId As Integer
        ' Metaphysical constants
        Public Fixed As Boolean
        ' Variables
        Public Pos As Vector2
        Public Vel As Vector2
        Public Ang As Double
        Public AngVel As Double
        ' Depedent variables
        Public Momentum As Vector2
        Public RotMomentum As Double
        ' Dependent constants
        Public Mass As Double
        Public RotInertia As Double
        Public Area As Double
        Public Density As Double
        ' Independent constants
        Public Restitution As Double
        Public Friction As Double
        ' Simulation
        Public NextPos As Vector2
        Public NextAng As Double

        Sub New(pos As Vector2, angle As Double)
            Me.Pos = pos
            Me.Vel = New Vector2(0, 0)
            Me.Ang = angle
            Me.AngVel = 0
            ' RotInertia = 
        End Sub

        Public Sub ApplyImpulse(radius As Vector2, impulse As Vector2)
            Momentum += impulse
            RotMomentum += Vector2.DotProduct(radius, impulse)
            Vel = Momentum / Mass
            AngVel = RotMomentum / RotInertia
        End Sub
    End Class

    Public Class Circle : Inherits PlaneFigure
        Public Radius As Double

        Sub New(pos As Vector2, radius As Double, angle As Double)
            MyBase.New(pos, angle)
            Radius = radius
            RotInertia = Density * 1 / 2 * Math.PI * radius ^ 4
        End Sub
    End Class

    Public Class Rectangle : Inherits PlaneFigure
        Public Dimensions As Vector2

        Sub New(pos As Vector2, angle As Double, dimensions As Vector2)
            MyBase.New(pos, angle)
            Me.Dimensions = dimensions
            'BigRadius = 0.5 * dimensions.Magnitude
            RotInertia = Density * 1 / 12 * dimensions.x * dimensions.y * dimensions.MagnitudeSqr
        End Sub
    End Class

    Public Class Polygon : Inherits PlaneFigure
        'Vertices are ordered counterclockwise.
        Public Vertices As Vector2()
        Public Convex As Boolean ' calculated

        Sub New(vertices As Vector2(), angle As Double)
            MyBase.New(New Vector2(0, 0), angle) ' promijeniti
            ' promijeniti
            Pos = New Vector2(0, 0)
            For i As Integer = 0 To vertices.Length
                Pos += vertices(i)
            Next
            Pos /= vertices.Length

            Dim posOffset As New Vector2(0, 0)
            Me.Vertices = vertices
            For Each v As Vector2 In Me.Vertices
                posOffset.x += v.x
                posOffset.y += v.y
            Next
            posOffset /= Me.Vertices.Count
            For Each v As Vector2 In Me.Vertices
                v.x -= posOffset.x
                v.y -= posOffset.y
            Next
        End Sub
    End Class

    Public Class Thruster
        Inherits SimObject
        Public Body As Double

        Public RelPos As Vector2
        Public RelAng As Double

        Sub New(relPos As Vector2, relAng As Double)
            Me.RelPos = relPos
            Me.RelAng = relAng
        End Sub
    End Class
End Namespace