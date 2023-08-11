@ModelType TIENDA.PRENDA
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.IdPrenda }) |
    @Html.ActionLink("Back to List", "Index")
</p>
