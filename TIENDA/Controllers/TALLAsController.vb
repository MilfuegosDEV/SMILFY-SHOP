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
    Public Class TALLAsController
        Inherits System.Web.Mvc.Controller

        Private db As New PROYECTOEntities

        ' GET: TALLAs
        Function Index() As ActionResult
            Return View(db.TALLA.ToList())
        End Function

        ' GET: TALLAs/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tALLA As TALLA = db.TALLA.Find(id)
            If IsNothing(tALLA) Then
                Return HttpNotFound()
            End If
            Return View(tALLA)
        End Function

        ' GET: TALLAs/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: TALLAs/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="IdTalla,Nombre")> ByVal tALLA As TALLA) As ActionResult
            If ModelState.IsValid Then
                db.TALLA.Add(tALLA)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(tALLA)
        End Function

        ' GET: TALLAs/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tALLA As TALLA = db.TALLA.Find(id)
            If IsNothing(tALLA) Then
                Return HttpNotFound()
            End If
            Return View(tALLA)
        End Function

        ' POST: TALLAs/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="IdTalla,Nombre")> ByVal tALLA As TALLA) As ActionResult
            If ModelState.IsValid Then
                db.Entry(tALLA).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(tALLA)
        End Function

        ' GET: TALLAs/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tALLA As TALLA = db.TALLA.Find(id)
            If IsNothing(tALLA) Then
                Return HttpNotFound()
            End If
            Return View(tALLA)
        End Function

        ' POST: TALLAs/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim tALLA As TALLA = db.TALLA.Find(id)
            db.TALLA.Remove(tALLA)
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
