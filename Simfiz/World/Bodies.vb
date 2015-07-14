Imports Simfiz.Datatypes
Imports Simfiz.SimObjects

Namespace World

    Module Bodies
        ' List of all bodies
        Public AllBodies As New List(Of PlaneFigure)
        ' Lists of bodies by type
        Public Planes As New List(Of HalfPlane)
        Public Circles As New List(Of Circle)
        Public Rectangles As New List(Of Drawing.Rectangle)
        ' Lists of colliding bodies
        Public CirclesCollidingPlanes As New List(Of Tuple(Of Circle, HalfPlane))
        Public RectanglesCollidingPlanes As New List(Of Tuple(Of Drawing.Rectangle, HalfPlane))
        Public CirclesCollidingCircles As New List(Of Tuple(Of Circle, Circle))
        Public RectanglesCollidingCircles As New List(Of Tuple(Of Drawing.Rectangle, Circle))
        Public CirclesCollidingRectangles As New List(Of Tuple(Of Circle, Drawing.Rectangle))
        Public RectanglesCollidingRectangles As New List(Of Tuple(Of Drawing.Rectangle, Drawing.Rectangle))
    End Module
End Namespace