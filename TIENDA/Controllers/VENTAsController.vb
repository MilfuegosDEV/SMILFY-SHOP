Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports TIENDA


Namespace Controllers
    Public Class VENTAsController
        Inherits System.Web.Mvc.Controller

        Private db As New PROYECTOEntities

        ' GET: VENTAs
        Function Index() As ActionResult
            Dim vENTA = db.VENTA.Include(Function(v) v.CLIENTE).Include(Function(v) v.PRENDA)
            Return View(vENTA.ToList())
        End Function

        ' GET: VENTAs/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim vENTA As VENTA = db.VENTA.Find(id)
            If IsNothing(vENTA) Then
                Return HttpNotFound()
            End If
            Return View(vENTA)
        End Function

        ' GET: VENTAs/Create
        Function Create() As ActionResult
            ViewBag.IdCliente = New SelectList(db.CLIENTE, "IdCliente", "Nombre")
            ViewBag.IdPrenda = New SelectList(db.PRENDA, "IdPrenda", "IdPrenda")
            Return View()
        End Function

        ' POST: VENTA/Create
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal venta As VENTA) As ActionResult
            If ModelState.IsValid Then
                Dim prenda = db.PRENDA.Find(venta.IdPrenda)
                If prenda IsNot Nothing AndAlso prenda.Stock >= venta.Cantidad Then
                    ' Actualizar el stock
                    prenda.Stock -= venta.Cantidad
                    db.Entry(prenda).State = EntityState.Modified

                    ' Establecer la fecha de la venta
                    venta.Fecha = DateTime.Now

                    ' Guardar la venta
                    db.VENTA.Add(venta)
                    db.SaveChanges()

                    Return RedirectToAction("Index")
                Else
                    ModelState.AddModelError("", "No hay suficiente stock para la venta.")
                End If
            End If

            ViewBag.IdCliente = New SelectList(db.CLIENTE, "IdCliente", "Nombre", venta.IdCliente)
            ViewBag.IdPrenda = New SelectList(db.PRENDA, "IdPrenda", "IdPrenda", venta.IdPrenda)
            Return View(venta)
        End Function

        ' GET: VENTAs/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim vENTA As VENTA = db.VENTA.Find(id)
            If IsNothing(vENTA) Then
                Return HttpNotFound()
            End If
            ViewBag.IdCliente = New SelectList(db.CLIENTE, "IdCliente", "Nombre", vENTA.IdCliente)
            ViewBag.IdPrenda = New SelectList(db.PRENDA, "IdPrenda", "IdPrenda", vENTA.IdPrenda)
            Return View(vENTA)
        End Function

        ' POST: VENTAs/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="IdVenta,IdPrenda,IdCliente,Cantidad")> ByVal vENTA As VENTA) As ActionResult
            If ModelState.IsValid Then
                db.Entry(vENTA).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.IdCliente = New SelectList(db.CLIENTE, "IdCliente", "Nombre", vENTA.IdCliente)
            ViewBag.IdPrenda = New SelectList(db.PRENDA, "IdPrenda", "IdPrenda", vENTA.IdPrenda)
            Return View(vENTA)
        End Function

        ' GET: VENTAs/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim vENTA As VENTA = db.VENTA.Find(id)
            If IsNothing(vENTA) Then
                Return HttpNotFound()
            End If
            Return View(vENTA)
        End Function

        ' POST: VENTAs/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim vENTA As VENTA = db.VENTA.Find(id)
            db.VENTA.Remove(vENTA)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
