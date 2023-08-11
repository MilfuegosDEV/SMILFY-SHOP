Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports TIENDA

Public Class HomeController
    Inherits System.Web.Mvc.Controller


    Private db As New PROYECTOEntities
    Function Index(fechainicio As Date?, fechafin As Date?, idventa As Integer?) As ActionResult
        Dim ventas = db.VENTA.Include(Function(v) v.CLIENTE).Include(Function(v) v.PRENDA).AsQueryable()

        ' Filtrar por fecha de inicio si se proporciona
        If fechainicio.HasValue Then
            ventas = ventas.Where(Function(v) v.Fecha >= fechainicio.Value)
        End If

        ' Filtrar por fecha fin si se proporciona
        If fechafin.HasValue Then
            ventas = ventas.Where(Function(v) v.Fecha <= fechafin.Value)
        End If

        ' Filtrar por idventa si se proporciona
        If idventa.HasValue Then
            ventas = ventas.Where(Function(v) v.IdVenta = idventa.Value)
        End If

        ' Obtener las cantidades
        Dim cantidadClientes = db.CLIENTE.Count()
        Dim cantidadVentas = ventas.Count()

        ' Pasar las cantidades a la vista usando ViewBag
        ViewBag.CantidadClientes = cantidadClientes
        ViewBag.CantidadVentas = cantidadVentas

        Return View(ventas.ToList())
    End Function

    'TODO:
    '<HttpPost>
    'Public Function ExportarDatosFiltrados(fechainicio As Date?, fechafin As Date?, idventa As Integer?) As FileResult
    '    Dim ventas = db.VENTA.Include(Function(v) v.CLIENTE).Include(Function(v) v.PRENDA).AsQueryable()

    '    ' Filtrar por fecha de inicio si se proporciona
    '    If fechainicio.HasValue Then
    '        ventas = ventas.Where(Function(v) v.Fecha >= fechainicio.Value)
    '    End If

    '    ' Filtrar por fecha fin si se proporciona
    '    If fechafin.HasValue Then
    '        ventas = ventas.Where(Function(v) v.Fecha <= fechafin.Value)
    '    End If

    '    ' Filtrar por idventa si se proporciona
    '    If idventa.HasValue Then
    '        ventas = ventas.Where(Function(v) v.IdVenta = idventa.Value)
    '    End If

    '    ' Obtener los datos filtrados
    '    Dim datosFiltrados = ventas.ToList()

    '    ' Crear un DataTable con los datos filtrados
    '    Dim dt As New DataTable()
    '    dt.Columns.Add("IdVenta", GetType(Integer))
    '    dt.Columns.Add("IdPrenda", GetType(Integer))
    '    dt.Columns.Add("IdCliente", GetType(Integer))
    '    dt.Columns.Add("Cantidad", GetType(Integer))
    '    dt.Columns.Add("Fecha", GetType(Date))

    '    For Each venta In datosFiltrados
    '        dt.Rows.Add(venta.IdVenta, venta.IdPrenda, venta.IdCliente, venta.Cantidad, venta.Fecha)
    '    Next

    '    ' Crear el archivo Excel
    '    Using wb As New XLWorkbook()
    '        Dim ws = wb.Worksheets.Add(dt, "DatosFiltrados")
    '        Using stream As New MemoryStream()
    '            wb.SaveAs(stream)
    '            Return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DatosFiltrados.xlsx")
    '        End Using
    '    End Using
    'End Function





    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
