Imports System.Data.Entity
Imports System.Data.SqlClient
Imports System.Net

Namespace Controllers
    Public Class CLIENTEsController
        Inherits System.Web.Mvc.Controller

        Private db As New PROYECTOEntities

        ' GET: CLIENTEs
        Function Index() As ActionResult
            Return View(db.CLIENTE.ToList())
        End Function

        ' GET: CLIENTEs/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cLIENTE As CLIENTE = db.CLIENTE.Find(id)
            If IsNothing(cLIENTE) Then
                Return HttpNotFound()
            End If
            Return View(cLIENTE)
        End Function

        ' GET: CLIENTEs/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: CLIENTEs/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="IdCliente,Nombre,Apellido,Email,Clave")> ByVal cLIENTE As CLIENTE) As ActionResult
            If ModelState.IsValid Then
                Dim parameters As SqlParameter() = {
                    New SqlParameter("@Nombre", cLIENTE.Nombre),
                    New SqlParameter("@Apellido", cLIENTE.Apellido),
                    New SqlParameter("@Email", cLIENTE.Email),
                    New SqlParameter("@Clave", cLIENTE.Clave),
                    New SqlParameter("@Mensaje", SqlDbType.VarChar, 500) With {.Direction = ParameterDirection.Output},
                    New SqlParameter("@Resultado", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
                }

                db.Database.ExecuteSqlCommand("exec InsertarCliente @Nombre, @Apellido, @Email, @Clave, @Mensaje OUTPUT, @Resultado OUTPUT", parameters)

                Dim resultado As Integer = Convert.ToInt32(parameters.FirstOrDefault(Function(p) p.ParameterName = "@Resultado")?.Value)
                Dim mensaje As String = parameters.FirstOrDefault(Function(p) p.ParameterName = "@Mensaje")?.Value.ToString()

                If resultado > 0 Then
                    Return RedirectToAction("Index")
                Else
                    ModelState.AddModelError("", mensaje)
                End If
            End If

            Return View(cLIENTE)
        End Function


        ' GET: CLIENTEs/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cLIENTE As CLIENTE = db.CLIENTE.Find(id)
            If IsNothing(cLIENTE) Then
                Return HttpNotFound()
            End If
            Return View(cLIENTE)
        End Function

        ' POST: CLIENTEs/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="IdCliente,Nombre,Apellido,Email,Clave")> ByVal cLIENTE As CLIENTE) As ActionResult
            If ModelState.IsValid Then
                Dim parameters As SqlParameter() = {
            New SqlParameter("@IdCliente", cLIENTE.IdCliente),
            New SqlParameter("@Nombre", cLIENTE.Nombre),
            New SqlParameter("@Apellido", cLIENTE.Apellido),
            New SqlParameter("@Email", cLIENTE.Email),
            New SqlParameter("@Mensaje", SqlDbType.VarChar, 500) With {.Direction = ParameterDirection.Output},
            New SqlParameter("@Resultado", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
        }

                db.Database.ExecuteSqlCommand("exec EditarCliente @IdCliente, @Nombre, @Apellido, @Email, @Mensaje OUTPUT, @Resultado OUTPUT", parameters)

                Dim resultado As Integer = Convert.ToInt32(parameters.FirstOrDefault(Function(p) p.ParameterName = "@Resultado")?.Value)
                Dim mensaje As String = parameters.FirstOrDefault(Function(p) p.ParameterName = "@Mensaje")?.Value.ToString()

                If resultado > 0 Then
                    Return RedirectToAction("Index")
                Else
                    ModelState.AddModelError("", mensaje)
                End If
            End If

            Return View(cLIENTE)
        End Function

        ' GET: CLIENTEs/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cLIENTE As CLIENTE = db.CLIENTE.Find(id)
            If IsNothing(cLIENTE) Then
                Return HttpNotFound()
            End If
            Return View(cLIENTE)
        End Function

        ' POST: CLIENTEs/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim cLIENTE As CLIENTE = db.CLIENTE.Find(id)
            db.CLIENTE.Remove(cLIENTE)
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
