@ModelType IEnumerable(Of TIENDA.DEPARTAMENTO)
@Code
    ViewData("Title") = "Index"
End Code

<main>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="@Url.Action("Index", "Home")">Home</a></li>
        <li class="breadcrumb-item active">Departamentos</li>
    </ol>

    <div class="card">
        <div class="card-header">
            <i class="fas fa-users me-1"></i> Lista de Departamentos
        </div>

        <div class="card-body mb-4">
            <div class="row">
                <div class="col-12">
                    <a class="btn btn-success" href="@Url.Action("CREATE", "DEPARTAMENTOes")">Añadir</a>
                </div>
            </div>

            <hr />
            <table id="tablaUsuarios" class="table table-responsive w-100 table-striped table-bordered">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Nombre</th>
                        <th width="110px"></th>
                    </tr>
                </thead>
                <tbody>
                    @For Each item In Model
                        @<tr>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.IdDepartamento)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Nombre)
                            </td>
                            <td>
                                <a href="@Url.Action("Edit", "DEPARTAMENTOes", New With {.id = item.IdDepartamento})" class="btn btn-outline-success btn-sm"><i class="fas fa-pen"></i></a> |
                                <a href="@Url.Action("Details", "DEPARTAMENTOes", New With {.id = item.IdDepartamento})" class="btn btn-outline-secondary btn-sm"><i class="fas fa-book"></i></a> |
                                <a href="@Url.Action("Delete", "DEPARTAMENTOes", New With {.id = item.IdDepartamento})" class="btn btn-outline-danger btn-sm"><i class="fas fa-trash"></i></a>
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
