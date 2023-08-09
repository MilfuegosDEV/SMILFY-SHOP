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
    Public Class MARCAsController
        Inherits System.Web.Mvc.Controller

        Private db As New PROYECTOEntities

        ' GET: MARCAs
        Function Index() As ActionResult
            Return View(db.MARCA.ToList())
        End Function

        ' GET: MARCAs/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim mARCA As MARCA = db.MARCA.Find(id)
            If IsNothing(mARCA) Then
                Return HttpNotFound()
            End If
            Return View(mARCA)
        End Function

        ' GET: MARCAs/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: MARCAs/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="IdMarca,Nombre")> ByVal mARCA As MARCA) As ActionResult
            If ModelState.IsValid Then
                db.MARCA.Add(mARCA)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(mARCA)
        End Function

        ' GET: MARCAs/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim mARCA As MARCA = db.MARCA.Find(id)
            If IsNothing(mARCA) Then
                Return HttpNotFound()
            End If
            Return View(mARCA)
        End Function

        ' POST: MARCAs/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="IdMarca,Nombre")> ByVal mARCA As MARCA) As ActionResult
            If ModelState.IsValid Then
                db.Entry(mARCA).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(mARCA)
        End Function

        ' GET: MARCAs/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim mARCA As MARCA = db.MARCA.Find(id)
            If IsNothing(mARCA) Then
                Return HttpNotFound()
            End If
            Return View(mARCA)
        End Function

        ' POST: MARCAs/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim mARCA As MARCA = db.MARCA.Find(id)
            db.MARCA.Remove(mARCA)
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
