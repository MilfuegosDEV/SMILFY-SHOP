@ModelType TIENDA.PRENDA
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>PRENDA</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Precio)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Precio)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Stock)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Stock)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DEPARTAMENTO.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DEPARTAMENTO.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.MARCA.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MARCA.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PROVEEDOR.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PROVEEDOR.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TALLA.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TALLA.Nombre)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
