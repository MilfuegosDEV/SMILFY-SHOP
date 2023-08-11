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
    Public Class PRENDAsController
        Inherits System.Web.Mvc.Controller

        Private db As New PROYECTOEntities

        ' GET: PRENDAs
        Function Index() As ActionResult
            Dim pRENDA = db.PRENDA.Include(Function(p) p.DEPARTAMENTO).Include(Function(p) p.MARCA).Include(Function(p) p.PROVEEDOR).Include(Function(p) p.TALLA)
            Return View(pRENDA.ToList())
        End Function

        ' GET: PRENDAs/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim pRENDA As PRENDA = db.PRENDA.Find(id)
            If IsNothing(pRENDA) Then
                Return HttpNotFound()
            End If
            Return View(pRENDA)
        End Function

        ' GET: PRENDAs/Create
        Function Create() As ActionResult
            ViewBag.IdDepartamento = New SelectList(db.DEPARTAMENTO, "IdDepartamento", "Nombre")
            ViewBag.IdMarca = New SelectList(db.MARCA, "IdMarca", "Nombre")
            ViewBag.IdProvedor = New SelectList(db.PROVEEDOR, "IdProveedor", "Nombre")
            ViewBag.IdTalla = New SelectList(db.TALLA, "IdTalla", "Nombre")
            Return View()
        End Function

        ' POST: PRENDAs/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="IdPrenda,IdMarca,IdTalla,IdDepartamento,IdProvedor,Precio,Stock")> ByVal pRENDA As PRENDA) As ActionResult
            If ModelState.IsValid Then
                db.PRENDA.Add(pRENDA)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.IdDepartamento = New SelectList(db.DEPARTAMENTO, "IdDepartamento", "Nombre", pRENDA.IdDepartamento)
            ViewBag.IdMarca = New SelectList(db.MARCA, "IdMarca", "Nombre", pRENDA.IdMarca)
            ViewBag.IdProvedor = New SelectList(db.PROVEEDOR, "IdProveedor", "Nombre", pRENDA.IdProvedor)
            ViewBag.IdTalla = New SelectList(db.TALLA, "IdTalla", "Nombre", pRENDA.IdTalla)
            Return View(pRENDA)
        End Function

        ' GET: PRENDAs/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim pRENDA As PRENDA = db.PRENDA.Find(id)
            If IsNothing(pRENDA) Then
                Return HttpNotFound()
            End If
            ViewBag.IdDepartamento = New SelectList(db.DEPARTAMENTO, "IdDepartamento", "Nombre", pRENDA.IdDepartamento)
            ViewBag.IdMarca = New SelectList(db.MARCA, "IdMarca", "Nombre", pRENDA.IdMarca)
            ViewBag.IdProvedor = New SelectList(db.PROVEEDOR, "IdProveedor", "Nombre", pRENDA.IdProvedor)
            ViewBag.IdTalla = New SelectList(db.TALLA, "IdTalla", "Nombre", pRENDA.IdTalla)
            Return View(pRENDA)
        End Function

        ' POST: PRENDAs/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="IdPrenda,IdMarca,IdTalla,IdDepartamento,IdProvedor,Precio,Stock")> ByVal pRENDA As PRENDA) As ActionResult
            If ModelState.IsValid Then
                db.Entry(pRENDA).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.IdDepartamento = New SelectList(db.DEPARTAMENTO, "IdDepartamento", "Nombre", pRENDA.IdDepartamento)
            ViewBag.IdMarca = New SelectList(db.MARCA, "IdMarca", "Nombre", pRENDA.IdMarca)
            ViewBag.IdProvedor = New SelectList(db.PROVEEDOR, "IdProveedor", "Nombre", pRENDA.IdProvedor)
            ViewBag.IdTalla = New SelectList(db.TALLA, "IdTalla", "Nombre", pRENDA.IdTalla)
            Return View(pRENDA)
        End Function

        ' GET: PRENDAs/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim pRENDA As PRENDA = db.PRENDA.Find(id)
            If IsNothing(pRENDA) Then
                Return HttpNotFound()
            End If
            Return View(pRENDA)
        End Function

        ' POST: PRENDAs/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim pRENDA As PRENDA = db.PRENDA.Find(id)
            db.PRENDA.Remove(pRENDA)
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
