'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class PRENDA
    Public Property IdPrenda As Integer
    Public Property IdMarca As Nullable(Of Integer)
    Public Property IdTalla As Nullable(Of Integer)
    Public Property IdDepartamento As Nullable(Of Integer)
    Public Property IdProvedor As Nullable(Of Integer)
    Public Property Precio As Nullable(Of Decimal)
    Public Property Stock As Nullable(Of Integer)

    Public Overridable Property DEPARTAMENTO As DEPARTAMENTO
    Public Overridable Property MARCA As MARCA
    Public Overridable Property PROVEEDOR As PROVEEDOR
    Public Overridable Property TALLA As TALLA
    Public Overridable Property VENTA As ICollection(Of VENTA) = New HashSet(Of VENTA)

End Class