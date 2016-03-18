Imports Simfiz.DataTypes

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

    Public MustInherit Class RigidBody : Inherits SimObject
        Public BodyId As Integer
        ' Metaphysical constants
        Public Fixed As Boolean
        ' Constants
        Public Restitution As Double
        Public Friction As Double
        Public Mass As Double
        Public RotInertia As Double
        Public Area As Double
        ' Auxiliary constants
        Public Density As Double
        ' State variables
        Public Position As Vector2
        Public Orientation As Double
        Public Momentum As Vector2
        Public AngMomentum As Double
        ' Auxiliary state variables
        Public Velocity As Vector2
        Public AngVelocity As Double

        Sub New(pos As Vector2, angle As Double)
            Me.Position = pos
            Me.Velocity = New Vector2(0, 0)
            Me.Orientation = angle
            Me.AngVelocity = 0
        End Sub
    End Class

    Public Class Circle : Inherits RigidBody
        Public Radius As Double

        Sub New(pos As Vector2, radius As Double, angle As Double)
            MyBase.New(pos, angle)
            Me.Radius = radius
            Me.RotInertia = Density * 1 / 2 * Math.PI * radius ^ 4
        End Sub
    End Class

    Public Class Rectangle : Inherits RigidBody
        Public Dimensions As Vector2

        Sub New(pos As Vector2, angle As Double, dimensions As Vector2)
            MyBase.New(pos, angle)
            Me.Dimensions = dimensions
            'BigRadius = 0.5 * dimensions.Magnitude
            Me.RotInertia = Density * 1 / 12 * dimensions.x * dimensions.y * dimensions.MagnitudeSquare
        End Sub
    End Class

    Public Class Polygon : Inherits RigidBody
        'Vertices are ordered counterclockwise.
        Public Vertices As Vector2()
        Public Convex As Boolean ' calculated

        Sub New(vertices As Vector2(), angle As Double)
            MyBase.New(New Vector2(0, 0), angle) ' promijeniti
            ' promijeniti
            Me.Position = New Vector2(0, 0)
            For i As Integer = 0 To vertices.Length
                Me.Position += vertices(i)
            Next
            Me.Position /= vertices.Length

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

    Public Class Thruster : Inherits SimObject
        Public Body As RigidBody

        Public RelPos As Vector2
        Public RelAng As Double

        Sub New(relPos As Vector2, relAng As Double)
            Me.RelPos = relPos
            Me.RelAng = relAng
        End Sub
    End Class
End Namespace