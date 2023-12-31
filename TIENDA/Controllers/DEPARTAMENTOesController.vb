﻿Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports TIENDA

Namespace Controllers
    Public Class DEPARTAMENTOesController
        Inherits System.Web.Mvc.Controller

        Private db As New PROYECTOEntities

        ' GET: DEPARTAMENTOes
        Function Index() As ActionResult
            Return View(db.DEPARTAMENTO.ToList())
        End Function

        ' GET: DEPARTAMENTOes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim dEPARTAMENTO As DEPARTAMENTO = db.DEPARTAMENTO.Find(id)
            If IsNothing(dEPARTAMENTO) Then
                Return HttpNotFound()
            End If
            Return View(dEPARTAMENTO)
        End Function

        ' GET: DEPARTAMENTOes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: DEPARTAMENTOes/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="IdDepartamento,Nombre")> ByVal dEPARTAMENTO As DEPARTAMENTO) As ActionResult
            If ModelState.IsValid Then
                db.DEPARTAMENTO.Add(dEPARTAMENTO)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(dEPARTAMENTO)
        End Function

        ' GET: DEPARTAMENTOes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim dEPARTAMENTO As DEPARTAMENTO = db.DEPARTAMENTO.Find(id)
            If IsNothing(dEPARTAMENTO) Then
                Return HttpNotFound()
            End If
            Return View(dEPARTAMENTO)
        End Function

        ' POST: DEPARTAMENTOes/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="IdDepartamento,Nombre")> ByVal dEPARTAMENTO As DEPARTAMENTO) As ActionResult
            If ModelState.IsValid Then
                db.Entry(dEPARTAMENTO).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(dEPARTAMENTO)
        End Function

        ' GET: DEPARTAMENTOes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim dEPARTAMENTO As DEPARTAMENTO = db.DEPARTAMENTO.Find(id)
            If IsNothing(dEPARTAMENTO) Then
                Return HttpNotFound()
            End If
            Return View(dEPARTAMENTO)
        End Function

        ' POST: DEPARTAMENTOes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim dEPARTAMENTO As DEPARTAMENTO = db.DEPARTAMENTO.Find(id)
            db.DEPARTAMENTO.Remove(dEPARTAMENTO)
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
