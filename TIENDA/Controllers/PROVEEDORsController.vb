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
    Public Class PROVEEDORsController
        Inherits System.Web.Mvc.Controller

        Private db As New PROYECTOEntities

        ' GET: PROVEEDORs
        Function Index() As ActionResult
            Return View(db.PROVEEDOR.ToList())
        End Function

        ' GET: PROVEEDORs/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim pROVEEDOR As PROVEEDOR = db.PROVEEDOR.Find(id)
            If IsNothing(pROVEEDOR) Then
                Return HttpNotFound()
            End If
            Return View(pROVEEDOR)
        End Function

        ' GET: PROVEEDORs/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: PROVEEDORs/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="IdProveedor,Nombre,Email")> ByVal pROVEEDOR As PROVEEDOR) As ActionResult
            If ModelState.IsValid Then
                db.PROVEEDOR.Add(pROVEEDOR)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(pROVEEDOR)
        End Function

        ' GET: PROVEEDORs/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim pROVEEDOR As PROVEEDOR = db.PROVEEDOR.Find(id)
            If IsNothing(pROVEEDOR) Then
                Return HttpNotFound()
            End If
            Return View(pROVEEDOR)
        End Function

        ' POST: PROVEEDORs/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="IdProveedor,Nombre,Email")> ByVal pROVEEDOR As PROVEEDOR) As ActionResult
            If ModelState.IsValid Then
                db.Entry(pROVEEDOR).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(pROVEEDOR)
        End Function

        ' GET: PROVEEDORs/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim pROVEEDOR As PROVEEDOR = db.PROVEEDOR.Find(id)
            If IsNothing(pROVEEDOR) Then
                Return HttpNotFound()
            End If
            Return View(pROVEEDOR)
        End Function

        ' POST: PROVEEDORs/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim pROVEEDOR As PROVEEDOR = db.PROVEEDOR.Find(id)
            db.PROVEEDOR.Remove(pROVEEDOR)
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
