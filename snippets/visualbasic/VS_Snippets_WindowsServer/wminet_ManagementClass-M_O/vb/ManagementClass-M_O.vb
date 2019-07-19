﻿'<Snippet1>
Imports System
Imports System.Management


Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Get the WMI class
        Dim p As New ManagementPath("Win32_Process")
        ' Options specify that amended qualifiers
        ' are to be retrieved along with the class
        Dim o As New ObjectGetOptions( _
            Nothing, System.TimeSpan.MaxValue, True)
        Dim c As New ManagementClass(p, o)

        ' Get the methods in the class
        Dim methods As MethodDataCollection
        methods = c.Methods

        ' display the methods
        Console.WriteLine("Method Names: ")
        For Each method As MethodData In methods

            Console.WriteLine(method.Name)
        Next
        Console.WriteLine()

        ' Get the properties in the class
        Dim properties As PropertyDataCollection
        properties = c.Properties

        ' display the properties
        Console.WriteLine("Property Names: ")
        For Each pdata As PropertyData In properties

            Console.WriteLine(pdata.Name)
        Next
        Console.WriteLine()

        ' Get the Qualifiers in the class
        Dim qualifiers As QualifierDataCollection = _
        c.Qualifiers()

        ' display the qualifiers
        Console.WriteLine("Qualifier Names: ")
        For Each qualifier As QualifierData In qualifiers

            Console.WriteLine(qualifier.Name)
        Next

    End Function
End Class
'</Snippet1>