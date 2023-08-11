@ModelType IEnumerable(Of TIENDA.VENTA)
@Code
	ViewData("Title") = "Home Page"
End Code

<main>
	<h1 class="mt-4">Dashboard</h1>

	<div class="row">
		<div class="col-xl-3 col-md-6">
			<div class="card bg-success text-white mb-4">
				<div class="card-body">
					<div class="row">
						<div class="col-sm-9">
							<h6>Cantidad Clientes</h6>
							<h6 id="totalcliente">@ViewBag.CantidadClientes</h6>
						</div>
						<div class="col-sm-3">
							<i class="fas fa-user fa-2x"></i>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="col-xl-3 col-md-6">
			<div class="card bg-warning text-white mb-4">
				<div class="card-body">
					<div class="row">
						<div class="col-sm-9">
							<h6>Cantidad Ventas</h6>
							<h6 id="totalventa">@ViewBag.CantidadVentas</h6>
						</div>
						<div class="col-sm-3">
							<i class="fas fa-shopping-bag fa-2x"></i>
						</div>
					</div>
				</div>
			</div>
		</div>

	</div>


	<div class="card mb-4">
		<div class="card-header">
			<i class="fas fa-tags me-1"></i>
			Historial de Ventas
		</div>
		<div class="card-body">

			<form method="get">
				<div class="row align-items-end">
					<div class="col-sm-2">
						<div class="mb-2">
							<label class="form-label">Fecha de Inicio:</label>
							<input class="form-control" type="text" id="txtfechainicio" name="fechainicio" />
						</div>
					</div>
					<div class="col-sm-2">
						<div class="mb-2">
							<label class="form-label">Fecha Fin:</label>
							<input class="form-control" type="text" id="txtfechafin" name="fechafin" />
						</div>
					</div>
					<div class="col-sm-2">
						<div class="mb-2">
							<label class="form-label">ID Venta:</label>
							<input class="form-control" type="text" id="txtidventa" name="idventa" />
						</div>
					</div>
					<div class="col-sm-2">
						<div class="d-grid mb-2">
							<button class="btn btn-primary" id="btnbuscar" type="submit"><i class="fas fa-search"></i> Buscar</button>
						</div>
					</div>
					@*TODO:
						<div class="col-sm-2">
						<div class="d-grid mb-2">
							<button class="btn btn-success" type="submit"><i class="fas fa-file-excel"></i> Exportar</button>
						</div>
					</div>*@
				</div>
			</form>

			<hr />

			<div class="row">

				<div class="col-sm-12">
					<table id="tablaUsuarios" class="table table-responsive w-100 table-striped table-bordered">
						<thead>
							<tr>
								<th>Id</th>
								<th>IdPrenda</th>
								<th>IdCliente</th>
								<th>Cantidad</th>
								<th>Fecha</th>
							</tr>
						</thead>
						<tbody>

							@if Model IsNot Nothing Then
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

									</tr>
								Next
							Else
								@<p>No hay datos disponibles.</p>
							End If

						</tbody>
					</table>
				</div>

			</div>


		</div>
	</div>



</main>

@section scripts
	<script>
		$('#tablaVentas').DataTable({
			"paging": true,
			"ordering": true,
			"responsive": true,
			"language": {
				"url": "https://cdn.datatables.net/plug-ins/1.11.3/i18n/es_es.json"
			}
		});
	</script>
END section