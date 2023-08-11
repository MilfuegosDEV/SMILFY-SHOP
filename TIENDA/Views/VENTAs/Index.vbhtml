@ModelType IEnumerable(Of TIENDA.VENTA)
@Code
    ViewData("Title") = "Index"
End Code

<main>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="@Url.Action("Index", "Home")">Home</a></li>
        <li class="breadcrumb-item active">Ventas</li>
    </ol>

    <div class="card">
        <div class="card-header">
            <i class="fas fa-users me-1"></i> Lista de Ventas
        </div>

        <div class="card-body mb-4">
            <div class="row">
                <div class="col-12">
                    <a class="btn btn-success" href="@Url.Action("Create", "VENTAs")">Añadir</a>
                </div>
            </div>

            <hr />
            <table id="tablaUsuarios" class="table table-responsive w-100 table-striped table-bordered">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>IdPrenda</th>
                        <th>IdCliente</th>
                        <th>Cantidad</th>
                        <th>Fecha</th>
                        <th width="110px"></th>
                    </tr>
                </thead>
                <tbody>
                    @For Each item In Model
                        @<tr>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.IdVenta)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.IdPrenda)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.IdCliente)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Cantidad)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Fecha)
                            </td>

                            <td>
                                <a href="@Url.Action("Edit", "VENTAs", New With {.id = item.IdVenta})" class="btn btn-outline-success btn-sm"><i class="fas fa-pen"></i></a> |
                                <a href="@Url.Action("Details", "VENTAs", New With {.id = item.IdVenta})" class="btn btn-outline-secondary btn-sm"><i class="fas fa-book"></i></a> |
                                <a href="@Url.Action("Delete", "VENTAs", New With {.id = item.IdVenta})" class="btn btn-outline-danger btn-sm"><i class="fas fa-trash"></i></a>
                            </td>
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
    </div>
</main>
@section scripts
    <script>
        $('#tablaUsuarios').DataTable({
            "paging": true,
            "ordering": true,
            "responsive": true,
            "language": {
                "url": "https://cdn.datatables.net/plug-ins/1.11.3/i18n/es_es.json"
            }
        });
    </script>
END section
