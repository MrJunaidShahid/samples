﻿' <Snippet4>
' StateManagedAuthorConverter.vb
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization
Imports System.Globalization
Imports System.Reflection

Namespace Samples.AspNet.VB.Controls
    Public Class StateManagedAuthorConverter
        Inherits ExpandableObjectConverter

        Public Overrides Function CanConvertFrom( _
        ByVal context As ITypeDescriptorContext, _
        ByVal sourceType As Type) As Boolean
            If sourceType Is GetType(String) Then
                Return True
            End If
            Return MyBase.CanConvertFrom(context, sourceType)
        End Function

        Public Overrides Function CanConvertTo( _
        ByVal context As ITypeDescriptorContext, _
        ByVal destinationType As Type) As Boolean
            If destinationType Is GetType(String) Then
                Return True
            End If
            Return MyBase.CanConvertTo(context, destinationType)
        End Function


        Public Overrides Function ConvertFrom( _
            ByVal context As ITypeDescriptorContext, _
            ByVal culture As CultureInfo, ByVal value As Object) _
            As Object
            If value Is Nothing Then
                Return New StateManagedAuthor()
            End If

            If (TypeOf value Is String) Then
                Dim s As String = CStr(value)
                If s.Length = 0 Then
                    Return New StateManagedAuthor()
                End If

                Dim parts() As String = s.Split(" ".ToCharArray)

                If (parts.Length < 2) Or (parts.Length > 3) Then
                    Throw New ArgumentException( _
                        "Name must have 2 or 3 parts.", "value")
                End If

                If parts.Length = 2 Then
                    Return New StateManagedAuthor(parts(0), parts(1))
                End If

                If parts.Length = 3 Then
                    Return New StateManagedAuthor(parts(0), _
                        parts(1), parts(2))
                End If
            End If
            Return MyBase.ConvertFrom(context, culture, value)
        End Function

        Public Overrides Function ConvertTo( _
        ByVal context As ITypeDescriptorContext, _
        ByVal culture As CultureInfo, ByVal value As Object, _
        ByVal destinationType As Type) As Object
            If value IsNot Nothing Then
                If Not (TypeOf value Is StateManagedAuthor) Then
                    Throw New ArgumentException( _
                        "Name must have 2 or 3 parts.", "value")
                End If
            End If

            If destinationType Is GetType(String) Then
                If value Is Nothing Then
                    Return String.Empty
                End If

                Dim auth As StateManagedAuthor = _
                    CType(value, StateManagedAuthor)

                If auth.MiddleName <> String.Empty Then
                    Return String.Format("{0} {1} {2}", _
                    auth.FirstName, _
                    auth.MiddleName, _
                    auth.LastName)
                Else
                    Return String.Format("{0} {1}", _
                        auth.FirstName, _
                        auth.LastName)
                End If
            End If

            Return MyBase.ConvertTo(context, culture, value, _
                destinationType)
        End Function
    End Class
End Namespace
' </Snippet4>
