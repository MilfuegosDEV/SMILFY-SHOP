@ModelType IEnumerable(Of TIENDA.CLIENTE)
@Code
	ViewData("Title") = "Clientes"
End Code




<main>
	<ol class="breadcrumb">
		<li class="breadcrumb-item"><a href="@Url.Action("Index", "Home")">Home</a></li>
		<li class="breadcrumb-item active">Clientes</li>
	</ol>

	<div class="card">
		<div class="card-header">
			<i class="fas fa-users me-1"></i> Lista de Usuarios
		</div>

		<div class="card-body mb-4">
			<div class="row">
				<div class="col-12">
					<a class="btn btn-success" href="@Url.Action("CREATE", "CLIENTEs")">Añadir</a>
				</div>
			</div>

			<hr />
			<table id="tablaUsuarios" class="table table-responsive w-100 table-striped table-bordered">
				<thead>
					<tr>
						<th>Id</th>
						<th>Nombre</th>
						<th>Apellido</th>
						<th>Correo electrónico</th>
						<th width="110px"></th>
					</tr>
				</thead>
				<tbody>
					@For Each item In Model
						@<tr>
							<td>
								@Html.DisplayFor(Function(modelItem) item.IdCliente)
							</td>
							<td>
								@Html.DisplayFor(Function(modelItem) item.Nombre)
							</td>
							<td>
								@Html.DisplayFor(Function(modelItem) item.Apellido)
							</td>
							<td>
								@Html.DisplayFor(Function(modelItem) item.Email)
							</td>
							<td>
								<a href="@Url.Action("Edit", "CLIENTEs", New With {.id = item.IdCliente})" class="btn btn-outline-success btn-sm"><i class="fas fa-pen"></i></a> |
								<a href="@Url.Action("Details", "CLIENTEs", New With {.id = item.IdCliente})" class="btn btn-outline-secondary btn-sm"><i class="fas fa-book"></i></a> |
								<a href="@Url.Action("Delete", "CLIENTEs", New With {.id = item.IdCliente})" class="btn btn-outline-danger btn-sm"><i class="fas fa-trash"></i></a>
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