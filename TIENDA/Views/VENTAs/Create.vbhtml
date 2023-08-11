@ModelType TIENDA.VENTA

<h2>Create</h2>

@Using (Html.BeginForm("Create", "VENTAs", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"}))
	@Html.AntiForgeryToken()
	@Html.ValidationSummary(True, "", New With {.class = "text-danger"})

	@<div Class="form-group">
		@Html.LabelFor(Function(model) model.IdPrenda, "IdPrenda", htmlAttributes:=New With {.class = "control-label col-md-2"})
		<div Class="col-md-10">
			@Html.DropDownList("IdPrenda", Nothing, htmlAttributes:=New With {.class = "form-control"})
			@Html.ValidationMessageFor(Function(model) model.IdPrenda, "", New With {.class = "text-danger"})
		</div>
	</div>

	@<div Class="form-group">
		@Html.LabelFor(Function(model) model.IdCliente, "Cliente", htmlAttributes:=New With {.class = "control-label col-md-2"})
		<div Class="col-md-10">
			@Html.DropDownList("IdCliente", Nothing, htmlAttributes:=New With {.class = "form-control"})
			@Html.ValidationMessageFor(Function(model) model.IdCliente, "", New With {.class = "text-danger"})
		</div>
	</div>

	@<div Class="form-group">
		@Html.LabelFor(Function(model) model.Cantidad, htmlAttributes:=New With {.class = "control-label col-md-2"})
		<div Class="col-md-10">
			@Html.EditorFor(Function(model) model.Cantidad, New With {.htmlAttributes = New With {.class = "form-control"}})
			@Html.ValidationMessageFor(Function(model) model.Cantidad, "", New With {.class = "text-danger"})
		</div>
	</div>

	@<div Class="form-group">
		<div Class="col-md-offset-2 col-md-10">
			<input type="submit" value="Realizar Venta" Class="btn btn-default" />
		</div>
	</div>
End Using

<div>
	@Html.ActionLink("Back to List", "Index")
</div>